using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using arch_sync.Model;

namespace arch_sync.Service.ServiceDependency
{
    public class StartupUpdater
    {
        public void Update(string file, string bn, string marker, List<FileModel> fms)
        {
            var t = File.ReadAllText(file);

            var ns = fms.GroupBy(fm => fm.Namespace).Select(g => g.First().Namespace);

            StringBuilder b = new StringBuilder();

            foreach (var n in ns)
            {
                b.AppendFormat("using {0}.{1};", bn, n);
                b.AppendLine();

                b.AppendFormat("using {0}.{1}.Interface;", bn, n);
                b.AppendLine();
            }

            var i = t.IndexOf(marker);

            if (i == -1)
            {
                Console.WriteLine("Error: No marker " + marker);
                return;
            }

            b.Append(t.Substring(0, i));
            b.AppendLine(marker);

            foreach (var g in fms.GroupBy(f => f.Namespace))
            {
                foreach (var fm in g)
                {
                    b.AppendFormat("services.AddSingleton<{0}, {1}>();", fm.Name, fm.Name.Substring(1));
                    b.AppendLine();
                }
                b.AppendLine();
            }

            b.Append(t.Substring(i + marker.Length));

            File.WriteAllText(file, b.ToString());
        }
    }
}
