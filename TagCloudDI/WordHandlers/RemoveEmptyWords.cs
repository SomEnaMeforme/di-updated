using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagCloudDI.Data;

namespace TagCloudDI.WordHandlers
{
    internal class RemoveEmptyWords : IWordFilter
    {
        public bool Accept(WordInfo word)
        {
            return word.InitialForm != "" || word.InitialForm != null;
        }
    }
}
