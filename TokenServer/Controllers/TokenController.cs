using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TokenServer.Repository;
using TokenServerCore.Entities;
using System;

namespace TokenServer.Controllers
{
    /// <summary>
    /// TokenController
    /// </summary>
    [Route("api/v1/[controller]")]
    public class TokenController : Controller
    {
        private RedisRepository _redisRepository;

        /// <summary>
        /// TokenController
        /// </summary>
        /// <param name="redisRepository"></param>
        public TokenController(RedisRepository redisRepository)
        {
            _redisRepository = redisRepository;
        }

        /// <summary>
        /// Create a new token.
        /// </summary>
        /// <returns>token</returns>
        /// <response code="200">Token created successfuly.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Token token)
        {
            try
            {
                if (!token.IsValid())
                    return BadRequest();

                await _redisRepository.Set(token.Key, token.Value);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Format("An error has ocurred while trying to create a new token. Ex: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Returns a token based on key.
        /// </summary>
        /// <returns>token</returns>
        /// <response code="200">Token retrieved successfuly.</response>
        /// <response code="404">Bad request.</response>
        /// <response code="404">Token not found.</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                    return BadRequest();

                var r = await _redisRepository.Get(key);

                if (r == null)
                    return NotFound();
                else
                    return Ok(r);
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Format("An error has ocurred while trying to retrieve a token. Ex: {0}", ex.Message));
            }
        }
    }
}
