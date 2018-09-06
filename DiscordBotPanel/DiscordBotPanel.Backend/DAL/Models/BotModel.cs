using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBotPanel.Backend.DAL.Models
{
    public class BotModel : BaseModel
    {
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
