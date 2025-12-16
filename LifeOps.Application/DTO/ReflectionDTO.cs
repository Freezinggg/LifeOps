using LifeOps.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeOps.Application.DTO
{
    public class ReflectionDTO : BaseReflectionDTO
    {
        public Guid Id { get; set; }

        private ReflectionDTO() { }
        public ReflectionDTO(Reflection x)
        {
            Id = x.Id;
            Date = x.Date;
            Mood = x.Mood;
            EnergyLevel = x.EnergyLevel;
            Note = x.Note;
        }
    }
}
