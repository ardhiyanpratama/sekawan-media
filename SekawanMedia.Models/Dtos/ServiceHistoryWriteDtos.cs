using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Models.Dtos
{
	public class ServiceHistoryWriteDtos
	{
		public Guid MsVehicleId { get; set; }
		public DateTimeOffset? ServiceAt { get; set; }
		[Required]
		public string? ServiceBy { get; set; }
		[Required]
		public string? ServiceIn { get; set; }
		public string? Description { get; set; }
		[Required]
		public double? TotalServiceFee { get; set; }
	}
}
