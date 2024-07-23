using RentACar_Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.ViewModels
{
    public class CarFilterViewModel
    {
        public List<int>? VehicleTypeId { get; set; }
        public int? PickupLocationId { get; set; }
        public int? ReturnLocationId { get; set; }

        [Required(ErrorMessage = "Tarih alanı boş geçilemez.")]
        [DataType(DataType.Date)]
        public DateTime PickupDate { get; set; }
        [Required(ErrorMessage = "Tarih alanı boş geçilemez.")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
        public List<Car> Cars { get; set; } = new List<Car>();
        public virtual Model Model { get; set; }
    }
}
