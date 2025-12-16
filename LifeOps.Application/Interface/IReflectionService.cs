using LifeOps.Application.Common;
using LifeOps.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeOps.Application.Interface
{
    public interface IReflectionService
    {
        Result<ReflectionDTO?> GetById(Guid id);
        Result<IReadOnlyList<ReflectionDTO>> GetAll();
        Result<Guid> Save(CreateReflectionDTO dto);
    }
}
