using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.Entities
{
	public class Model
	{
		public int Id { get; set; }
		public int BrandId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string FuelType { get; set; }
		public string GearBoxType { get; set; }
		public int VehicleTypeId { get; set; }

		//Rel
		public virtual Brand Brand { get; set; }
		public virtual VehicleType VehicleType {get ; set; }
	}
}
