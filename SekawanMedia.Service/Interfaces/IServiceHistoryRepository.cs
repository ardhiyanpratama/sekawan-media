using CustomLibrary.Helper;
using SekawanMedia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Service.Interfaces
{
	public interface IServiceHistoryRepository
	{
		ValueTask<List<ServiceHistoryReadDtos>> GetServiceHistorysAsync();
		ValueTask<ServiceHistoryReadDtos> GetSingleHistoryAsync(string id);
		ValueTask<ResponseBaseViewModel> SubmitHistoryAsync(ServiceHistoryWriteDtos serviceHistoryWriteDtos);
		ValueTask<ResponseBaseViewModel> UpdateHistoryAsync(string id, ServiceHistoryWriteDtos serviceHistoryWriteDtos);
	}
}
