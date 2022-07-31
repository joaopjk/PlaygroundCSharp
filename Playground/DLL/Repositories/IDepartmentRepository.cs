using DLL.Context;
using DLL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync();
        Task<Department> GetAsync(int id);
        Task<Department> InsertAsync(Department department);
        Task<Department> UpdateAsync(int id, Department department);
        Task<Department> Delete(int id);
    }

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetAsync(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<Department> InsertAsync(Department department)
        {
            await _context.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateAsync(int id, Department department)
        {
            var departmentExists = await this.GetAsync(id);
            if (department == null)
                return null;

            departmentExists.Name = department.Name;
            departmentExists.Code = department.Code;
            _context.Departments.Update(departmentExists);
            await _context.SaveChangesAsync();
            return departmentExists;
        }

        public async Task<Department> Delete(int id)
        {
            var department = await this.GetAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                return department;
            }
            return null;
        }
    }
}
