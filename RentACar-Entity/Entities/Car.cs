using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.Entities
{
	public class Car
	{
		public int Id { get; set; }
		public int ModelId { get; set; }
        public decimal Price { get; set; }
		public string PictureUrl { get; set; }
		public int? LocationId { get; set; }
        




        //Relation
        public virtual Model Model { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

	}
}
