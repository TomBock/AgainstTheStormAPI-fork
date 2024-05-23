using System.Collections.Generic;
using System.Linq;
using Eremite;
using Eremite.Model;

namespace ATS_API.Helpers;

public enum NeedTypes
{
    Unknown = -1,
    None,
    All,
    Any_Housing,
    Beaver_Housing,
    Fox_Housing,
    Harpy_Housing,
    Human_Housing,
    Lizard_Housing,
    Jerky,
    Porridge,
    Skewer,
    Biscuits,
    Pie,
    Pickled_Goods,
    Clothes,
    Leasiure,
    Bloodthirst,
    Religion,
    Education,
    Luxury,
    Treatment,
}

public static class NeedTypeExtensions
{
    internal static readonly Dictionary<NeedTypes, string> TypeToInternalName = new Dictionary<NeedTypes, string>()
    {
        { NeedTypes.Any_Housing, "Any Housing" },
        { NeedTypes.Beaver_Housing, "Beaver Housing" },
        { NeedTypes.Fox_Housing, "Fox Housing" },
        { NeedTypes.Harpy_Housing, "Harpy Housing" },
        { NeedTypes.Human_Housing, "Human Housing" },
        { NeedTypes.Lizard_Housing, "Lizard Housing" },
        { NeedTypes.Jerky, "Jerky" },
        { NeedTypes.Porridge, "Porridge" },
        { NeedTypes.Skewer, "Skewer" },
        { NeedTypes.Biscuits, "Biscuits" },
        { NeedTypes.Pie, "Pie" },
        { NeedTypes.Pickled_Goods, "Pickled Goods" },
        { NeedTypes.Clothes, "Clothes" },
        { NeedTypes.Leasiure, "Leasiure" },
        { NeedTypes.Bloodthirst, "Bloodthirst" },
        { NeedTypes.Religion, "Religion" },
        { NeedTypes.Education, "Education" },
        { NeedTypes.Luxury, "Luxury" },
        { NeedTypes.Treatment, "Treatment" },
    };
    public static string ToName(this NeedTypes type)
    {
        if (TypeToInternalName.TryGetValue(type, out var name))
        {
            return name;
        }

        Plugin.Log.LogError($"Cannot find name of need type: " + type);
        return NeedTypes.Any_Housing.ToName();
    }

    public static NeedModel ToModel(this NeedTypes type)
    {
        return SO.Settings.Needs.FirstOrDefault(need => need.Name == type.ToName());
    }
}
