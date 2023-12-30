using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Data.Domain
{
    public class BookingApproval
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BookingRequestId { get; set; }
        public Guid MsUserId { get; set; }
        public bool? IsApproved { get; set; }
        public DateTimeOffset? ApprovedAt { get; set; }
        public string? ApprovedBy { get; set; }


        public virtual BookingRequest? BookingRequest { get; set; }
        public virtual MsUser? MsUser { get; set; }
    }
}
