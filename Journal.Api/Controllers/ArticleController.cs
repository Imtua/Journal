namespace Journal.Api.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        private readonly ITagService _tagService;

        private readonly ICommentService _commentService;

        public ArticleController(IArticleService articleService, ITagService tagService, ICommentService commentService)
        {
            _articleService = articleService;
            _tagService = tagService;
            _commentService = commentService;
        }

        /// <summary>
        /// Request to GET articles.
        /// </summary>
        /// <response code="200" >Articles received</response>
        /// <response code="400" >Internal server error</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CollectionResult<ArticleDto>>> GetArticles()
        {
            var response = await _articleService.GetArticlesAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Request to GET an article by Id.
        /// </summary>
        /// <param name="articleId"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET
        ///     {
        ///         "id" : "382b5a7b-d39a-4a76-b848-33cd03210187"
        ///     }
        /// </remarks>
        /// <response code="200" >Article received</response>
        /// <response code="400" >Internal server error</response>
        [HttpGet("{articleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<ArticleDto>>> GetArticleById(Guid articleId)
        {
            var response = await _articleService.GetArticleByIdAsync(articleId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Request to CREATE an article.
        /// </summary>
        /// <param name="request"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST
        ///     {
        ///         "title" : "Article #1",
        ///         "content" : "Some content",
        ///         "description" : "Some description",
        ///         "userId" : "cff09933-e686-4448-98ad-7e438f8aa077"
        ///     }
        /// </remarks>
        /// <response code="200">Article created</response>
        /// <response code="400" >Internal server error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<ArticleDto>>> AddArticle([FromBody] CreateArticleDto request)
        {
            var response = await _articleService.CreateArticleAsync(request);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Request to EDIT an article.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT
        ///     {
        ///         "id" : "c920547f-7075-4bff-8182-7960f63521bf",
        ///         "title" : "Updated title",
        ///         "content" : "Updated content",
        ///         "description" : "Updated description"
        ///     }
        /// </remarks>
        /// <response code="200" >Article updated</response>
        /// <response code="400" >Internal server error</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<ArticleDto>>> UpdateArticle([FromBody] UpdateArticleDto request)
        {
            var response = await _articleService.UpdateArticleAsync(request);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Request to DELETE an article.
        /// </summary>
        /// <param name="articleId"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE
        ///     {
        ///         "id" : "382b5a7b-d39a-4a76-b848-33cd03210187"
        ///     }
        /// </remarks>
        /// <response code="200" >Article deleted</response>
        /// <response code="400" >Internal server error</response>
        [HttpDelete]
        [Route("{articleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<ArticleDto>>> DeleteArticle(Guid articleId)
        {
            var response = await _articleService.DeleteArticleAsync(articleId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Request to GET article tags.
        /// </summary>
        /// <param name="articleId"></param>
        /// <response code="200" >Tags received</response>
        /// <response code="400" >Internal server error</response>
        [HttpGet]
        [Route("{articleId}/tags")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CollectionResult<TagDto>>> GetArticleTags(Guid articleId)
        {
            var response = await _articleService.GetTagsByArticleId(articleId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Request to CRETE a tag for an article. 
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="request"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST
        ///     {
        ///         "id" : ""
        ///         "title" : "Article #1",
        ///     }
        /// </remarks>
        /// <response code="200" >Tag created</response>
        /// <response code="400" >Internal server error</response>
        [HttpPost]
        [Route("{articleId}/tags/{tagId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<ArticleDto>>> AddTagToArticle(Guid articleId, Guid tagId)
        {
            var response = await _articleService.AddTagToArticleAsync(articleId, tagId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Request to DELETE a tag from article.
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="tagId"></param>
        /// <response code="200" >Tag deleted</response>
        /// <response code="400" >Internal server error</response>
        [HttpDelete]
        [Route("{articleId}/tags/{tagId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<TagDto>>> DeleteTagToArticle(Guid articleId, Guid tagId)
        {
            var response = await _articleService.DeleteTagToArticleAsync(articleId, tagId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Request to GET article comments.
        /// </summary>
        /// <param name="articleId"></param>
        /// <response code="200" >Comments recivied</response>
        /// <response code="400" >Internal server error</response>
        [HttpGet]
        [Route("{articleId}/comments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CollectionResult<CommentDto>>> GetArticleComments(Guid articleId)
        {
            var response = await _commentService.GetCommentsByArticleIdAsync(articleId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
