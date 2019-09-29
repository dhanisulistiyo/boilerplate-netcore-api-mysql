using AutoMapper;
using boilerplate_netcore_api_mysql.Apps.Dtos.In;
using boilerplate_netcore_api_mysql.Apps.Dtos.Out;
using boilerplate_netcore_api_mysql.Apps.Interfaces;
using boilerplate_netcore_api_mysql.Apps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace boilerplate_netcore_api_mysql.Apps.Controllers
{
    /// <summary>
    /// PersonController
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/persons")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IRepositoryWrapper _repo;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public PersonController(IRepositoryWrapper repo, IMapper mapper, ILogger<PersonController> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }


        /// <summary>
        /// Get list person
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PersonOutDtos>), 200)]
        public async Task<ActionResult<IEnumerable<PersonOutDtos>>> Gets()
        {
            var data = await _repo.Person.Gets();
            _logger.LogInformation($"Showing list Person");
            return Ok(data);
        }

        /// <summary>
        /// Get Details
        /// </summary>
        /// <param name="Id"></param>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{Id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PersonOutDtos), 200)]
        public async Task<ActionResult<PersonOutDtos>> GetDetail(Guid Id)
        {
            var data = await _repo.Person.GetDetail(Id);
            _logger.LogInformation($"Get with Id: {Id}");
            if (data == null)
            {
                _logger.LogWarning($"{Id} hasn't been found in database.");
                return NotFound();
            }
            return Ok(data);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="personInDtos"></param>
        /// <response code="200">Success</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> Create([FromBody]  PersonInDtos personInDtos)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogCritical($"Invalid parameter");
                return BadRequest("Invalid parameter");
            }

            _logger.LogInformation($"Create : {personInDtos}");
            var res = await _repo.Person.Create(personInDtos);
            return Ok(res);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="personInDtos"></param>
        /// <response code="200">Success</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("{Id}")]
        public async Task<ActionResult> Update(Guid Id, [FromBody] PersonInDtos personInDtos)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogCritical($"Invalid parameter");
                return BadRequest("Invalid parameter");
            }

            _logger.LogInformation($"Get Detail with Id: {Id}");
            var dataOut = await _repo.Person.GetDetail(Id);

            _logger.LogInformation($"Updating with Id : {Id}");
            await _repo.Person.Update(dataOut, personInDtos);
            return Ok();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="Id"></param>
        /// <response code="200">Success</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogCritical($"Invalid parameter");
                return BadRequest("Invalid parameter");
            }

            _logger.LogInformation($"Get Detail with Id: {Id}");
            var dataOut = await _repo.Person.GetDetail(Id);
            if (dataOut == null)
            {
                _logger.LogWarning($"Get Detail with Id: {Id}, hasn't been found in database.");
                return NotFound();
            }

            _logger.LogInformation($"Updating with Id : {Id}");
            await _repo.Person.Delete(dataOut);
            return Ok();
        }
    }
}
