using LifeOps.Application.Interface;
using LifeOps.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeOps.Infrastructure.Persistence
{
    public class InMemoryReflectionRepository : IReflectionRepository
    {
        public static List<Reflection> reflections = new List<Reflection>();

        public IReadOnlyList<Reflection> GetAll()
        {
            return reflections;
        }

        public Reflection? GetById(Guid id)
        {
            return reflections.Where(x => x.Id == id).FirstOrDefault();
        }

        public Reflection? Save(Reflection reflection)
        {
            try
            {
                reflections.Add(reflection);
                return reflection;
            }
            catch
            {
                return null;
            }
        }
    }
}
