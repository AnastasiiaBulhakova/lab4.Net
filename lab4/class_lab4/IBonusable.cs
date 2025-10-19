using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.class_lab4
{
    public interface IBonusable
    {
        void CalculateBonus();
        double Bonus { get; }
    }
}
