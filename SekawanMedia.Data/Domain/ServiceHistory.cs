using CustomLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Data.Domain
{
    public class ServiceHistory:EntityBase
    {
        public Guid MsVehicleId { get; set; }
        public DateTimeOffset? ServiceAt { get; set; }
        public string? ServiceBy { get; set; }
        public string? ServiceIn { get; set; }
        public string? Description { get; set; }
        public double? TotalServiceFee { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }


        public virtual MsVehicle? MsVehicle { get; set; }
    }
}
