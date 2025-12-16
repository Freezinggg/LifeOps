using LifeOps.Application.Common;
using LifeOps.Application.DTO;
using LifeOps.Application.Interface;
using LifeOps.Application.Validator;
using LifeOps.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace LifeOps.Application.Service
{
    public class ReflectionService : IReflectionService
    {
        IReflectionRepository _repo;
        public ReflectionService(IReflectionRepository repo)
        {
            _repo = repo;
        }

        public Result<IReadOnlyList<ReflectionDTO>> GetAll()
        {
            IReadOnlyList<ReflectionDTO> reflectionList = _repo.GetAll().Select(x => new ReflectionDTO(x)).ToList();

            return Result<IReadOnlyList<ReflectionDTO>>.Success(reflectionList);
        }

        public Result<ReflectionDTO?> GetById(Guid id)
        {
            Reflection? reflection = _repo.GetById(id);
            if (reflection == null) return Result<ReflectionDTO?>.NotFound("Reflection doesnt exist.");

            ReflectionDTO dto = new ReflectionDTO(reflection);
            return Result<ReflectionDTO?>.Success(dto);

        }

        public Result<Guid> Save(CreateReflectionDTO dto)
        {
            try
            {
                string validateResult = ReflectionValidator.Validate(dto);
                if (!string.IsNullOrEmpty(validateResult)) return Result<Guid>.Fail(validateResult);

                Reflection reflection = new(dto.Date, dto.Mood, dto.EnergyLevel, dto.Note);
                if (_repo.Save(reflection) == null) return Result<Guid>.Fail("Save Reflection fail");

                return Result<Guid>.Success(reflection.Id);
            }
            catch
            {
                return Result<Guid>.Error("Save Reflection error");
            }
        }
    }
}
