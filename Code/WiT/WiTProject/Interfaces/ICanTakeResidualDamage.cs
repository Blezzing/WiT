using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiTProject
{
    interface ICanTakeResidualDamage
    {
        void CheckForResidualDamage();
        void TakeResidualDamage(int amountOfDamage);
    }
}
