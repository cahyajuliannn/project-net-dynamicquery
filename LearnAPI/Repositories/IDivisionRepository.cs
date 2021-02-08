using LearnAPI.Models;
using LearnAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnAPI.Repositories
{
    public interface IDivisionRepository
    {
        Task<IEnumerable<DivisionVM>> Get();
        Task<DivisionVM> Get(int Id);
        int Create(Division division);
        int Update(int Id, DivisionVM divisionVM);
        int Delete(int Id);
    }
}
