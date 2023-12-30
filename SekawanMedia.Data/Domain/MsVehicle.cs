using CustomLibrary.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Data.Domain
{
    public class MsVehicle : EntityBase
    {
        public MsVehicle()
        {
            ServiceHistories = new HashSet<ServiceHistory>();
            BookingRequests = new HashSet<BookingRequest>();
        }

        public Guid MsUserId { get; set; }
        public Guid MsVehicleTypeId { get; set; }
        public string? Name { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Nopol { get; set; }
        [Column(TypeName = "varchar(7)")]
        public string? HullNumber { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Colours { get; set; }
        public string? PurchasedAt { get; set; }
        public string? PurchasedBy { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Stnk { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Bpkb { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }


        public virtual MsUser? MsUser { get; set; }
        public virtual MsVehicleType? MsVehicleType { get; set; }
        public virtual ICollection<ServiceHistory> ServiceHistories { get; set; }
        public virtual ICollection<BookingRequest> BookingRequests { get; set; }
    }
}
