using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Infrastucture.Data;
using Wallet.Infrastucture.Data.Dto;
using Wallet.Infrastucture.Data.Dto.Operation;
using Wallet.Services.Interfaces;

namespace Wallet.Infrastructure.Business
{
	public class OperationService : IOperationService
	{
		private readonly IOptions<PageSettings> _pageSettings;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public OperationService(
			IUnitOfWork unitOfWork, 
			IMapper mapper,
			IOptions<PageSettings> pageSettings) 
		{
			_pageSettings = pageSettings;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IList<OperationDto>> GetAllAsync(FilterDto filter)
		{
			if (filter.PageNumber < 0)
			{
				filter.PageNumber = _pageSettings.Value.PageNumber;
			}

			int pageNumber = (filter.PageNumber - 1) * _pageSettings.Value.PageSize;
			var operations = await _unitOfWork.OperationRepository.GetAllAsync(pageNumber, filter.PageSize);

			return _mapper.Map<IList<OperationDto>>(operations);
		}

		public async Task<OperationDto> GetByIdAsync(int id)
		{ 
			var operation = await _unitOfWork.OperationRepository.GetIdAsync(id);
			return _mapper.Map<OperationDto>(operation);
		}

		public async Task<IList<OperationDto>> GetLatestAccountOperations(int id)
		{
			var operations = await _unitOfWork.OperationRepository.GetLatestOperations(id);
			return _mapper.Map<IList<OperationDto>>(operations);
		}
	}
}
