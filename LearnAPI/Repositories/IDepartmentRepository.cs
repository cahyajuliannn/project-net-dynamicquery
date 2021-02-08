using LearnAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnAPI.Repositories
{
    public interface IDepartmentRepository //Penampung balikan sebuah data
    {
        Task<IEnumerable<Department>> Get();
        Task<Department> Get(int Id);
        int Create(Department department);
        int Update(int Id, Department department);
        int Delete(int Id);
    }
}
