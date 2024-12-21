using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization.CloudLayouter
{
    public interface ICloudLayouter
    {
        public Rectangle PutNextRectangle(Size nextRectangle);
    }
}
