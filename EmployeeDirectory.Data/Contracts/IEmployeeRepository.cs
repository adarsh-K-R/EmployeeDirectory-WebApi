using DBModel = EmployeeDirectory.Data.DBModels;
using Model = EmployeeDirectory.Models;

namespace EmployeeDirectory.Data.Contracts;

public interface IEmployeeRepository 
{
    List<Model.Employee> GetAll();
    DBModel.Employee Add(DBModel.Employee employee);
    Model.Employee? GetByEmpNo(string empNo);
    bool Delete(string empNo);
    bool Update(DBModel.Employee employee);
}