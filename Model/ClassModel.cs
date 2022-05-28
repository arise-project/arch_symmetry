namespace arch_sync.Model
{
	public class ClassModel
	{
		public ClassModel(string name, string baseNamespace, string folder, bool exits, bool empty, InterfaceModel proto)
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
		
		public InterfaceModel Proto { get; set; }
	}	
}
