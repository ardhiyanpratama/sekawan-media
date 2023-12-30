using CustomLibrary.Helper;
using SekawanMedia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Service.Interfaces
{
	public interface IVehicleRepository
	{
		ValueTask<List<VehicleReadDtos>> GetVehiclesAsync();
		ValueTask<VehicleReadDtos> GetSingleVehiclesAsync(string id);
		ValueTask<ResponseBaseViewModel> SubmitVehicleAsync(VehicleWriteDtos vehicleWriteDtos);
		ValueTask<ResponseBaseViewModel> UpdateVehicleAsync(string id, VehicleWriteDtos vehicleWriteDtos);
	}
}
