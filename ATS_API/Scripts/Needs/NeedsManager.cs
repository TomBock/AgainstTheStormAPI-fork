using System.Collections.Generic;
using System.Collections.ObjectModel;
using ATS_API.Goods;
using ATS_API.Helpers;
using ATS_API.Relics;
using ATS_API.Traders;
using Eremite;
using Eremite.Model;
using UnityEngine;

namespace ATS_API.Scripts.Needs;

public static class NeedsManager
{
    public static IReadOnlyList<NewNeed> NewNeeds => new ReadOnlyCollection<NewNeed>(s_newNeeds);

    private static List<NewNeed> s_newNeeds = new List<NewNeed>();
    
    private static bool s_instantiated = false;
    private static bool s_dirty = false;
    
    private static ArraySync<NeedModel, NewNeed> s_needs = new("New Needs");

    public static NewNeed New(string guid, string name)
    {
        NeedModel model = ScriptableObject.CreateInstance <NeedModel>();
        model.order = 6;
        model.presentation = null;
        model.category = null;
        model.effect = null;
        model.canBeProhibited = true;
        model.requiresInstitution = false;
        model.referenceGood = null;             // Optional
        model.equalProhibitionPenalty = null;   // Optional
        model.unfairProhibitionPenalty = null;  // Optional

        return Add(guid, name, model);
    }

    private static NewNeed Add(string guid, string name, NeedModel model)
    {
        model.name = guid + "_" + name;

        NeedTypes id = GUIDManager.Get <NeedTypes>(guid, name);
        NewNeed newNeed = new NewNeed()
        {
            model = model,
            id = id,
        };
        s_newNeeds.Add(newNeed);
        NeedTypesExtensions.TypeToInternalName.Add(id, model.name);
        s_dirty = true;
        
        return newNeed;
    }
    
    internal static void Instantiate()
    {
        s_instantiated = true;
        s_dirty = true;
        SyncNeeds();
    }
    
    
    public static void Tick()
    {
        if(s_dirty)
        {
            s_dirty = false;
            SyncNeeds();
        }
    }

    private static void SyncNeeds()
    {
        if (!s_instantiated)
        {
            return;
        }

        Plugin.Log.LogInfo("NeedsManager.Sync: " + s_newNeeds.Count + " new goods");

        
        Settings settings = SO.Settings;
        _ = s_needs.Sync(ref settings.Needs, s_newNeeds, a => a.model);
    }
}
