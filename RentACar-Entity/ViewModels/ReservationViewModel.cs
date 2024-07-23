using RentACar_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.ViewModels
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int? CustomerId { get; set; }    
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public string? Description { get; set; }    //şimdilik boş olabilir
        public int LocationId { get; set; }
        public decimal TotalPrice { get; set; }

        //Relation
        public virtual Car Car { get; set; }
        public virtual CustomerUser CustomerUser { get; set; }
        public virtual Location Location { get; set; }
    }
}
