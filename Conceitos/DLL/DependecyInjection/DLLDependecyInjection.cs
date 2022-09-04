using DLL.Context;
using DLL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DLL.DependecyInjection
{
  public static class DLLDependecyInjection
  {
    public static void AddDLLDependencies(this IServiceCollection services)
    {
      services.AddDbContext<ApplicationDbContext>(_ => _.UseSqlServer("Server=127.0.0.1,1433;Database=CourseUdemy;user id=SA;Password=Root@123root"));
      services.AddTransient<IDepartmentRepository, DepartmentRepository>();
    }
  }
}
