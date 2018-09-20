using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBotPanel.Backend.DTO
{
    public class RequestResultDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public RequestResultDTO()
        {

        }

        public RequestResultDTO(bool success, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}
