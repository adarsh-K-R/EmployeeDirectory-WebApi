using Model = EmployeeDirectory.Models;
using DBModel = EmployeeDirectory.Data.DBModels;

namespace EmployeeDirectory.Services.Contracts;

public interface IEmployeeService 
{
    List<Model.Employee> GetAll();
    DBModel.Employee Add(Model.Employee employee);
    Model.Employee? GetByEmpNo(string empNo);
    bool Delete(string empNo);
    bool Update(Model.Employee employee);
}
