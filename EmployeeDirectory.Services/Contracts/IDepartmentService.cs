namespace EmployeeDirectory.Services.Contracts;

public interface IDepartmentService
{
    public List<Models.Department> GetAll();
}