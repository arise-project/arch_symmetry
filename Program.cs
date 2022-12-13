using arch_sync.Unit;

namespace arch_sync
{
    class Program
    {
        static void Main(string[] args)
        {
            //BV5500Plus
            //new ClassInterfaceUnit().Execute();

            //PC30
            //new ClassMethodUnit().Execute();

            //Patriot
            //new ClassStubUnit().Execute();

            //new IntrfaceClass().Execute();

            //new ServiceDependencyUnit().Execute();

            //THeMIS
            //new UnitBuilderUnit().Execute();
            
            new StaticClassUnit().Execute();

            //new MethodCallUnit().Execute();
            
            //
            //new SnippetUnit().Execute();

            //new ServicesSetupUnit().Execute();
        }
    }
}
