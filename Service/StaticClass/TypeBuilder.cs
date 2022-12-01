using System.IO;
using arch_sync.Model;

namespace arch_sync.Service.StaticClass
{
    public class TypeBuilder
    {
        public void Write(
            AppConfig ac, 
            FileModel fm, 
            string typeName,
            FileType ft, 
            string dt,
            string method)
        {
            //Igla
            var bn = new DirectoryInfo(ac.BaseDirectory).Name;
            var ns = bn + "." + ac.ServiceFolder;

            var type = "";
            
            switch (ft)
            {
                case FileType.Class:
                    type = "class";
                    break;
                // case FileType.Interface:
                //     type = "interface";
                //     break;
            }
            
            dt = dt.Replace("{namespace}", ns)
                   .Replace("{type}", type)
                   .Replace("{typeName}", typeName)
                   .Replace("{method}", method);

            File.WriteAllText(fm.FullName, dt);
        }
    }
}
