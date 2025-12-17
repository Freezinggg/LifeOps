using LifeOps.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeOps.Application.Interface
{
    public interface IReflectionRepository
    {
        Reflection? GetById(Guid id);
        IReadOnlyList<Reflection> GetAll();
        Reflection? Save(Reflection reflection);
        bool Update(Reflection reflection);
        bool Delete(Guid id);
    }
}
