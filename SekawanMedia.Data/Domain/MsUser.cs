using CustomLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Data.Domain
{
    public class MsUser : EntityBase
    {
        public MsUser()
        {
            MsVehicles = new HashSet<MsVehicle>();
            BookingApprovals = new HashSet<BookingApproval>();
        }
        public Guid MsUserRolesId { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? IdCardNumber { get; set; }
        public string? Address { get; set; }
        public string? PlaceOfBirth { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public string? Sex { get; set; }
        public string? MaritalStatus { get; set; }
        public string? ProfilePicture { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Nationality { get; set; }
        public string? Email { get; set; }
        public DateTimeOffset? JoinedAt { get; set; }
        public DateTimeOffset? LastLogin { get; set; }


        public virtual MsUserRoles? MsUserRoles { get; set; }
        public virtual ICollection<MsVehicle> MsVehicles { get; set; }
        public virtual ICollection<BookingApproval> BookingApprovals { get; set; }
    }
}
