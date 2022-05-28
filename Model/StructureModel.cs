using System.Collections.Generic;

namespace arch_sync.Model
{
	public class StructureModel
	{
		public StructureModel()
		{
			ClassFolder = new FolderModel();
			InterfaceFolder = new FolderModel();
			Classes = new List<ClassModel>();
			Interfaces = new List<InterfaceModel>();
			ClassNamespace = new NamespaceModel();
			InterfaceNamespace= new NamespaceModel();
		}
		
		public FolderModel ClassFolder { get;set; }
		
		public FolderModel InterfaceFolder { get;set; }
		
		public List<ClassModel> Classes { get; set; }
		
		public List<InterfaceModel> Interfaces { get; set; }
		
		public NamespaceModel ClassNamespace { get; set; }
		
		public NamespaceModel InterfaceNamespace { get; set; }
		
		public bool ClassSub { get; set; }
		
		public bool InterfaceSub { get; set; }
	}	
}

