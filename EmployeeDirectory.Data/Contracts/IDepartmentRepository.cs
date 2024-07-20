namespace EmployeeDirectory.Data.Contracts;

public interface IDepartmentRepository
{
    List<Models.Department> GetAll ();
}