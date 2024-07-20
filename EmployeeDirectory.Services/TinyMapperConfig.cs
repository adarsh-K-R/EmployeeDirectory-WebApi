using Model = EmployeeDirectory.Models;
using DBModel = EmployeeDirectory.Data.DBModels;
using Nelibur.ObjectMapper;

namespace EmployeeDirectory.Services;

public static class TinyMapperConfig
{
    public static void ConfigureMappings()
    {
        TinyMapper.Bind<Model.Employee, DBModel.Employee>(config =>
        {
            config.Bind(source => source.Role.Id, target => target.RoleId);
            config.Bind(source => source.Department.Id, target => target.DepartmentId);
            config.Bind(source => source.Project.Id, target => target.ProjectId);            
        });

        TinyMapper.Bind<Model.Role, DBModel.Role>(config =>
        {
            config.Bind(source => source.Department.Id, target => target.DepartmentId);
        });
    }
}