using RentACar_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.ViewModels
{
    public class ModelViewModel
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FuelType { get; set; }
        public string GearBoxType { get; set; }
        public int VecihleTypeId { get; set; }

    }
}
