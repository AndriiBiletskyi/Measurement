using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomiaryGUI
{
    public class RaportsParameters
    {
        public FormStates FormState { get; }
        public DateTime DateFrom { get; }
        public DateTime DateTo { get; }

        public RaportsParameters(FormStates formState, DateTime dateFrom, DateTime dateTo)
        {
            FormState = formState;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}
