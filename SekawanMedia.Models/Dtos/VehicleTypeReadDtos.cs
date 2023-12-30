using CustomLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Models.Dtos
{
	public class VehicleTypeReadDtos : EntityBase
	{
		public string Name { get; set; }
		public string Code { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsDelete { get; set; }
	}
}
