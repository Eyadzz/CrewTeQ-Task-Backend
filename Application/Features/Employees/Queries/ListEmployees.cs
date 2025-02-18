using Application.Features.Employees.Dtos;
using Mapster;

namespace Application.Features.Employees.Queries;

public record ListEmployees : IRequest<BaseResponse>
{
    public int PageSize { get; set; }
    public int LastId { get; set; }
}

public class ListEmployeesHandler : IRequestHandler<ListEmployees, BaseResponse>
{
    private readonly ApplicationDbContext _dbContext;

    public ListEmployeesHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<BaseResponse> Handle(ListEmployees request, CancellationToken cancellationToken)
    {
       var employees = await _dbContext.Employees
           .OrderBy(e => e.Id)
           .Where(e => e.Id > request.LastId)
           .Take(request.PageSize)
           .ProjectToType<EmployeeDto>()
           .ToListAsync(cancellationToken);
       
         return Responses.Success(employees);
    }
}
