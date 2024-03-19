using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BattleBuddy.Services.Messaging
{
    public class DtoFactory
    {
        public List<ArmyListEntryDto> CreateArmyListEntry(string rawString, string origin)
        {
            var entries = JsonConvert.DeserializeObject<List<ArmyListEntryDto>>(rawString) ?? new();

            entries.ForEach(entry => { entry.Origin = origin; });

            return entries;
        }
    }

    public class ArmyListEntryDto
    {
        public Guid Uid { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Origin { get; set; } = string.Empty;
    }
}
