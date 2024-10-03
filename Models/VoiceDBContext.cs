using Microsoft.EntityFrameworkCore;

namespace SynthNetVoice.Data.Models
{
    public class VoiceDBContext(DbContextOptions<VoiceDBContext> options) : DbContext(options)
    {
        public DbSet<GameInfo> GameInfo { get; set; } = null!;

    }
}
