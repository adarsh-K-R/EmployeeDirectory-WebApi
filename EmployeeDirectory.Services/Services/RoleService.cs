using EmployeeDirectory.Data.Contracts;
using EmployeeDirectory.Services.Contracts;
using Model = EmployeeDirectory.Models;
using DBModel = EmployeeDirectory.Data.DBModels;
using TinyMapper = Nelibur.ObjectMapper.TinyMapper;

namespace EmployeeDirectory.Services.Services;

public class RoleService: IRoleService 
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork) 
    {
        _roleRepository = roleRepository;
        TinyMapperConfig.ConfigureMappings();
        _unitOfWork = unitOfWork;
    }

    public List<Model.Role> GetAll() 
    {
        return _roleRepository.GetAll();
    }

    public Model.Role Add(Model.Role role) 
    {
        var newRole = _roleRepository.Add(TinyMapper.Map<DBModel.Role>(role));
        _unitOfWork.SaveChanges();
        role.Id = newRole.Id;
        return role;
    }

    public List<Model.Role> GetByDepartmentId(string Id) 
    {
        return _roleRepository.GetByDepartmentId(Id);
    }

    public Model.Role GetByRoleId(string Id)
    {
        return _roleRepository.GetByRoleId(Id);
    }
}