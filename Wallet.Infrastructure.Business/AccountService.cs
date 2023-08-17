using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Entities;
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

		public async Task<string> GetPaymentDue()
		{
			return $"You've paid your {new CultureInfo(DateTime.Now.ToString("MMMM")).TextInfo.ToTitleCase} balance";
		}

		public async Task<string> GetDailyPoints(int id)
		{
			var getTodaysDate = DateTime.Now;
			var todaysSeason = GetSeason(getTodaysDate);

			DateTime springStarts = new DateTime(DateTime.Now.Year, 3, 1);
			DateTime summerStarts = new DateTime(DateTime.Now.Year, 8, 10);
			DateTime autumnStarts = new DateTime(DateTime.Now.Year, 9, 1);
			DateTime winterStarts = new DateTime(DateTime.Now.Year, 12, 1);

			TimeSpan daysPassed = new TimeSpan();
			switch (todaysSeason)
			{
				case Season.Spring:
					daysPassed = getTodaysDate - springStarts;
					break;
				case Season.Summer:
					daysPassed = getTodaysDate - summerStarts;
					break;
				case Season.Autumn:
					daysPassed = getTodaysDate - autumnStarts;
					break;
				case Season.Winter:
					daysPassed = getTodaysDate - winterStarts;
					break;
			}

			return CalculatePoints((int)daysPassed.TotalDays, springStarts.Day);
		}

		public async Task<IList<OperationDto>> GetLatestOperation(int id)
		{
			var accountOperations = await _unitOfWork.OperationRepository.GetLatestOperations(id);
			return _mapper.Map<IList<OperationDto>>(accountOperations);
		}

		private static Season GetSeason(DateTime date)
		{
			int month = date.Month;

			if (month >= 3 && month <= 5)
			{
				return Season.Spring;
			}
			else if (month >= 6 && month <= 8)
			{
				return Season.Summer;
			}
			else if (month >= 9 && month <= 11)
			{
				return Season.Autumn;
			}
			else
			{
				return Season.Winter;
			}
		}

		private static string CalculatePoints(int dayNumber, int seasonStartDay, int points = 2)
		{
			if (dayNumber == 1)
			{
				return points.ToString();
			}
			else if (dayNumber == 2)
			{
				return (points + 1).ToString();
			}
			else
			{
				int prevDayPoints = int.Parse(CalculatePoints(dayNumber - 1, seasonStartDay));
				int prevPrevDayPoints = int.Parse(CalculatePoints(dayNumber - 2, seasonStartDay));

				int currentPoints = prevDayPoints + prevPrevDayPoints;

				if (currentPoints > 1000)
				{
					return $"{currentPoints / 1000}K";
				}

				return currentPoints.ToString();
			}
		}
	}
}
