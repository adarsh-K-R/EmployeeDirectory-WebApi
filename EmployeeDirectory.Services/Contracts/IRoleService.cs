using Model = EmployeeDirectory.Models;
using DBModel = EmployeeDirectory.Data.DBModels;

namespace EmployeeDirectory.Services.Contracts;

public interface IRoleService 
{
    List<Model.Role> GetAll();
    Model.Role Add(Model.Role role);
    List<Model.Role> GetByDepartmentId(string Id);

    Model.Role GetByRoleId(string Id);
}