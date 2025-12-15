using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeOps.Domain.Entity
{
    public class Reflection
    {
        public Guid Id { get; private set; }
        public DateOnly Date { get; private set; }
        public int Mood { get; private set; }
        public int EnergyLevel { get; private set; }
        public string Note { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Reflection() { }

        public Reflection(
            DateOnly date,
            int mood,
            int energyLevel,
            string note)
        {
            Id = Guid.NewGuid();
            Date = date;
            Mood = mood;
            EnergyLevel = energyLevel;
            Note = note;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
