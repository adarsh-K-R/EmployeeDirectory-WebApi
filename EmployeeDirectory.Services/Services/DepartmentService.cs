using EmployeeDirectory.Data.Contracts;
using EmployeeDirectory.Services.Contracts;

namespace EmployeeDirectory.Services.Services;

public class DepartmentService : IDepartmentService 
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository) 
    {
        _departmentRepository = departmentRepository;
    }
    
    public List<Models.Department> GetAll() 
    {
        return _departmentRepository.GetAll();
    }
}