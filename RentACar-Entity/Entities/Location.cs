using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.Entities
{
	public class Location
	{
		public int Id { get; set; }
		public string City { get; set; }
		public string Region { get; set; }

		public virtual List<Car> Cars { get; set; }
	}
}
