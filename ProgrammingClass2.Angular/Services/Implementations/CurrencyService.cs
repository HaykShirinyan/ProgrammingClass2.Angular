using AutoMapper;
using ProgrammingClass2.Angular.DataTransferObjects;
using ProgrammingClass2.Angular.Models;
using ProgrammingClass2.Angular.Repositories.Definitions;
using ProgrammingClass2.Angular.Services.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Services.Implementations
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(IMapper mapper, ICurrencyRepository currencyRepository)
        {
            _mapper = mapper;
            _currencyRepository = currencyRepository;
        }

        public async Task<List<CurrencyDto>> GetAllAsync()
        {
            var modelList = await _currencyRepository.GetAllAsync();
            var dtoList = _mapper.Map<List<CurrencyDto>>(modelList);

            return dtoList;
        }

        public async Task<CurrencyDto> GetAsync(int id)
        {
            var model = await _currencyRepository.GetAsync(id);

            if (model != null)
            {
                return _mapper.Map<CurrencyDto>(model);
            }

            return null;
        }

        public async Task<CurrencyDto> CreateAsync(CurrencyDto dto)
        {
            var model = _mapper.Map<Currency>(dto);
            var created = await _currencyRepository.CreateAsync(model);

            if (created != null)
            {
                return _mapper.Map<CurrencyDto>(created);
            }

            return null;
        }

        public async Task<CurrencyDto> UpdateAsync(CurrencyDto dto)
        {
            var model = _mapper.Map<Currency>(dto);
            var updated = await _currencyRepository.UpdateAsync(model);

            if (updated != null)
            {
                return _mapper.Map<CurrencyDto>(updated);
            }

            return null;
        }

        public async Task<CurrencyDto> DeleteAsync(int id)
        {
            var deleted = await _currencyRepository.DeleteAsync(id);

            if (deleted != null)
            {
                return _mapper.Map<CurrencyDto>(deleted);
            }

            return null;
        }
    }
}
