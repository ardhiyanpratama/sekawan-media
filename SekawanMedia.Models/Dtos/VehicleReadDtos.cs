using CustomLibrary.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Models.Dtos
{
	public class VehicleReadDtos : EntityBase
	{
		public Guid MsUserId { get; set; }
		public Guid MsVehicleTypeId { get; set; }
		public string? MsVehicleTypeName { get; set; }
		public string? Name { get; set; }
		public string? Nopol { get; set; }
		public string? HullNumber { get; set; }
		public string? Colours { get; set; }
		public string? PurchasedAt { get; set; }
		public string? PurchasedBy { get; set; }
		public string? Stnk { get; set; }
		public string? Bpkb { get; set; }
		public string? Description { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsDelete { get; set; }
	}
}
