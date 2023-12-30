using CustomLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Models.Dtos
{
	public class BookingApprovalReadDtos
	{
		public Guid Id { get; set; }
		public Guid BookingRequestId { get; set; }
		public string? BookingRequestTitle { get; set; }
		public Guid MsUserId { get; set; }
		public bool? IsApproved { get; set; }
		public DateTimeOffset? ApprovedAt { get; set; }
		public string? ApprovedBy { get; set; }
	}
}
