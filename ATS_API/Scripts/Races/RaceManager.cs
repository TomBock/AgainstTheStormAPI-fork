using System.Collections.Generic;
using ATS_API.Helpers;

namespace ATS_API.Scripts.Races;

public static partial class RaceManager
{
    public static IReadOnlyList <CustomRace> NewRaces => new List <CustomRace>();
    
    private static Dictionary<RaceTypes, CustomRace> s_newRaces = new Dictionary<RaceTypes, CustomRace>();
}
