namespace Journal.Api.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        /// <summary>
        /// Request to GET tags.
        /// </summary>
        /// <response code="200" >Tags received</response>
        /// <response code="400" >Internal server error</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CollectionResult<TagDto>>> GetTags()
        {
            var response = await _tagService.GetTagsAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Request to GET a tag by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET
        ///     {
        ///         "id" : "0d52f8ef-1ce1-49d1-b126-26989af3250d"
        ///     }
        /// </remarks>
        /// <response code="200" >Tag received</response>
        /// <response code="400" >Internal server error</response>
        [HttpGet]
        [Route("{tagId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<TagDto>>> GetTagById(Guid tagId)
        {
            var response = await _tagService.GetTagByIdAsync(tagId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Request to CREATE a tag.
        /// </summary>
        /// <param name="request"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST
        ///     {
        ///         "title" : "Test tag #1"
        ///     }
        /// </remarks>
        /// <response code="200" >Tag created</response>
        /// <response code="400" >Internal server error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<TagDto>>> AddTag([FromBody]CreateTagDto request)
        {
            var response = await _tagService.CreateTagAsync(request);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Request to EDIT a tag.
        /// </summary>
        /// <param name="request"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT
        ///     {
        ///         "id" : "3ef9b2a3-3759-492c-bb8a-8710a3553081",
        ///         "title" : "Updated tag",
        ///     }
        /// </remarks>
        /// <response code="200" >Tag updated</response>
        /// <response code="400" >Internal server error</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<TagDto>>> UpdateTag([FromBody]UpdateTagDto request)
        {
            var response = await _tagService.UpdateTagAsync(request);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Request to DELETE a tag.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE
        ///     {
        ///         "id" : "ae38013a-a9ca-4029-96cf-3d91fe30fc8f"
        ///     }
        /// </remarks>
        /// <response code="200" >Tag deleted</response>
        /// <response code="400" >Internal server error</response>
        [HttpDelete]
        [Route("{tagId}")]
        public async Task<ActionResult<BaseResult<TagDto>>> DeleteTag(Guid tagId)
        {
            var response = await _tagService.DeleteTagAsync(tagId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
