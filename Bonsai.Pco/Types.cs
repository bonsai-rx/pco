using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Pco
{
    public enum TriggerMode : ushort
    {
        AutoTrigger = 0,
        SoftwareTrigger = 1,
        ExternalTrigger = 2,
        ExposureControl = 3
    }
}
