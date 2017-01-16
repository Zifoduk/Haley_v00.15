using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haley
{
    class Haley_Looks
    {        
        public static void Expess(string E)
        {
            if (E == Expression.Active.ToString())
                Haley_Sight.LooksUpdate(Haley.Properties.Resources.HaleyActive);
            if (E == Expression.Awake.ToString())
                Haley_Sight.LooksUpdate(Haley.Properties.Resources.HaleyAwake);
            if (E == Expression.Sleep.ToString())
                Haley_Sight.LooksUpdate(Haley.Properties.Resources.HaleySleep);
        }
    }

    enum Expression
    {
        Sleep,
        Awake,
        Active
    }

}
