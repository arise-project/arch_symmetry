namespace arch_sync.Model.ClassInterface
{
    public class InterfaceModel
    {
        public InterfaceModel(string name, string baseNamespace, string folder, bool exits, bool empty, ClassModel proto)
        {
            Name = name;
            Namespace = baseNamespace + "." + folder;
            Exists = exits;
            Empty = empty;
            Proto = proto;
        }

        public string Name { get; set; }

        public string Namespace { get; set; }

        public bool Exists { get; set; }

        public bool Empty { get; set; }

        public ClassModel Proto { get; set; }
    }
}
