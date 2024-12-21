using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagCloudDI.WordHandlers;

namespace TagCloudDI
{
    public class DataProvider
    {
        private IDataSource source;
        private IEnumerable<IWordTransformer> preprocessors;
        private IEnumerable<IWordFilter> filters;
        public DataProvider(IDataSource dataSource, IEnumerable<IWordTransformer> preprocessors, IEnumerable<IWordFilter> filters) 
        {
            this.preprocessors = preprocessors;
            this.filters = filters;
            source = dataSource;
        }
        private string[] ReadData(IDataSource dataSource)
        {
            return source.Read();
        }

        private IWordParameters[] PreprocessData()
        {
            throw new NotImplementedException();
        }

        public IWordParameters[] GetData()
        {
            throw new NotImplementedException();
        }
    }
}
