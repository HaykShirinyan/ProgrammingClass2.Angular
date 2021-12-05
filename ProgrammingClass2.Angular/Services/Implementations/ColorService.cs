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
    public class ColorService : IColorService
    {
        private readonly IMapper _mapper;
        private readonly IColorRepository _colorRepository;

        public ColorService(IMapper mapper, IColorRepository colorRepository)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;
        }

        public async Task<List<ColorDto>> GetAllAsync()
        {
            var modelList = await _colorRepository.GetAllAsync();
            var dtoList = _mapper.Map<List<ColorDto>>(modelList);

            return dtoList;
        }

        public async Task<ColorDto> GetAsync(int id)
        {
            var model = await _colorRepository.GetAsync(id);

            if (model != null)
            {
                return _mapper.Map<ColorDto>(model);
            }

            return null;
        }

        public async Task<ColorDto> CreateAsync(ColorDto dto)
        {
            var model = _mapper.Map<UnitOfMeasure>(dto);
            var created = await _colorRepository.CreateAsync(model);

            if (created != null)
            {
                return _mapper.Map<ColorDto>(created);
            }

            return null;
        }

        public async Task<ColorDto> UpdateAsync(ColorDto dto)
        {
            var model = _mapper.Map<Color>(dto);
            var updated = await _colorRepository.UpdateAsync(model);

            if (updated != null)
            {
                return _mapper.Map<ColorDto>(updated);
            }

            return null;
        }

        public async Task<ColorDto> DeleteAsync(int id)
        {
            var deleted = await _colorRepository.DeleteAsync(id);

            if (deleted != null)
            {
                return _mapper.Map<ColorDto>(deleted);
            }

            return null;
        }
    }
}
