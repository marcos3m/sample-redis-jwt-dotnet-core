using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TokenServer.Repository;

namespace TokenServer.Controllers
{
    [Route("api/v0/[controller]")]
    public class TokenController : Controller
    {
        private RedisRepository redisRepository;

        public TokenController(RedisRepository redisRepository)
        {
            this.redisRepository = redisRepository;
        }

        // GET api/values/5
        [HttpGet("{key}/{value}")]
        public async Task Set(string key, string value)
        {
            await this.redisRepository.Set(key, value);
        }

        // GET api/values/5
        [HttpGet("{value}")]
        public async Task<string> Get(string value)
        {
            return await this.redisRepository.Get(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
