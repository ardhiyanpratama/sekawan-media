using CustomLibrary.Helper;
using CustomLibrary.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;
using SekawanMedia.Data;
using SekawanMedia.Data.Domain;
using SekawanMedia.Models.Dtos;
using SekawanMedia.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Service.Services
{
	public class VehicleTypeRepository : IVehicleTypeRepository
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IIdentityService _identityService;

		public VehicleTypeRepository(ApplicationDbContext dbContext
			, IIdentityService identityService)
        {
			_dbContext = dbContext;
			_identityService = identityService;
		}
        public async ValueTask<VehicleTypeReadDtos> GetSingleVehiclesTypeAsync(string id)
		{
			var data = await _dbContext.MsVehicleTypes
				.Where(x => x.Id.ToString() == id && x.IsActive == true && x.IsDelete == false)
				.FirstOrDefaultAsync();

			var result = data.Adapt<VehicleTypeReadDtos>();

			return result;
		}

		public async ValueTask<List<VehicleTypeReadDtos>> GetVehiclesTypeAsync()
		{
			var data = await _dbContext.MsVehicleTypes
				.Where(x => x.IsActive == true && x.IsDelete == false)
				.OrderByDescending(x => x.CreatedAt)
				.ToListAsync();

			var result = data.Adapt<List<VehicleTypeReadDtos>>();

			return result;
		}

		public async ValueTask<ResponseBaseViewModel> SubmitVehicleTypeAsync(VehicleTypeWriteDtos vehicleTypeWriteDtos)
		{
			var response = new ResponseBaseViewModel();
			await using var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				var vehicle = new MsVehicleType()
				{
					Code = vehicleTypeWriteDtos.Code,
					Name = vehicleTypeWriteDtos.Name,
					CreatedAt = DateTimeOffset.Now,
					CreatedBy = _identityService.GetUserId(),
					UpdatedAt = DateTimeOffset.Now,
					UpdatedBy = _identityService.GetUserId(),
					IsActive = true,
					IsDelete = false
				};

				await _dbContext.MsVehicleTypes.AddAsync(vehicle);

				transaction.Commit();
				await _dbContext.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				response.IsError = true;
				response.ErrorMessage = ex.Message;
			}

			return response;
		}

		public async ValueTask<ResponseBaseViewModel> UpdateVehicleTypeAsync(string id, VehicleTypeWriteDtos vehicleTypeWriteDtos)
		{
			var response = new ResponseBaseViewModel();
			await using var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				var data = await _dbContext.MsVehicleTypes
				.Where(x => x.Id.ToString() == id && x.IsActive == true && x.IsDelete == false)
				.FirstOrDefaultAsync();

				data.Code = vehicleTypeWriteDtos.Code;
				data.Name = vehicleTypeWriteDtos.Name;
				data.UpdatedAt = DateTimeOffset.Now;
				data.UpdatedBy = _identityService.GetUserId();

				_dbContext.MsVehicleTypes.Update(data);

				transaction.Commit();
				await _dbContext.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				response.IsError = true;
				response.ErrorMessage = ex.Message;
			}

			return response;
		}
	}
}
