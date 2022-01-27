using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomiaryGUI
{
    public enum Raport
    {
        hour, day, week, month, year
    }

    public enum ChartMode
    {
        power, current, voltage, cos
    }

    public enum FormStates
    {
        start,
        power, current, voltage, cos, somename,
        hourly, daily, weekly, monthly, annual,
        setequipments, connection, network
    }
}
