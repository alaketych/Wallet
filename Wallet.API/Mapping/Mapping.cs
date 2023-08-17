using AutoMapper;
using System;
using System.Linq;
using Wallet.Domain.Entities;
using Wallet.Services.Interfaces;
using Wallet.Infrastucture.Data.Dto;
using Wallet.Infrastucture.Data.Dto.Account;
using Wallet.Infrastucture.Data.Dto.Operation;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Wallet.API.Models.Operation.Response;
using Wallet.API.Models.Account.Response;

namespace Wallet.API.Mapping
{
	public class Mapping : Profile
	{
		public Mapping()
		{
			CreateMap<Account, AccountDto>().ReverseMap();
			CreateMap<Operation, OperationDto>().ReverseMap();

			CreateMap<AccountDto, AccountDetailedResponse>().ReverseMap();
			CreateMap<OperationDto, OperationDetailedResponse>().ReverseMap();
		}
	}

}
