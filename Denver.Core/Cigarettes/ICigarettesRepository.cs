using Denver._Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Denver.Core.Repository
{
    public interface ICigarettesRepository
    {
        Cigarettes[] GetCigarettes();
        int AddCigarettes(Cigarettes cigarettes);
        int DeleteCigarettes(int id);
        Cigarettes GetCigarettesById(int id);
        int UpdateCigarettes(int id, Cigarettes cigarettes);
    }
}
