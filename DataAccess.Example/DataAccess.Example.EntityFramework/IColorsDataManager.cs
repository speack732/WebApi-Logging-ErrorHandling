using DataAccess.Example.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Example.EntityFramework
{
    public interface IColorsDataManager
    {
        void Insert(Color color);


        void Update(Color color);


        Color Get(int id);


        IList<Color> GetAll();

        void Delete(int id);
    }
}
