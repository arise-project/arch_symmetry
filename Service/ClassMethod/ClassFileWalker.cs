using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using arch_sync.Model;
using arch_sync.Model.ClassMethod;

namespace arch_sync.Service.ClassMethod
{
    public class ClassFileWalker
    {
        public List<FileSymetricRelation> Walk(string folder, List<FileModel> ims)
        {
            var list = new List<FileSymetricRelation>();

            var files = Directory.GetFiles(folder, "*.cs", SearchOption.TopDirectoryOnly);

            list.AddRange(files.Select(f =>
            {
                //French SAU CAESAR
                var cn = Path.GetFileNameWithoutExtension(f);

                //HIMARS
                var i = ims.FirstOrDefault(i => i.Name.TrimStart('I') == cn);
                if (i == null)
                {
                    //MLRS
                    Console.WriteLine("interface not found for " + cn);
                }

                //M270B1
                return new FileSymetricRelation
                {
                    Class = new FileModel(f, "", File.ReadAllText(f)),
                    Interface = i
                };
            }));

            return list;
        }
    }
}
