namespace Journal.Application.Services
{
    public class TagService : ITagService
    {
        private readonly IBaseRepository<Tag> _tagRepository;

        private readonly IBaseRepository<Article> _articleRepository;

        private readonly ITagVlidator _tagVlidator;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public TagService(IBaseRepository<Tag> tagRepository,
            IBaseRepository<Article> articleRepository,
            ITagVlidator tagVlidator,
            ILogger logger,
            IMapper mapper)
        {
            _tagRepository = tagRepository;
            _tagVlidator = tagVlidator;
            _logger = logger;
            _mapper = mapper;
            _articleRepository = articleRepository;
        }

        /// <inheritdoc/>
        public async Task<CollectionResult<TagDto>> GetTagsAsync()
        {
            TagDto[]? tags;

            try
            {
                tags = await _tagRepository.GetAll().AsNoTracking()
                    .Select(t => new TagDto(t.Id, t.Title))
                    .ToArrayAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new CollectionResult<TagDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }

            if (!tags.Any())
            {
                return new CollectionResult<TagDto>
                {
                    ErrorMessage = ErrorMessage.TagsNotFound,
                    ErrorCode = (int)ErrorCodes.TagsNotFound,
                };
            }

            return new CollectionResult<TagDto>
            {
                Data = tags,
                Count = tags.Count()
            };
        }

        /// <inheritdoc/>
        public async Task<BaseResult<TagDto>> GetTagByIdAsync(Guid id)
        {
            TagDto? tag;
            try
            {
                 tag = await _tagRepository.GetAll().AsNoTracking()
                    .Select(t => new TagDto(t.Id, t.Title))
                    .FirstOrDefaultAsync(t => t.Id == id);
            }
            catch (Exception ex) 
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<TagDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }

            if (tag == null)
            {
                _logger.Warning(ErrorMessage.TagNotFound, id);
                return new BaseResult<TagDto>
                {
                    ErrorMessage = ErrorMessage.TagNotFound,
                    ErrorCode = (int)ErrorCodes.TagNotFound,
                };
            }

            return new BaseResult<TagDto>
            {
                Data = _mapper.Map<TagDto>(tag),
            };
        }

        /// <inheritdoc/>
        public async Task<BaseResult<TagDto>> CreateTagAsync(CreateTagDto dto)
        {
            try
            {
                var tag = await _tagRepository.GetAll().AsNoTracking()
                    .FirstOrDefaultAsync(t => t.Title.ToLower() == dto.Title.ToLower());

                var result = _tagVlidator.CreateValidator(tag);

                if (!result.IsSuccess)
                {
                    return new BaseResult<TagDto>
                    {
                        ErrorMessage = result.ErrorMessage,
                        ErrorCode = result.ErrorCode,
                    };
                }

                tag = _mapper.Map<Tag>(dto);
                await _tagRepository.CreateAsync(tag);

                return new BaseResult<TagDto>
                {
                    Data = _mapper.Map<TagDto>(tag)
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<TagDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode= (int)ErrorCodes.InternalServerError,
                };
            }
        }

        /// <inheritdoc/>
        public async Task<BaseResult<TagDto>> DeleteTagAsync(Guid id)
        {
            try
            {
                var tag = await _tagRepository.GetAll().AsNoTracking()
                    .FirstOrDefaultAsync(t => t.Id == id);

                var result = _tagVlidator.ValidateOnNull(tag);

                if (!result.IsSuccess)
                {
                    return new BaseResult<TagDto>
                    {
                        ErrorMessage = result.ErrorMessage,
                        ErrorCode = result.ErrorCode,
                    };
                }

                await _tagRepository.DeleteAsync(tag);

                return new BaseResult<TagDto>
                {
                    Data = _mapper.Map<TagDto>(tag)
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<TagDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }
        }

        /// <inheritdoc/>
        public async Task<BaseResult<TagDto>> UpdateTagAsync(UpdateTagDto dto)
        {
            try
            {
                var tag = await _tagRepository.GetAll().FirstOrDefaultAsync(t => t.Id == dto.Id);

                var result = _tagVlidator.ValidateOnNull(tag);

                if (!result.IsSuccess)
                {
                    return new BaseResult<TagDto>
                    {
                        ErrorMessage = result.ErrorMessage,
                        ErrorCode = (int)ErrorCodes.InternalServerError,
                    };
                }

                tag.Title = dto.Title;

                await _tagRepository.UpdateAsync(tag);

                return new BaseResult<TagDto>
                {
                    Data = _mapper.Map<TagDto>(tag),
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<TagDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }
        }
    }
}
