using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TT.EMS.Domain.Employee;

namespace TT.EMS.Infrastructure.Persistence.Repositories;

internal sealed class EmployeeRepository(ApplicationDbContext Context) : IEmployeeRepository
{
    public void DeleteRange(IEnumerable<Guid> employees) =>
        Context.Employees.RemoveRange(Context.Employees.Where(e => employees.Contains(e.Id)));

    public async Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await Context.Employees.FindAsync([id], cancellationToken: cancellationToken);

    public async Task<IReadOnlyCollection<Employee>> GetListAsync(CancellationToken cancellationToken) =>
        await Context.Employees
            .ToListAsync(cancellationToken);

    public void Insert(Employee employee) =>
        Context.Employees.Add(employee);

    public void Update(Employee employee) =>
        Context.Employees.Update(employee);

    public async Task<IReadOnlyCollection<Employee>> GetByFilterAsync(Expression<Func<Employee, bool>> filter, CancellationToken cancellationToken) =>
        await Context.Employees
                .Where(filter)
                .ToListAsync(cancellationToken);
}