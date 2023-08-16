using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wallet.API.Models;
using Wallet.Infrastucture.Data.Dto.Account;
using Wallet.Services.Interfaces;

namespace Wallet.API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;
		private readonly IOperationService _operationService;
		private readonly IMapper _mapper;

		public AccountController(
			IAccountService accountService,
			IOperationService operationService,
			IMapper mapper)
		{
			_accountService = accountService;
			_operationService = operationService;
			_mapper = mapper;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAccount(int id)
		{
			var account = await _accountService.GetByIdAsync(id);
			if (account != null)
			{
				return Ok(account);
			}

			var latestAccountOperations = await _operationService.GetLatestAccountOperations(account.Id);
			if (latestAccountOperations != null)
			{
				return Ok(latestAccountOperations);
			}

			return NotFound();
		}
	}
}
