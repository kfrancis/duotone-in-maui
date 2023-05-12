using FontAwesome;
using System.ComponentModel;
using System.Reflection;

namespace CommunityFA.Controls.Helpers
{
    internal static class DescriptionHelper
    {
        internal static string? GetDescriptionByUnicodeValue(string unicodeValue)
        {
            // Get all public static fields of the type
            var fields = typeof(FontAwesomeIcons).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            // Search for the field with a value that matches the provided unicodeValue
            var field = fields
                .Where(f => f.IsLiteral && !f.IsInitOnly)  // Ensure it's a constant
                .FirstOrDefault(f => (string?)f.GetValue(null) == unicodeValue) ?? throw new ArgumentException("No matching unicode value found", nameof(unicodeValue));

            // Get the Description attribute of the field and return its value
            var descriptionAttr = field.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return descriptionAttr?.Description;
        }

        internal static string? GetUnicodeValueByDescription(string description)
        {
            // Get all public static fields of the type
            var fields = typeof(FontAwesomeIcons).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            // Search for the field with a Description attribute that matches the provided description
            var field = fields
                .Where(f => f.IsLiteral && !f.IsInitOnly)  // Ensure it's a constant
                .FirstOrDefault(f =>
                {
                    var descriptionAttr = f.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
                    return descriptionAttr?.Description == description;
                }) ?? throw new ArgumentException("No matching description found", nameof(description));

            // Return the string value of the field
            return field.GetValue(null) as string;
        }
    }
}