using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Models;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
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
        public DbSet<User> Users { get; set; }
    }
}
