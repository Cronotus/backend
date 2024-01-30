
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository
{
    public class SportConfiguration : IEntityTypeConfiguration<Sport>
    {
        public void Configure(EntityTypeBuilder<Sport> builder)
        {
            builder.HasData
                (
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "Football",
                    },
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "Basketball",
                    },
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "Cricket",
                    },
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "Volleyball",
                    },
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "Rugby",
                    },
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "American Football",
                    },
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "Baseball",
                    },
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "Ice Hockey",
                    },
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "Field Hockey",
                    },
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "Handball",
                    },
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "Water Polo",
                    },
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "Softball",
                    },
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "Frisbee",
                    },
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "Lacrosse",
                    },
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "Tennis",
                    },
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "Table Tennis",
                    },
                    new Sport
                    {
                        Id = Guid.NewGuid(),
                        Name = "Badminton",
                    }
                );
        }
    }
}
