using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wallet.Infrastructure.Business;
using Wallet.Services.Interfaces;

namespace Wallet.API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class OperationController : ControllerBase
	{
		private readonly IOperationService _operationService;
		private readonly IMapper _mapper;

		public OperationController(
			IOperationService operationService,
			IMapper mapper)
		{
			_operationService = operationService;
			_mapper = mapper;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetOperation(int id)
		{
			var operation = await _operationService.GetByIdAsync(id);
			if (operation != null)
			{
				return Ok(operation);
			}

			return NotFound();
		}
	}
}
