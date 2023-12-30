using CustomLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Models.Dtos
{
	public class BookingRequestReadDtos : EntityBase
	{
		public Guid MsVehicleId { get; set; }
		public string? VehicleName { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public string? Driver { get; set; }
		public string? RequestedBy { get; set; }
		public DateTimeOffset? RequestedAt { get; set; }
		public string? BbmConsumption { get; set; }
		public StatusEnum? Status { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsDelete { get; set; }
	}
}
