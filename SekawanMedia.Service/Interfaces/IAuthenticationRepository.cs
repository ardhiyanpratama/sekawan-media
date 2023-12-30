using CustomLibrary.Helper;
using SekawanMedia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Service.Interfaces
{
	public interface IAuthenticationRepository
	{
		ValueTask<ResponseBaseViewModel> AuthenticationUser(AuthDto authDto);
	}
}
