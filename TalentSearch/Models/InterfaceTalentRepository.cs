using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentSearch.Models
{
    interface InterfaceTalentRepository
    {
        IEnumerable<Talent> GetAll();
        Talent Get(int id);
        Talent Add(Talent item);
        void Remove(int id);
        bool Update(Talent item);
    }
}
