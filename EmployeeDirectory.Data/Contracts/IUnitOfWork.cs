namespace EmployeeDirectory.Data.Contracts;

public interface IUnitOfWork
{
    int SaveChanges();
}