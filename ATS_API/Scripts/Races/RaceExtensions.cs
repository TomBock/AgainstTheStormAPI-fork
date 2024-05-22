using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace ATS_API.Scripts.Races;

public static class RaceExtensions
{
    public static string ToNiceString(this UnityEngine.Object obj, int depth = 0, int maxDepth = 2)
    {
        
        StringBuilder sb = new StringBuilder();
        string indent = new string(' ', depth * 2);
        sb.AppendLine($"{indent}{obj.GetType().Name} Details at depth {depth}:");

        // Get all fields of the object
        sb.AppendLine($"{indent}Fields:");
        var fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var field in fields)
        {
            try
            {
                var value = field.GetValue(obj);
                if (value is Sprite sprite)
                {
                    sb.AppendLine($"{indent}{field.Name}: Sprite (Width: {sprite.rect.width}, Height: {sprite.rect.height})");
                }
                else if (value is IEnumerable enumerable && !(value is string))
                {
                    sb.AppendLine($"{indent}{field.Name}: {value.GetType().Name} (Count: {((ICollection)value).Count})");
                    if (depth < maxDepth)
                    {
                        foreach (var item in enumerable)
                        {
                            if (item is UnityEngine.Object childObj)
                            {
                                sb.AppendLine(childObj.ToNiceString(depth + 1, maxDepth));
                            }
                            else
                            {
                                sb.AppendLine($"{indent}  {item}");
                            }
                        }
                    }
                }
                else if (value is UnityEngine.Object childObj)
                {
                    sb.AppendLine($"{indent}{field.Name}: Child Object (Type: {childObj.GetType().Name})");
                    if (depth < maxDepth)
                    {
                        sb.AppendLine(childObj.ToNiceString(depth + 1, maxDepth));
                    }
                }
                else
                {
                    sb.AppendLine($"{indent}{field.Name}: {value}");
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine($"{indent}{field.Name}: Error retrieving value ({ex.Message})");
            }
        }

        // Get all properties of the object
        sb.AppendLine($"{indent}Properties:");
        var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var property in properties)
        {
            try
            {
                var value = property.GetValue(obj, null);
                if (value is Sprite sprite)
                {
                    sb.AppendLine($"{indent}{property.Name}: Sprite (Width: {sprite.rect.width}, Height: {sprite.rect.height})");
                }
                else if (value is IEnumerable enumerable && !(value is string))
                {
                    sb.AppendLine($"{indent}{property.Name}: {value.GetType().Name} (Count: {((ICollection)value).Count})");
                    if (depth < maxDepth)
                    {
                        foreach (var item in enumerable)
                        {
                            if (item is UnityEngine.Object childObj)
                            {
                                sb.AppendLine(childObj.ToNiceString(depth + 1, maxDepth));
                            }
                            else
                            {
                                sb.AppendLine($"{indent}  {item}");
                            }
                        }
                    }
                }
                else if (value is UnityEngine.Object childObj)
                {
                    sb.AppendLine($"{indent}{property.Name}: Child Object (Type: {childObj.GetType().Name})");
                    if (depth < maxDepth)
                    {
                        sb.AppendLine(childObj.ToNiceString(depth + 1, maxDepth));
                    }
                }
                else
                {
                    sb.AppendLine($"{indent}{property.Name}: {value}");
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine($"{indent}{property.Name}: Error retrieving value ({ex.Message})");
            }
        }

        return sb.ToString();
    }
}
