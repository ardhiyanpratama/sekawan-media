using CustomLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Data.Domain
{
    public class MsVehicleType : EntityBase
    {
        public MsVehicleType()
        {
            MsVehicles = new HashSet<MsVehicle>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }


        public virtual ICollection<MsVehicle> MsVehicles { get; set; }
    }
}
