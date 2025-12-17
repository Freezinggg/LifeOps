using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeOps.Application.DTO
{
    public class BaseReflectionDTO
    {
        public Guid? Id { get; set; }
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public int Mood { get; set; }
        public int EnergyLevel { get; set; }
        public string Note { get; set; }
    }
}
