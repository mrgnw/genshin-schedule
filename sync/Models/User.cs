using System;
using GenshinSchedule.SyncServer.Database;
using Newtonsoft.Json;

namespace GenshinSchedule.SyncServer.Models
{
    public class User
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("createdTime")]
        public DateTime CreatedTime { get; set; }

        public static User FromDbModel(DbUser user) => new User
        {
            Username    = user.Username,
            CreatedTime = user.CreatedTime
        };
    }
}