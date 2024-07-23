using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.Entities
{
	public class Rent
	{
		public int Id { get; set; }
		public int ReservationId { get; set; }
		public int Discount { get; set; }
		public DateTime RentDate { get; set; }

		//Relation
		public virtual Reservation Reservation { get; set; }
	}
}
