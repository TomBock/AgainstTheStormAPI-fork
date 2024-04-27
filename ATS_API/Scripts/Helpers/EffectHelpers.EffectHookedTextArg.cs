using Eremite.Model.Effects;
using Eremite.Model.Effects.Hooked;
using TextArgType = Eremite.Model.Effects.Hooked.TextArgType;

namespace ATS_API.Helpers;

public static class EffectHookedTextArg_Extensions
{
    public static HookedTextArg[] ToHookedTextArgArray(this (SourceType source, TextArgType type)[] args)
    {
        HookedTextArg[] hookedTextArgs = new HookedTextArg[args.Length];
        for (int i = 0; i < args.Length; i++)
        {
            hookedTextArgs[i] = new HookedTextArg()
            {
                source = args[i].source,
                sourceIndex = 0,
                type = args[i].type,
            };
        }

        return hookedTextArgs;
    }
    
    public static HookedStateTextArg[] ToHookedStateTextArgArray(this HookedStateTextArg.HookedStateTextSource[] args)
    {
        HookedStateTextArg[] hookedStateTextArgs = new HookedStateTextArg[args.Length];
        for (int i = 0; i < args.Length; i++)
        {
            hookedStateTextArgs[i] = new HookedStateTextArg()
            {
                source = args[i],
                sourceIndex = i,
            };
        }

        return hookedStateTextArgs;
    }
}