namespace DiscordBotPanel.Backend.DTO
{
    public class LogStatsDto
    {
        public ulong BotId { get; set; }
        public int GuildsCount { get; set; }
        public int MembersCount { get; set; }
        public int ExecutedCommandsCount { get; set; }
    }
}
