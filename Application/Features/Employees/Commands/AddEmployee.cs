using System.ComponentModel.DataAnnotations;
using Application.Features.Employees.Dtos;

namespace Application.Features.Employees.Commands;

public record AddEmployee : IRequest<BaseResponse>
{
    [MinLength(1)]
    public required string FirstName { get; set; }
    [MinLength(1)]
    public required string LastName { get; set; }
    [MinLength(1)]
    public required string Username { get; set; }
}

public class AddEmployeeHandler : IRequestHandler<AddEmployee, BaseResponse>
{
    private readonly ApplicationDbContext _dbContext;

    public AddEmployeeHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<BaseResponse> Handle(AddEmployee request, CancellationToken cancellationToken)
    {
        var usernameExists = _dbContext.Employees.Any(e => e.Username == request.Username);
        if (usernameExists)
        {
            return Responses.AlreadyExist("Username");
        }
        
        var employee = new Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Username = request.Username
        };
        
        await _dbContext.Employees.AddAsync(employee, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Responses.Success();
    }
}