using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloudDI.WordHandlers
{
    internal class LowerCaseTransformer : IWordTransformer
    {
        public string Apply(string word)
        {
            return word.ToLower();
        }
    }
}
