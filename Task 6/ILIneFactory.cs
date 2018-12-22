using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    public interface ILIneFactory
    {
        ILine Create(MyPoint p1, MyPoint p2, List<MyPoint> points);
    }
}
