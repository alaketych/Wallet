using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wallet.API.Models;
using Wallet.API.Models.Account.Response;
using Wallet.Infrastucture.Data.Dto.Account;
using Wallet.Services.Interfaces;

namespace Wallet.API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpGet("{id}")]
		public async Task<DtoResponse<AccountDetailedResponse>> GetAccount(int id)
		{
			var account = await _accountService.GetByIdAsync(id);
			var response = new DtoResponse<AccountDetailedResponse>()
			{
				Result = new AccountDetailedResponse()
				{
					PaymentDue = await _accountService.GetPaymentDue(),
					DailyPoints = await _accountService.GetDailyPoints(account.Id),
					Operations = await _accountService.GetLatestOperation(account.Id)
				}
			};

			return response;
		}
	}
}
