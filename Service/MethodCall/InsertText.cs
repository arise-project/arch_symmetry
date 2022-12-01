using System;
using System.IO;

namespace arch_sync.Service.MethodCall
{
    public class InsertText
    {
        public void Insert(string file, string marker, string snippet)
        {
            var text = File.ReadAllText(file);
            int start = text.IndexOf(marker);
            var beg = text.Substring(0, start);
            var end = text.Substring(start + marker.Length);
            File.WriteAllText(file, beg + snippet + Environment.NewLine + end);
        }
    }
}
