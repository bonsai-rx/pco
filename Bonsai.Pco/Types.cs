using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Pco
{
    public enum AcquireMode : ushort
    {
        Auto = 0,
        External = 1,
        ExternalModulate = 2
    }

    public enum TriggerMode : ushort
    {
        AutoTrigger = 0,
        SoftwareTrigger = 1,
        ExternalTrigger = 2,
        ExposureControl = 3
    }

    public enum TimestampMode : ushort
    {
        None = 0,
        Binary = 1,
        BinaryAscii = 2,
        Ascii = 3
    }
}
