using System.IO;
using arch_sync.Model;

namespace arch_sync.Service.StaticClass
{
    public class MethodBuilder
    {
        public string Gen(string rec)
        {
            var s =  rec.Split(',');
            if(rec.Length == 2)
            {
                return s[1];
            }

            return s[1] + "_to_" + s[2];
        }
    }
}
