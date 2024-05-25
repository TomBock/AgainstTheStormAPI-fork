using System.Collections.Generic;
using System.Linq;
using ATS_API.Helpers;
using Eremite;
using Eremite.Model;

namespace ATS_API.Scripts.Needs;

public enum NeedCategoryTypes
{
     Unknown = -1,
     None,
     Housing_Need_Category,		// HousePresentationModel
     Food_Need_Category,		// GoodPresentationModel
     Clothing_Need_Category,	// GoodPresentationModel
     Services_Need_Category		// GoodPresentationModel
}


public static class NeedCategoryTypesExtensions
{
	public static string ToName(this NeedCategoryTypes type)
	{
		if (TypeToInternalName.TryGetValue(type, out var name))
		{
			return name;
		}

		Plugin.Log.LogError($"Cannot find name of NeedTypes: " + type);
		return TypeToInternalName[NeedCategoryTypes.Housing_Need_Category];
	}
	
	public static NeedCategoryModel ToNeedCategoryModel(this string name)
    {
        NeedCategoryModel model = SO.Settings.Needs.FirstOrDefault(a=>a.category.name == name)?.category;
        if (model != null)
        {
            return model;
        }
    
        Plugin.Log.LogError("Cannot find NeedCategoryModel for NeedTypes with name: " + name);
        return null;
    }

	public static NeedCategoryModel ToNeedModel(this NeedTypes types)
	{
		return types.ToName().ToNeedCategoryModel();
	}
	
	public static NeedCategoryModel[] ToNeedModelArray(this IEnumerable<NeedCategoryTypes> collection)
    {
        int count = collection.Count();
        NeedCategoryModel[] array = new NeedCategoryModel[count];
        int i = 0;
        foreach (NeedCategoryTypes element in collection)
        {
            array[i++] = element.ToName().ToNeedCategoryModel();
        }

        return array;
    }

	internal static readonly Dictionary<NeedCategoryTypes, string> TypeToInternalName = new()
	{
		{ NeedCategoryTypes.Housing_Need_Category, "Housing Need Category" },
		{ NeedCategoryTypes.Food_Need_Category, "Food Need Category" },
		{ NeedCategoryTypes.Clothing_Need_Category, "Clothing Need Category" },
		{ NeedCategoryTypes.Services_Need_Category, "Services Need Category" },
	};
}