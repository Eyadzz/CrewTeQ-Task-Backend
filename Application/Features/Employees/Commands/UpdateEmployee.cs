using System.ComponentModel.DataAnnotations;

namespace Application.Features.Employees.Commands;

public record UpdateEmployee : IRequest<BaseResponse>
{
    [Range(1, int.MaxValue, ErrorMessage = "Role ID must be greater than 0")]
    public required int Id { get; set; }
    [MinLength(1)]
    public required string FirstName { get; set; }
    [MinLength(1)]
    public required string LastName { get; set; }
    [MinLength(1)]
    public required string Username { get; set; }
    public required bool IsActive { get; set; }
}

public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployee, BaseResponse>
{
    private readonly ApplicationDbContext _dbContext;

    public UpdateEmployeeHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<BaseResponse> Handle(UpdateEmployee request, CancellationToken cancellationToken)
    {
        var employee = await _dbContext.Employees.FindAsync(request.Id);
        if (employee == null)
        {
            return Responses.NotFound("Employee");
        }
        
        var usernameExists = _dbContext.Employees.Any(e => e.Username == request.Username && e.Id != request.Id);
        if (usernameExists)
        {
            return Responses.AlreadyExist("Username");
        }
        
        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.Username = request.Username;
        employee.IsActive = request.IsActive;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Responses.Success();
    }
}