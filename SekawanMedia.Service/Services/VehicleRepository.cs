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
using static CustomLibrary.Helper.ResponseMessageExtensions;

namespace SekawanMedia.Service.Services
{
	public class VehicleRepository : IVehicleRepository
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IIdentityService _identityService;

		public VehicleRepository(ApplicationDbContext dbContext
			,IIdentityService identityService)
        {
			_dbContext = dbContext;
			_identityService = identityService;
		}
        public async ValueTask<VehicleReadDtos> GetSingleVehiclesAsync(string id)
		{
			var data = await _dbContext.MsVehicles
				.Where(x => x.Id.ToString() == id && x.IsActive == true && x.IsDelete == false)
				.FirstOrDefaultAsync();

			var result = data.Adapt<VehicleReadDtos>();

			return result;
		}

		public async ValueTask<List<VehicleReadDtos>> GetVehiclesAsync()
		{
			var data = await _dbContext.MsVehicles
				.Where(x => x.IsActive == true && x.IsDelete == false)
				.OrderByDescending(x => x.CreatedAt)
				.ToListAsync();

			var result = data.Adapt<List<VehicleReadDtos>>();

			return result;
		}

		public async ValueTask<ResponseBaseViewModel> SubmitVehicleAsync(VehicleWriteDtos vehicleWriteDtos)
		{
			var response = new ResponseBaseViewModel();
			await using var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				var vehicle = new MsVehicle()
				{
					Bpkb = vehicleWriteDtos.Bpkb,
					Colours = vehicleWriteDtos.Colours,
					Description = vehicleWriteDtos.Description,
					HullNumber = vehicleWriteDtos.HullNumber,
					MsUserId = vehicleWriteDtos.MsUserId,
					MsVehicleTypeId = vehicleWriteDtos.MsVehicleTypeId,
					Name = vehicleWriteDtos.Name,
					Nopol = vehicleWriteDtos.Nopol,
					PurchasedAt = vehicleWriteDtos.PurchasedAt,
					PurchasedBy = vehicleWriteDtos.PurchasedBy,
					Stnk = vehicleWriteDtos.Stnk,
					CreatedAt = DateTimeOffset.Now,
					CreatedBy = _identityService.GetUserId(),
					UpdatedAt = DateTimeOffset.Now,
					UpdatedBy = _identityService.GetUserId(),
					IsActive = true,
					IsDelete = false
				};

				await _dbContext.MsVehicles.AddAsync(vehicle);

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

		public async ValueTask<ResponseBaseViewModel> UpdateVehicleAsync(string id, VehicleWriteDtos vehicleWriteDtos)
		{
			var response = new ResponseBaseViewModel();
			await using var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				var data = await _dbContext.MsVehicles
				.Where(x => x.Id.ToString() == id && x.IsActive == true && x.IsDelete == false)
				.FirstOrDefaultAsync();

				data.Bpkb = vehicleWriteDtos.Bpkb;
				data.Stnk = vehicleWriteDtos.Stnk;
				data.Colours = vehicleWriteDtos.Colours;
				data.HullNumber = vehicleWriteDtos.HullNumber;
				data.MsVehicleTypeId = vehicleWriteDtos.MsVehicleTypeId;
				data.Name = vehicleWriteDtos.Name;
				data.Nopol = vehicleWriteDtos.Nopol;
				data.PurchasedAt = vehicleWriteDtos.PurchasedAt;
				data.PurchasedBy = vehicleWriteDtos.PurchasedBy;
				data.Description = vehicleWriteDtos.Description;
				data.UpdatedAt = DateTimeOffset.Now;
				data.UpdatedBy = _identityService.GetUserId();

				_dbContext.MsVehicles.Update(data);

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
