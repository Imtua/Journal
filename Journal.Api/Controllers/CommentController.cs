namespace Journal.Api.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// Request to GET a comment by Id.
        /// </summary>
        /// <param name="commentId"></param>
        /// <response code="200" >Comment received</response>
        /// <response code="400" >Internal server error</response>
        [HttpGet]
        [Route("{commentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CollectionResult<CommentDto>>> GetComment(Guid commentId)
        {
            var response = await _commentService.GetByIdAsync(commentId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        /// <summary>
        /// Request to CREATE a comment.
        /// </summary>
        /// <param name="request"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST
        ///     {
        ///         "text" : "Test comment",
        ///         "articleId" : "c920547f-7075-4bff-8182-7960f63521bf",
        ///         "userId" : "cff09933-e686-4448-98ad-7e438f8aa077"
        ///     }
        /// </remarks>
        /// <response code="200" >Comment created</response>
        /// <response code="400" >Internal server error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<CommentDto>>> AddComment([FromBody] CreateCommentDto request)
        {
            var response = await _commentService.CreateCommentAsync(request);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest();
        }


        /// <summary>
        /// Request to EDIT a comment for article.
        /// </summary>
        /// <param name="request"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT
        ///     {
        ///         "id" : "c920547f-7075-4bff-8182-7960f63521bf",
        ///         "text" : "Updated comment",
        ///         "articleId" : "c920547f-7075-4bff-8182-7960f63521bf",
        ///         "userId" : "cff09933-e686-4448-98ad-7e438f8aa077"
        ///     }
        /// </remarks>
        /// <response code="200" >Comment updated</response>
        /// <response code="400" >Internal server error</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<CommentDto>>> UpdateComment([FromBody] UpdateCommentDto request)
        {
            var response = await _commentService.UpdateCommentAsync(request);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Request to DELETE a comment.
        /// </summary>
        /// <param name="commentId"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE
        ///     {
        ///         "id" : ""
        ///     }
        /// </remarks>
        /// <response code="200" >Comment deleted</response>
        /// <response code="400" >Internal server error</response>
        [HttpDelete]
        [Route("{commentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<CommentDto>>> DeleteComment(Guid commentId)
        {
            var response = await _commentService.DeleteCommentAsync(commentId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
