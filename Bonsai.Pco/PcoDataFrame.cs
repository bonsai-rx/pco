using OpenCV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Pco
{
    public struct PcoDataFrame
    {
        public int Counter;
        public DateTimeOffset Timestamp;
        public IplImage Image;
    }
}
