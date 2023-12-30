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
	public class ServiceHistoryRepository : IServiceHistoryRepository
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IIdentityService _identityService;

		public ServiceHistoryRepository(ApplicationDbContext dbContext
			, IIdentityService identityService)
        {
			_dbContext = dbContext;
			_identityService = identityService;
		}
        public async ValueTask<List<ServiceHistoryReadDtos>> GetServiceHistorysAsync()
		{
			var data = await _dbContext.ServiceHistories
				.Where(x => x.IsActive == true && x.IsDelete == false)
				.OrderByDescending(x => x.CreatedAt)
				.ToListAsync();

			var result = data.Adapt<List<ServiceHistoryReadDtos>>();

			return result;
		}

		public async ValueTask<ServiceHistoryReadDtos> GetSingleHistoryAsync(string id)
		{
			var data = await _dbContext.ServiceHistories
				.Where(x => x.Id.ToString() == id && x.IsActive == true && x.IsDelete == false)
				.FirstOrDefaultAsync();

			var result = data.Adapt<ServiceHistoryReadDtos>();

			return result;
		}

		public async ValueTask<ResponseBaseViewModel> SubmitHistoryAsync(ServiceHistoryWriteDtos serviceHistoryWriteDtos)
		{
			var response = new ResponseBaseViewModel();
			await using var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				var service = new ServiceHistory()
				{
					Description = serviceHistoryWriteDtos.Description,
					MsVehicleId = serviceHistoryWriteDtos.MsVehicleId,
					ServiceAt = serviceHistoryWriteDtos.ServiceAt,
					ServiceBy = serviceHistoryWriteDtos.ServiceBy,
					ServiceIn = serviceHistoryWriteDtos.ServiceIn,
					TotalServiceFee = serviceHistoryWriteDtos.TotalServiceFee,
					CreatedAt = DateTimeOffset.Now,
					CreatedBy = _identityService.GetUserId(),
					UpdatedAt = DateTimeOffset.Now,
					UpdatedBy = _identityService.GetUserId(),
					IsActive = true,
					IsDelete = false
				};

				await _dbContext.ServiceHistories.AddAsync(service);

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

		public async ValueTask<ResponseBaseViewModel> UpdateHistoryAsync(string id, ServiceHistoryWriteDtos serviceHistoryWriteDtos)
		{
			var response = new ResponseBaseViewModel();
			await using var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				var data = await _dbContext.ServiceHistories
				.Where(x => x.Id.ToString() == id && x.IsActive == true && x.IsDelete == false)
				.FirstOrDefaultAsync();

				data.Description = serviceHistoryWriteDtos.Description;
				data.TotalServiceFee = serviceHistoryWriteDtos.TotalServiceFee;
				data.ServiceAt = serviceHistoryWriteDtos.ServiceAt;
				data.ServiceBy = serviceHistoryWriteDtos.ServiceBy;
				data.ServiceIn = serviceHistoryWriteDtos.ServiceIn;
				data.MsVehicleId = serviceHistoryWriteDtos.MsVehicleId;
				data.UpdatedAt = DateTimeOffset.Now;
				data.UpdatedBy = _identityService.GetUserId();

				_dbContext.ServiceHistories.Update(data);

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
