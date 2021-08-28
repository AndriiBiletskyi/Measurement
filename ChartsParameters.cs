using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomiaryGUI
{
     public class ChartsParameters
    {
        public string EquName { get; }
        public DateTime DateFrom { get; }
        public DateTime DateTo { get; }
        public List<string> Lines { get; }

        public ChartsParameters(string equName, DateTime dateFrom,DateTime dateTo, List<string> lines)
        {
            EquName = equName;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Lines = lines;
        }
    }
}
