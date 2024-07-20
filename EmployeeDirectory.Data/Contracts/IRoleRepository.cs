using DBModel = EmployeeDirectory.Data.DBModels;
using Model = EmployeeDirectory.Models;

namespace EmployeeDirectory.Data.Contracts;

public interface IRoleRepository 
{
    List<Model.Role> GetAll();
    DBModel.Role Add(DBModel.Role role);
    List<Model.Role> GetByDepartmentId(string Id);

    Model.Role GetByRoleId(string Id);
}

