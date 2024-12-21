using System.Drawing;
using System.Runtime.CompilerServices;
using TagCloudDI.WordHandlers;

namespace TagCloudDI
{
    public class CloudCreator
    {
        private DataProvider dataProvider;
        private ICloudLayouter layouter;
        public CloudCreator(DataProvider dataProvider, ICloudLayouter cloudLayouter) 
        {
            this.dataProvider = dataProvider;
            this.layouter = cloudLayouter;
        }
        
        public Rectangle[] CreateTagCloud()
        {
            var words = dataProvider.GetData();
            throw new NotImplementedException();
        }
    }
}