using System;
using System.Collections.Generic;
using System.Linq;
using arch_sync.Model.ClassInterface;
using arch_sync.Model;

namespace arch_sync.Service.InterfaceClass
{
    public class FolderMerger
    {
        public List<InterfaceModel> Merge(StructureModel sm, List<InterfaceModel> ims, List<ClassModel> cms)
        {
            var ce = cms.Where(c => !ims.Any(i => string.Equals(c.Name, i.Name.Substring(1))));
            if (ce.Count() > 0)
            {
                Console.WriteLine();
                Console.WriteLine("interfaces:");
                foreach (var i in ims)
                {
                    Console.WriteLine(i.Name);
                }

                Console.WriteLine();
                Console.WriteLine("new iterfaces:");
                foreach (var c in ce)
                {
                    Console.WriteLine("I" + c.Name);
                }
            }
            return ims.Union(ce.Select(c => new InterfaceModel(c.Name, sm.InterfaceNamespace.Name, "", false, false, c))).ToList();
        }

        public List<ClassModel> Merge(StructureModel sm, List<ClassModel> cms, List<InterfaceModel> ims)
        {
            var ie = ims.Where(i => !cms.Any(c => string.Equals(i.Name.Substring(1), c.Name)));
            if (ie.Count() > 0)
            {
                Console.WriteLine();
                Console.WriteLine("classes:");
                foreach (var c in cms)
                {
                    Console.WriteLine(c.Name);
                }

                Console.WriteLine();
                Console.WriteLine("new classes:");
                foreach (var i in ie)
                {
                    Console.WriteLine(i.Name.TrimStart('I'));
                }
            }
            return cms.Union(ie.Select(i => new ClassModel(i.Name.Substring(1), sm.ClassNamespace.Name, "", false, false, i))).ToList();
        }
    }
}
