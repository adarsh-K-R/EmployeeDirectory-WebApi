namespace EmployeeDirectory.Data.Contracts;

public interface IProjectRepository
{
    List<Models.Project> GetAll ();
}