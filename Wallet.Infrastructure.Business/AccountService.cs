using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Infrastucture.Data;
using Wallet.Infrastucture.Data.Dto;
using Wallet.Infrastucture.Data.Dto.Account;
using Wallet.Infrastucture.Data.Dto.Operation;
using Wallet.Services.Interfaces;

namespace Wallet.Infrastructure.Business
{
	public class AccountService : IAccountService
	{
		private readonly IOptions<PageSettings> _pageSettings;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public AccountService(
			IUnitOfWork unitOfWork,
			IMapper mapper,
			IOptions<PageSettings> pageSettings)
		{
			_pageSettings = pageSettings;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IList<AccountDto>> GetAllAsync(FilterDto filter)
		{
			if (filter.PageNumber < 0)
			{
				filter.PageNumber = _pageSettings.Value.PageNumber;
			}

			int pageNumber = (filter.PageNumber - 1) * _pageSettings.Value.PageSize;
			var accounts = await _unitOfWork.AccountRepository.GetAllAsync(pageNumber, filter.PageSize);

			return _mapper.Map<IList<AccountDto>>(accounts);
		}

		public async Task<AccountDto> GetByIdAsync(int id)
		{
			var account = await _unitOfWork.AccountRepository.GetIdAsync(id);
			return _mapper.Map<AccountDto>(account);
		}

		public async Task<short> GetDailyPoints(int id)
		{
			//TODO: make an logic for calculating daily points.

			return 1;
		}
	}
}
