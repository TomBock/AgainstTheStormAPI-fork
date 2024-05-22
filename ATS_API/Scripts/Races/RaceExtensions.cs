using System.Text;
using Eremite;
using Eremite.Model;

namespace ATS_API.Scripts.Races;

public static class RaceExtensions
{
    public static string ToNiceString(this RaceModel raceModel)
    {
        StringBuilder sb = new StringBuilder();
        
        sb.AppendLine("RaceModel Details:");
        sb.AppendLine("Fields:");
        
        // Get all fields of the RaceModel class
        var fields = raceModel.GetType().GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        foreach (var field in fields)
        {
            try
            {
                var value = field.GetValue(raceModel);
                sb.AppendLine($"{field.Name}: {value}");
            }
            catch (System.Exception ex)
            {
                sb.AppendLine($"{field.Name}: Error retrieving value ({ex.Message})");
            }
        }

        sb.AppendLine("Properties:");

        // Get all properties of the RaceModel class
        var properties = raceModel.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        foreach (var property in properties)
        {
            try
            {
                var value = property.GetValue(raceModel, null);
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
