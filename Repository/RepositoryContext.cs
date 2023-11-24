using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventReview> EventReviews { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerInterest> PlayerInterests { get; set; }
        public DbSet<PlayersOnEvent> PlayersOnEvents { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<ReactionType> ReactionTypes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        public DbSet<Sport> Sports { get; set; }
    }
}
