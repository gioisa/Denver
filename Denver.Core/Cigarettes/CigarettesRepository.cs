using Denver._Model;
using Denver.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Denver.Core.Repository
{
    public class CigarettesRepository : ICigarettesRepository
    {
        private readonly DataContext _context;

        public CigarettesRepository(DataContext context)
        {
            _context = context;
        }

        public Cigarettes[] GetCigarettes()
        {
            return _context.Cigarettes.ToArray();
        }

        public Cigarettes GetCigarettesById(int id)
        {
            var cigarettes = _context.Cigarettes.SingleOrDefault(c => c.IdCigarettes == id);
            return cigarettes;
        }

        public int UpdateCigarettes(int id, Cigarettes cigarettes)
        {
            int updateSuccess = 0;
            var target = _context.Cigarettes.SingleOrDefault(c => c.IdCigarettes == id);
            if (target != null)
            {
                _context.Entry(target).CurrentValues.SetValues(cigarettes);
                updateSuccess = _context.SaveChanges();
            }
            return updateSuccess;
        }

        public int AddCigarettes(Cigarettes cigarettes)
        {
            int insertSuccess = 0;
            
            _context.Cigarettes.Add(cigarettes);
            insertSuccess = _context.SaveChanges();

            return insertSuccess;

        }

        public int DeleteCigarettes(int id)
        {
            int deleteSuccess = 0;
            var cigarettes = _context.Cigarettes.SingleOrDefault(a => a.IdCigarettes == id);
            if (cigarettes != null)
            {
                _context.Cigarettes.Remove(cigarettes);
                deleteSuccess = _context.SaveChanges();
            }
            return deleteSuccess;
        }


    }
}
