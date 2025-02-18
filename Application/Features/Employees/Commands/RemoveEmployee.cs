namespace Application.Features.Employees.Commands;

public record RemoveEmployee : IRequest<BaseResponse>
{
    public int Id { get; set; }
}

public class RemoveEmployeeHandler : IRequestHandler<RemoveEmployee, BaseResponse>
{
    private readonly ApplicationDbContext _dbContext;

    public RemoveEmployeeHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<BaseResponse> Handle(RemoveEmployee request, CancellationToken cancellationToken)
    {
        var employee = await _dbContext.Employees.FindAsync(request.Id, cancellationToken);
        if (employee == null)
        {
            return Responses.NotFound("Employee");
        }
        
        _dbContext.Employees.Remove(employee);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Responses.Success();
    }
}

