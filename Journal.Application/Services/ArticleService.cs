namespace Journal.Application.Services
{
    /// <inheritdoc/>
    public class ArticleService : IArticleService
    {
        private readonly IBaseRepository<Article> _articleRepository;

        private readonly IBaseRepository<User> _userRepository;

        private readonly IBaseRepository<Tag> _tagRepository;   

        private readonly IArticleValidator _articleValidator;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public ArticleService(IBaseRepository<Article> articleRepository,
            IBaseRepository<User> userRepository,
            IBaseRepository<Tag> tagRepository,
            IArticleValidator articleValidator,
            ILogger logger,
            IMapper mapper)
        {
            _articleRepository = articleRepository;
            _userRepository = userRepository;
            _tagRepository = tagRepository;
            _articleValidator = articleValidator;
            _logger = logger;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<CollectionResult<ArticleDto>> GetArticlesAsync()
        {
            ArticleDto[]? articles;
            try
            {
                articles = await _articleRepository.GetAll().AsNoTracking()
                    .Include(a => a.Tags)
                    .Select(a => new ArticleDto(a.Id, a.Title, a.Content, a.Description,
                        a.Tags.Select(t => new TagDto(t.Id, t.Title)),a.CreatedAt))
                    .ToArrayAsync();

            }

            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new CollectionResult<ArticleDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }

            if (!articles.Any())
            {
                _logger.Warning(ErrorMessage.ArticlesNotFound, articles.Length);
                return new CollectionResult<ArticleDto>
                {
                    ErrorMessage = ErrorMessage.ArticlesNotFound,
                    ErrorCode = (int)ErrorCodes.ArticlesNotFound,
                };
            }

            return new CollectionResult<ArticleDto>
            {
                Data = articles,
                Count = articles.Length
            };
        }

        /// <inheritdoc/>
        public async Task<CollectionResult<ArticleDto>> GetUserArticlesAsync(Guid userId)
        {
            ArticleDto[]? articles;
            try
            {
                articles = await _articleRepository.GetAll()
                    .Where(a => a.UserId == userId)
                    .Include(a => a.Tags)
                    .Select(a => new ArticleDto(a.Id,
                        a.Title,
                        a.Content,
                        a.Description,
                        a.Tags.Select(t => new TagDto(t.Id, t.Title)),
                        a.CreatedAt))
                    .ToArrayAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new CollectionResult<ArticleDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }

            if (!articles.Any())
            {
                _logger.Warning(ErrorMessage.ArticlesNotFound, articles.Length);
                return new CollectionResult<ArticleDto>
                {
                    ErrorMessage = ErrorMessage.ArticlesNotFound,
                    ErrorCode = (int)ErrorCodes.ArticlesNotFound,
                };
            }

            return new CollectionResult<ArticleDto> 
            { 
                Data = articles,
                Count = articles.Length
            };
        }

        /// <inheritdoc/>
        public async Task<BaseResult<ArticleDto>> GetArticleByIdAsync(Guid id)
        {
            ArticleDto? article;
            try
            {
                article = await _articleRepository.GetAll()
                    .AsNoTracking()
                    .Select(a => new ArticleDto(a.Id,
                        a.Title,
                        a.Content,
                        a.Description,
                        a.Tags.Select(t => new TagDto(t.Id, t.Title)),
                        a.CreatedAt))
                    .FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<ArticleDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }

            if (article == null)
            {
                _logger.Warning(ErrorMessage.ArticleNotFound, id);
                return new BaseResult<ArticleDto>
                {
                    ErrorMessage = ErrorMessage.ArticleNotFound,
                    ErrorCode = (int)ErrorCodes.ArticleNotFound,
                };
            }

            return new BaseResult<ArticleDto> 
            { 
                Data = article
            };
        }

        /// <inheritdoc/>
        public async Task<BaseResult<ArticleDto>> CreateArticleAsync(CreateArticleDto dto)
        {
            try
            {   
                var user = await _userRepository.GetAll().AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Id == dto.UserId);

                var article = await _articleRepository.GetAll().AsNoTracking()
                    .FirstOrDefaultAsync(a => a.Title == dto.Title);

                var result = _articleValidator.CreateValidator(article, user);

                if (!result.IsSuccess)
                {
                    return new BaseResult<ArticleDto>()
                    {
                        ErrorMessage =  result.ErrorMessage,
                        ErrorCode = result.ErrorCode,
                    };
                }

                article = _mapper.Map<Article>(dto);

                await _articleRepository.CreateAsync(article);

                return new BaseResult<ArticleDto>()
                {
                    Data = _mapper.Map<ArticleDto>(article),
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<ArticleDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }
        }

        /// <inheritdoc/>
        public async Task<BaseResult<ArticleDto>> DeleteArticleAsync(Guid id)
        {
            try
            {
                var article = await _articleRepository.GetAll().AsNoTracking()
                    .FirstOrDefaultAsync(a => a.Id == id);

                var result = _articleValidator.ValidateOnNull(article);

                if (!result.IsSuccess)
                {
                    return new BaseResult<ArticleDto>()
                    {
                        ErrorMessage = result.ErrorMessage,
                        ErrorCode = result.ErrorCode,
                    };
                }

                await _articleRepository.DeleteAsync(article);

                return new BaseResult<ArticleDto>
                {
                    Data = _mapper.Map<ArticleDto>(article),
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<ArticleDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }
        }

        /// <inheritdoc/>
        public async Task<BaseResult<ArticleDto>> UpdateArticleAsync(UpdateArticleDto dto)
        {
            try
            {
                var article = await _articleRepository.GetAll()
                    .FirstOrDefaultAsync(a => a.Id == dto.Id);

                var result = _articleValidator.ValidateOnNull(article);

                if (!result.IsSuccess)
                {
                    return new BaseResult<ArticleDto>()
                    {
                        ErrorMessage = result.ErrorMessage,
                        ErrorCode = result.ErrorCode,
                    };
                }

                article.Title = dto.Title;
                article.Content = dto.Content;
                article.Description = dto.Description;

                await _articleRepository.UpdateAsync(article);

                return new BaseResult<ArticleDto>
                {
                    Data = _mapper.Map<ArticleDto>(article),
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<ArticleDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }
        }


        /// <inheritdoc/>
        public async Task<CollectionResult<TagDto>> GetTagsByArticleId(Guid id)
        {
            TagDto[]? tags;
            try
            {
                tags = await _articleRepository.GetAll().AsNoTracking()
                    .Where(a => a.Id == id)
                    .Select(a => a.Tags.Select(t => new TagDto(t.Id, t.Title)).ToArray())
                    .FirstOrDefaultAsync();

                var result = _articleValidator.GetArticleTags(tags);

                if (!result.IsSuccess)
                {
                    return new CollectionResult<TagDto>
                    {
                        ErrorMessage = result.ErrorMessage,
                        ErrorCode = result.ErrorCode
                    };
                }

                return new CollectionResult<TagDto>
                {
                    Data = _mapper.Map<TagDto[]>(tags),
                    Count = tags.Count(),
                };
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
        }

        /// <inheritdoc/>
        public async Task<BaseResult<ArticleDto>> AddTagToArticleAsync(Guid articleId, Guid tagId)
        {
            try
            {
                var article = await _articleRepository.GetAll()
                    .Include(a => a.Tags)
                    .FirstOrDefaultAsync(a => a.Id == articleId);

                var tag = await _tagRepository.GetAll()
                    .FirstOrDefaultAsync(t => t.Id == tagId);

                var result = _articleValidator.AddTagToArticleValidator(article, tag);

                if (!result.IsSuccess)
                {
                    return new BaseResult<ArticleDto>
                    {
                        ErrorMessage = result.ErrorMessage,
                        ErrorCode = result.ErrorCode,
                    };
                }

                if (article.Tags.Contains(tag))
                {
                    return new BaseResult<ArticleDto>
                    {
                        ErrorMessage = ErrorMessage.TagAlreadyAppends,
                        ErrorCode = (int)ErrorCodes.TagAlreadyAppends,
                    };
                }

                article.Tags.Add(tag);
                await _articleRepository.UpdateAsync(article);

                return new BaseResult<ArticleDto>
                {
                    Data = _mapper.Map<ArticleDto>(article),
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<ArticleDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }
        }

        /// <inheritdoc/>
        public async Task<BaseResult<TagDto>> DeleteTagToArticleAsync(Guid articleId, Guid tagId)
        {
            try
            {
                var article = await _articleRepository.GetAll()
                    .Include(a => a.Tags)
                    .FirstOrDefaultAsync(a => a.Id == articleId);

                var tag = await _tagRepository.GetAll()
                    .FirstOrDefaultAsync(t => t.Id == tagId);

                var result = _articleValidator.DeleteTagToArticleValidator(article, tag);

                if (!result.IsSuccess)
                {
                    return new BaseResult<TagDto>
                    {
                        ErrorMessage = result.ErrorMessage,
                        ErrorCode = result.ErrorCode,
                    };
                }

                if (!article.Tags.Contains(tag))
                {
                    return new BaseResult<TagDto>
                    {
                        ErrorMessage = ErrorMessage.TagNotFound,
                        ErrorCode = (int)ErrorCodes.TagNotFound,
                    };
                }

                article.Tags.Remove(tag);
                await _articleRepository.UpdateAsync(article);

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
