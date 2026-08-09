using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder) =>
        builder.HasData(
            new Book
            {
                Id = new Guid("2343c3e6-a2db-4b5c-87af-e7e0605d816a"),
                Title = "The Quiet Harbour",
                PageCount = 312,
                Genre = "Literary fiction",
                ReleaseYear = 2018,
                PublisherId = new Guid("8c76b8a8-f748-4eed-b13b-5ce2ba50ce18")
            },
            new Book
            {
                Id = new Guid("f9d3ab49-d925-4e8c-b380-7c60b444b94a"),
                Title = "Patterns of the North",
                PageCount = 448,
                Genre = "History",
                ReleaseYear = 2021,
                PublisherId = new Guid("8c76b8a8-f748-4eed-b13b-5ce2ba50ce18")
            },
            new Book
            {
                Id = new Guid("66fdae8f-eb22-487a-8def-a138928f205b"),
                Title = "Winter Lantern",
                PageCount = 264,
                Genre = "Mystery",
                ReleaseYear = 2019,
                PublisherId = new Guid("c67499e0-0041-4ee3-98b1-b2fdf6834885")
            },
            new Book
            {
                Id = new Guid("1e0ef065-7153-4555-b23d-242e27bc4cbf"),
                Title = "Concrete and Rain",
                PageCount = 190,
                Genre = "Poetry",
                ReleaseYear = 2023,
                PublisherId = new Guid("c67499e0-0041-4ee3-98b1-b2fdf6834885")
            },
            new Book
            {
                Id = new Guid("800dfb90-d562-4595-9878-6ff361456cd0"),
                Title = "The Cartographer's Debt",
                PageCount = 526,
                Genre = "Historical fiction",
                ReleaseYear = 2020,
                PublisherId = new Guid("2dddc208-8925-41c4-80ec-bb58ee833dc7")
            },
            new Book
            {
                Id = new Guid("b0d5912d-d356-4dd9-b783-a95625c8a528"),
                Title = "Southern Reef",
                PageCount = 358,
                Genre = "Science",
                ReleaseYear = 2022,
                PublisherId = new Guid("2dddc208-8925-41c4-80ec-bb58ee833dc7")
            });
}
