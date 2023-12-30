using CustomLibrary.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Models.Dtos
{
	public class VehicleTypeWriteDtos
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Code { get; set; }
	}
}
