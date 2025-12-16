using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeOps.Domain.Entity
{
    public class Reflection
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public int Mood { get; set; } //1-5, LOW to HIGH
        public int EnergyLevel { get; set; } //1-5, LOW to HIGH
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }

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
