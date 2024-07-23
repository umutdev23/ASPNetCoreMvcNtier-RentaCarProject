using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.Entities
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Model> Models { get; set; }
    }
}
