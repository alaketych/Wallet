﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wallet.API.Models;
using Wallet.API.Models.Operation.Response;
using Wallet.Infrastructure.Business;
using Wallet.Services.Interfaces;

namespace Wallet.API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class OperationController : ControllerBase
	{
		private readonly IOperationService _operationService;

		public OperationController(IOperationService operationService)
		{
			_operationService = operationService;
		}

		[HttpGet("{id}")]
		public async Task<DtoResponse<OperationDetailedResponse>> GetOperation(int id)
		{
			var operation = await _operationService.GetByIdAsync(id);
			var response = new DtoResponse<OperationDetailedResponse>()
			{
				Result = new OperationDetailedResponse()
				{
					Id = operation.Id,
					AccountId = operation.Id,
					Type = operation.Type,
					Name = operation.Name,
					Description = operation.Description,
					DateTimeOffset = operation.DateTimeOffset,
					Pending = operation.Pending,
					Status = operation.Pending ? "Not Approved" : "Approved",
					Total = operation.Total,
					Icon = operation.Icon,
				}
			};

			return response;
		}
	}
}
