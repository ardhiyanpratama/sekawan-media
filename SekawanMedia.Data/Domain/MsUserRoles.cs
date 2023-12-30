using CustomLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Data.Domain
{
    public class MsUserRoles:EntityBase
    {
        public MsUserRoles()
        {
            MsUsers = new HashSet<MsUser>();
        }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }


        public virtual ICollection<MsUser> MsUsers { get; set; }
    }
}
