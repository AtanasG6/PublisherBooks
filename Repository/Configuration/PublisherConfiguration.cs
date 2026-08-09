using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder) =>
        builder.HasData(
            new Publisher
            {
                Id = new Guid("8c76b8a8-f748-4eed-b13b-5ce2ba50ce18"),
                Name = "Northwind Press",
                City = "Manchester",
                Country = "United Kingdom"
            },
            new Publisher
            {
                Id = new Guid("c67499e0-0041-4ee3-98b1-b2fdf6834885"),
                Name = "Silverleaf Publishing",
                City = "Toronto",
                Country = "Canada"
            },
            new Publisher
            {
                Id = new Guid("2dddc208-8925-41c4-80ec-bb58ee833dc7"),
                Name = "Aurora Books",
                City = "Melbourne",
                Country = "Australia"
            });
}
