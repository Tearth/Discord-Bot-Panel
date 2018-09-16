using System;
using System.Collections.Generic;
using System.Text;
using DiscordBotPanel.Backend.DAL;
using Microsoft.EntityFrameworkCore;

namespace DiscordBotPanel.Backend.Tests.Helpers
{
    public static class DatabaseFactory
    {
        public static DatabaseContext Create()
        {
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            return new DatabaseContext(builder.Options);
        }
    }
}
