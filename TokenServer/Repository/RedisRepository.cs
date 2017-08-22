using System;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace TokenServer.Repository
{
    public class RedisRepository
    {
        private ConnectionMultiplexer connection;
        
        public RedisRepository(AppConfiguration configuration)
        {
            if(string.IsNullOrEmpty(configuration.RedisServers))
            {
                throw new ArgumentException("The server list should not be null or empty.");
            }

            this.connection = ConnectionMultiplexer.Connect(configuration.RedisServers);
        }

        public async Task Set(string key, string value){
            if(string.IsNullOrEmpty(key))
            {
               throw new ArgumentException("The key should not be null or empty.");
            }

            var db = this.connection.GetDatabase();
            await db.StringSetAsync(key, value);
        }

        public async Task<string> Get(string key){
            if(string.IsNullOrEmpty(key))
            {
               throw new ArgumentException("The key should not be null or empty.");
            }

            var db = this.connection.GetDatabase();

            return await db.StringGetAsync(key);
        }
    }
}
