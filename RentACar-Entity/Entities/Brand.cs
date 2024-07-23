using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.Entities
{
	public class Brand
	{
		public int Id { get; set; }
		public string Name { get; set; }

		//Relation
		public virtual List<Model> Models { get; set; }
	}
}
