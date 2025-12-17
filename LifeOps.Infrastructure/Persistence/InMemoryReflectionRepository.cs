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

        public bool Update(Reflection reflection)
        {
            Reflection exist = reflections.Where(x => x.Id == reflection.Id).FirstOrDefault();

            exist.Date = reflection.Date;
            exist.Note = reflection.Note;
            exist.EnergyLevel = reflection.EnergyLevel;
            exist.Mood = reflection.Mood;

            return true;
        }

        public bool Delete(Guid id)
        {
            Reflection refl = reflections.FirstOrDefault(x => x.Id == id);
            reflections.Remove(refl);

            return true;
        }
    }
}
