using CustomLibrary.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Models.Dtos
{
	public class BookingRequestWriteDtos
	{
		public Guid MsVehicleId { get; set; }
		[Required]
		public string? Title { get; set; }
		public string? Description { get; set; }
		[Required]
		public string? Driver { get; set; }
		public string? RequestedBy { get; set; }
		public DateTimeOffset? RequestedAt { get; set; }
	}
}
