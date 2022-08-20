using System.Linq;
using System.Collections.Generic;

namespace arch_sync.Service.ClassMethod
{
    public class SignatureExtractor
    {
        public List<string> Extract(List<string> list)
        {
            //M777=blue
            //CEASAR=green
            //MLRS=yellow

            return list
            .Where(l => !string.IsNullOrWhiteSpace(l) && l.Contains("(") && l.Contains(")"))
            .ToList();
        }
    }
}
