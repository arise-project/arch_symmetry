using System;
using System.Collections.Generic;
using System.Linq;
using arch_sync.Model.ClassInterface;

namespace arch_sync.Service.ClassInterface
{
    public class StructureBuilder
    {
        public void Build(AppConfig ac, StructureModel sm, List<ClassModel> cms, List<InterfaceModel> ims)
        {
            Console.WriteLine();
            var ec = cms.Where(c => c.Empty);
            var nc = cms.Where(c => !c.Exists);
            Console.WriteLine("build classes " + nc.Count() + ec.Count());

            foreach (var c in nc)
            {
                new ClassWritter().Write(ac, sm.ClassNamespace, c, c.Proto);
            }

            foreach (var c in ec)
            {
                new ClassWritter().Write(ac, sm.ClassNamespace, c, c.Proto);
            }

            var ei = ims.Where(i => i.Empty);
            var ni = ims.Where(i => !i.Exists);
            Console.WriteLine("build interfalces " + ni.Count());

            foreach (var i in ni)
            {
                new InterfaceWritter().Write(ac, sm.InterfaceNamespace, i, i.Proto);
            }

            foreach (var i in ei)
            {
                new InterfaceWritter().Write(ac, sm.InterfaceNamespace, i, i.Proto);
            }
        }
    }
}
