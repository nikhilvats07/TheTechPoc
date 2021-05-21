using EmployeeStory.BusinessEntities;
using EmployeeStory.WebAPI.DAL.Repositiry;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeStory.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoryController : ControllerBase
    {

        private readonly IMongoRepository<Story> _storyRepository;
        private readonly ILogger<StoryController> _logger;
        public StoryController(IMongoRepository<Story> peopleRepository, ILogger<StoryController> logger)
        {
            _storyRepository = peopleRepository;
            _logger = logger;
        }

        /// <summary>
        /// Create an Story
        /// </summary>
        /// <param name="story"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Story story)
        {
            _logger.LogInformation($"Create story {story.StoryId}");          
            await _storyRepository.InsertOneAsync(story);
            return Ok();
        }

        /// <summary>
        /// Update an story
        /// </summary>
        /// <param name="story"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Story story)
        {
            _logger.LogInformation($"Update story {story.StoryId}");

            await _storyRepository.ReplaceOneAsync(story);
            return Ok();

        }

        /// <summary>
        /// Return an story by ID
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{storyId}")]
        public async Task<IActionResult> Get(string storyId)
        {
            _logger.LogInformation($"Get story {storyId}");
            return Ok(await _storyRepository.FindByIdAsync(storyId));

        }

        /// <summary>
        /// Return all stories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Get All stories");
            return Ok(_storyRepository.AsQueryable().ToList());

        }

        /// <summary>
        /// Delete an story by ID
        /// </summary>
        /// <param name="storyID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{storyID:int}")]
        public async Task<ActionResult> Delete(string storyID)
        {
            _logger.LogInformation($"Delete story {storyID}");

            await _storyRepository.DeleteByIdAsync(storyID);
            return Ok();

        }


    }
}