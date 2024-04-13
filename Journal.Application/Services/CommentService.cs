namespace Journal.Application.Services
{
    ///  <inheritdoc/>
    public class CommentService : ICommentService
    {
        private readonly IBaseRepository<Comment> _commentRepository;

        private readonly IBaseRepository<Article> _articleRepository;

        private readonly IBaseRepository<User> _userRepository;

        private readonly ICommentValidator _commentValidator;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public CommentService(IBaseRepository<Comment> commentRepository,
            IBaseRepository<Article> articleRepository,
            IBaseRepository<User> userRepository,
            ILogger logger,
            ICommentValidator commentValidator,
            IMapper mapper)
        {
            _commentRepository = commentRepository;
            _articleRepository = articleRepository;
            _logger = logger;
            _userRepository = userRepository;
            _commentValidator = commentValidator;
            _mapper = mapper;
        }

        ///  <inheritdoc/>
        public async Task<CollectionResult<CommentDto>> GetCommentsByArticleIdAsync(Guid articleId)
        {
            CommentDto[] comments;

            try
            {
                comments = await _commentRepository.GetAll()
                    .AsNoTracking()
                    .Where(c => c.ArticleId == articleId)
                    .Select(c => new CommentDto(c.Id, c.Text, c.ArticleId, c.UserId, c.CreatedAt))
                    .ToArrayAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new CollectionResult<CommentDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }

            if (!comments.Any())
            {
                _logger.Warning(ErrorMessage.CommentsNotFound, comments.Length);
                return new CollectionResult<CommentDto>
                {
                    ErrorMessage = ErrorMessage.CommentsNotFound,
                    ErrorCode = (int)ErrorCodes.CommentsNotFound,
                };
            }

            return new CollectionResult<CommentDto>
            {
                Data = comments,
                Count = comments.Length,
            };
        }

        ///  <inheritdoc/>
        public async Task<CollectionResult<CommentDto>> GetCommentsByUserId(Guid userId)
        {
            CommentDto[] comments;

            try
            {
                comments = await _commentRepository.GetAll()
                    .AsNoTracking()
                    .Where(c => c.UserId == userId)
                    .Select(c => new CommentDto(c.Id, c.Text, c.ArticleId, c.UserId, c.CreatedAt))
                    .ToArrayAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new CollectionResult<CommentDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }

            if (!comments.Any())
            {
                return new CollectionResult<CommentDto>
                {
                    ErrorMessage = ErrorMessage.CommentsNotFound,
                    ErrorCode = (int)ErrorCodes.CommentsNotFound,
                };
            }

            return new CollectionResult<CommentDto>
            {
                Data = comments,
                Count = comments.Length,
            };
        }

        ///  <inheritdoc/>
        public async Task<BaseResult<CommentDto>> CreateCommentAsync(CreateCommentDto dto)
        {
            try
            {
                var comments = await _commentRepository.GetAll()
                    .AsNoTracking()
                    .Where(c => c.Text.ToLower() == dto.Text.ToLower() &&
                    c.ArticleId == dto.ArticleId &&
                    c.UserId == dto.UserId)
                    .ToArrayAsync();

                var user = await _userRepository.GetAll()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Id == dto.UserId);

                var article = await _articleRepository.GetAll()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(a => a.Id == dto.ArticleId);

                var result = _commentValidator.CreateValidator(comments, user, article);

                if (!result.IsSuccess)
                {
                    return new BaseResult<CommentDto>
                    {
                        ErrorMessage = result.ErrorMessage,
                        ErrorCode = result.ErrorCode,
                    };
                }

                var comment = _mapper.Map<Comment>(dto);
                await _commentRepository.CreateAsync(comment);

                return new BaseResult<CommentDto>
                {
                    Data = _mapper.Map<CommentDto>(comment),
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<CommentDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }
        }

        ///  <inheritdoc/>
        public async Task<BaseResult<CommentDto>> UpdateCommentAsync(UpdateCommentDto dto)
        {
            try
            {
                var comment = await _commentRepository.GetAll()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == dto.Id);

                var article = await _articleRepository.GetAll()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(a => a.Id == dto.ArticleId);

                var result = _commentValidator.UpdateValidator(comment, article);

                if (!result.IsSuccess)
                {
                    return new BaseResult<CommentDto>
                    {
                        ErrorMessage = result.ErrorMessage, 
                        ErrorCode = result.ErrorCode,
                    };
                }

                comment.Text = dto.Text;
                await _commentRepository.UpdateAsync(comment);

                return new BaseResult<CommentDto>
                {
                    Data = _mapper.Map<CommentDto>(comment),
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<CommentDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }
        }

        ///  <inheritdoc/>
        public async Task<BaseResult<CommentDto>> GetByIdAsync(Guid id)
        {
            CommentDto? comment;
            try
            {
                comment = await _commentRepository.GetAll()
                    .AsNoTracking()
                    .Select(c => new CommentDto(c.Id, c.Text, c.ArticleId, c.UserId, c.CreatedAt))
                    .FirstOrDefaultAsync(c => c.Id ==  id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<CommentDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }
            if (comment == null)
            {
                _logger.Warning(ErrorMessage.CommentNotFound, id);
                return new BaseResult<CommentDto>
                {
                    ErrorMessage = ErrorMessage.CommentNotFound,
                    ErrorCode = (int)ErrorCodes.CommentNotFound,
                };
            }
            return new BaseResult<CommentDto>
            {
                Data = _mapper.Map<CommentDto>(comment),
            };
        }

        ///  <inheritdoc/>
        public async Task<BaseResult<CommentDto>> DeleteCommentAsync(Guid commentId)
        {
            try
            {
                var comment = await _commentRepository.GetAll()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == commentId);
                var result = _commentValidator.ValidateOnNull(comment);
                if (!result.IsSuccess)
                {
                    return new BaseResult<CommentDto>
                    {
                        ErrorMessage = result.ErrorMessage,
                        ErrorCode = result.ErrorCode,
                    };
                }
                await _commentRepository.DeleteAsync(comment);
                return new BaseResult<CommentDto>
                {
                    Data = _mapper.Map<CommentDto>(comment),
                };
            }
            catch (Exception ex)
            { 
                _logger.Error(ex, ex.Message);
                return new BaseResult<CommentDto> 
                { 
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError
                };
            }
        }
    }
}
