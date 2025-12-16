using LifeOps.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeOps.Application.Validator
{
    public static class ReflectionValidator
    {
        public static string Validate(BaseReflectionDTO dto)
        {
            if (dto.Date > DateOnly.FromDateTime(DateTime.UtcNow)) return "Date cannot be more than today.";
            if (dto.Mood < 1 || dto.Mood > 5) return "Mood must be between 1 and 5";
            if (dto.EnergyLevel < 1 || dto.EnergyLevel > 5) return "Energy Level must be between 1 and 5";
            if (string.IsNullOrWhiteSpace(dto.Note)) return "Note cannot be empty.";

            return string.Empty;
        }
    }
}
