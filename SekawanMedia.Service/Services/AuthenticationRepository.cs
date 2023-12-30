using CustomLibrary.Helper;
using CustomLibrary.Services;
using Microsoft.EntityFrameworkCore;
using SekawanMedia.Data;
using SekawanMedia.Models.Dtos;
using SekawanMedia.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Service.Services
{
	public class AuthenticationRepository : IAuthenticationRepository
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IIdentityService _identityService;

		public AuthenticationRepository(ApplicationDbContext dbContext
			, IIdentityService identityService)
        {
			_dbContext = dbContext;
			_identityService = identityService;
		}
        public async ValueTask<ResponseBaseViewModel> AuthenticationUser(AuthDto authDto)
		{
			var response = new ResponseBaseViewModel();
			try
			{
				var findId = await _dbContext.MsUsers
						.Include(x => x.MsUserRoles)
						.FirstOrDefaultAsync(x => x.Username == authDto.Username && x.Password == authDto.Password);

				if (findId is null)
				{

					response.IsError = true;
					response.ErrorMessage = "User not found";
					return response;
				}
			}
			catch (Exception ex)
			{
				response.IsError = true;
				response.ErrorMessage = ex.Message;
			}

			return response;
		}
	}
}
