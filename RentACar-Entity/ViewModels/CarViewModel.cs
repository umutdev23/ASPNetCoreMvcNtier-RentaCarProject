using RentACar_Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int? LocationId { get; set; }
        public int VehicleTypeId { get; set; }
        public string GearBoxType { get; set; }

        public virtual Model Model { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
    }
}
