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
    public class UnitOfMeasureService : IUnitOfMeasureService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;

        public UnitOfMeasureService(IMapper mapper, IUnitOfMeasureRepository unitOfMeasureRepository)
        {
            _mapper = mapper;
            _unitOfMeasureRepository = unitOfMeasureRepository;
        }

        public async Task<List<UnitOfMeasureDto>> GetAllAsync()
        {
            var modelList = await _unitOfMeasureRepository.GetAllAsync();
            var dtoList = _mapper.Map<List<UnitOfMeasureDto>>(modelList);

            return dtoList;
        }

        public async Task<UnitOfMeasureDto> GetAsync(int id)
        {
            var model = await _unitOfMeasureRepository.GetAsync(id);

            if (model != null)
            {
                return _mapper.Map<UnitOfMeasureDto>(model);
            }

            return null;
        }

        public async Task<UnitOfMeasureDto> CreateAsync(UnitOfMeasureDto dto)
        {
            var model = _mapper.Map<UnitOfMeasure>(dto);
            var created = await _unitOfMeasureRepository.CreateAsync(model);

            if (created != null)
            {
                return _mapper.Map<UnitOfMeasureDto>(created);
            }

            return null;
        }

        public async Task<UnitOfMeasureDto> UpdateAsync(UnitOfMeasureDto dto)
        {
            var model = _mapper.Map<UnitOfMeasure>(dto);
            var updated = await _unitOfMeasureRepository.UpdateAsync(model);

            if (updated != null)
            {
                return _mapper.Map<UnitOfMeasureDto>(updated);
            }

            return null;
        }

        public async Task<UnitOfMeasureDto> DeleteAsync(int id)
        {
            var deleted = await _unitOfMeasureRepository.DeleteAsync(id);

            if (deleted != null)
            {
                return _mapper.Map<UnitOfMeasureDto>(deleted);
            }

            return null;
        }
    }
}
