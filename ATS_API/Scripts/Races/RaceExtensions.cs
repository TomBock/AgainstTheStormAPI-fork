using System.Text;
using Eremite;
using Eremite.Model;
using UnityEngine;

namespace ATS_API.Scripts.Races;

public static class RaceExtensions
{
    public static string ToNiceString(this IModel model)
    {
        StringBuilder sb = new StringBuilder();
        
        sb.AppendLine("Model Details:");
        sb.AppendLine("Fields:");
        
        // Get all fields of the RaceModel class
        var fields = model.GetType().GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        foreach (var field in fields)
        {
            try
            {
                var value = field.GetValue(model);
                if (value is Sprite sprite)
                {
                    sb.AppendLine($"{field.Name}: Sprite (Width: {sprite.rect.width}, Height: {sprite.rect.height})");
                }
                else
                {
                    sb.AppendLine($"{field.Name}: {value}");
                }
            }
            catch (System.Exception ex)
            {
                sb.AppendLine($"{field.Name}: Error retrieving value ({ex.Message})");
            }
        }

        sb.AppendLine("Properties:");

        // Get all properties of the RaceModel class
        var properties = model.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        foreach (var property in properties)
        {
            try
            {
                var value = property.GetValue(model, null);
                sb.AppendLine($"{property.Name}: {value}");
            }
            catch (System.Exception ex)
            {
                sb.AppendLine($"{property.Name}: Error retrieving value ({ex.Message})");
            }
        }

        return sb.ToString();
    }
}
