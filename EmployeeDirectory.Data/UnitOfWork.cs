using EmployeeDirectory.Data.Contracts;
using EmployeeDirectory.Data.Repositories;

namespace EmployeeDirectory.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly EmployeeDbContext _employeeDbContext;
    public UnitOfWork(EmployeeDbContext employeeDbContext)
    {
        _employeeDbContext = employeeDbContext;
    }

    public int SaveChanges()
    {
        return _employeeDbContext.SaveChanges();
    }
}