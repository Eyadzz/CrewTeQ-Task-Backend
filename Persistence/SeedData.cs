using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Employee>()
            .HasData(
                new List<Employee>
                {
                    new()
                    {
                        Id = 1,
                        Username = "bob1",
                        FirstName = "Bob",
                        LastName = "Marle"
                    },
                    new()
                    {
                        Id = 2,
                        Username = "alice123",
                        FirstName = "Alice",
                        LastName = "Chris"
                    },
                    new()
                    {
                        Id = 3,
                        Username = "johnsmith221",
                        FirstName = "John",
                        LastName = "Smith"
                    }
                }
            );
    }
}