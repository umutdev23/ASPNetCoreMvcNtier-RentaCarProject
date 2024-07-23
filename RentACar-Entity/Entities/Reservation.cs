using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.Entities
{
	public class Reservation
	{
		public int Id { get; set; }
		public int CarId { get; set; }
		public int? CustomerUserId { get; set; }	//şimdilik boş olabilir
		public DateTime StartDay { get; set; }
		public DateTime EndDay { get; set; } 
		public string? Description { get; set; }    //şimdilik boş olabilir
        public int LocationId { get; set; }
		public decimal TotalPrice { get; set; }

		//Relation
		public virtual Car Car { get; set; }
        [ForeignKey("CustomerUserId")]
        public virtual CustomerUser CustomerUser { get; set; }
		public virtual Location Location { get; set; }
	}
}
