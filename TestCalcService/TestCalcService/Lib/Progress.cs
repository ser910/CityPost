using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalcService
{
    public class ProgressItem
    {
        public string Title { get; set; }
        public double CurWeight { get; set; }
        public KeyValuePair<double, double> Item { get; set; }
    }
}
