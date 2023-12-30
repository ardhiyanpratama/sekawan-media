using CustomLibrary.Helper;
using SekawanMedia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Service.Interfaces
{
	public interface IVehicleTypeRepository
	{
		ValueTask<List<VehicleTypeReadDtos>> GetVehiclesTypeAsync();
		ValueTask<VehicleTypeReadDtos> GetSingleVehiclesTypeAsync(string id);
		ValueTask<ResponseBaseViewModel> SubmitVehicleTypeAsync(VehicleTypeWriteDtos vehicleTypeWriteDtos);
		ValueTask<ResponseBaseViewModel> UpdateVehicleTypeAsync(string id, VehicleTypeWriteDtos vehicleTypeWriteDtos);
	}
}
