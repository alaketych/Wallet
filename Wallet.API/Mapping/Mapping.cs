using AutoMapper;
using System;
using System.Linq;
using Wallet.Domain.Entities;
using Wallet.Services.Interfaces;
using Wallet.Infrastucture.Data.Dto;
using Wallet.Infrastucture.Data.Dto.Account;
using Wallet.Infrastucture.Data.Dto.Operation;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Wallet.API.Mapping
{
	public class Mapping : Profile
	{
		public Mapping()
		{
			CreateMap<Account, AccountDto>().ReverseMap();
			CreateMap<Operation, OperationDto>().ReverseMap();
		}
	}

}
