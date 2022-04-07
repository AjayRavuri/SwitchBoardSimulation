using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchBoardSimulation
{
    public class Button
    {
        public int applianceId;
        public bool state;
        public Button(int id)
        {
            this.applianceId = id;
        }
    }
}
