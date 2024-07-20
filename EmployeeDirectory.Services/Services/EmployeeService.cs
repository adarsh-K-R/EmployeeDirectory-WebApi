using EmployeeDirectory.Data.Contracts;
using EmployeeDirectory.Services.Contracts;
using Model = EmployeeDirectory.Models;
using DBModel = EmployeeDirectory.Data.DBModels;
using TinyMapper = Nelibur.ObjectMapper.TinyMapper;

namespace EmployeeDirectory.Services.Services;

public class EmployeeService: IEmployeeService 
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork) 
    {
        _employeeRepository = employeeRepository;
        TinyMapperConfig.ConfigureMappings();
        _unitOfWork = unitOfWork;
    }

    public List<Model.Employee> GetAll() 
    {
        return _employeeRepository.GetAll();
    }

    public DBModel.Employee Add(Model.Employee employee) 
    {
        var dbEmployee = _employeeRepository.Add(TinyMapper.Map<DBModel.Employee>(employee));
        _unitOfWork.SaveChanges();
        return dbEmployee;
    }

    public Model.Employee? GetByEmpNo(string empNo) 
    {
        return _employeeRepository.GetByEmpNo(empNo);
    }

    public bool Delete(string empNo) 
    {
        bool res;
        Model.Employee employee = _employeeRepository.GetByEmpNo(empNo)!;
        if(employee != null)
        {
            res = _employeeRepository.Delete(empNo);
            _unitOfWork.SaveChanges();
        }
        else
        {
            res = false;
        }

        return res;
    }

    public bool Update(Model.Employee employee) 
    {
       var emp = _employeeRepository.Update(TinyMapper.Map<DBModel.Employee>(employee));
       _unitOfWork.SaveChanges();
       return emp;
    }
}