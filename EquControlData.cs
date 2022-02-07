using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomiaryGUI
{
    public class EquControlData
    {
        public List<int> eqNumbers = new List<int>();
        public Dictionary<int, (string name, float minValue, float maxValue, EquipmentType type, bool state)> eqParameters = new Dictionary<int, (string name, float minValue, float maxValue, EquipmentType type, bool state)>();
        public Dictionary<int, Dictionary<string, float>> eqData = new Dictionary<int, Dictionary<string, float>>();
    }
}
