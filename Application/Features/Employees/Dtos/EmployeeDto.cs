namespace Application.Features.Employees.Dtos;

public record EmployeeDto
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Username { get; set; }
    public bool IsActive { get; set; }
}