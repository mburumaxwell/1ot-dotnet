using System.Text.RegularExpressions;

namespace Mobi1ot.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public enum ProfileAction
    {
        Enable,
        Delete,
        Download,
        DownloadAndEnable
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    internal static class ProfileActionExtensions
    {
        public static string GetQueryValue(this ProfileAction action)
        {
            var source = action.ToString();
            // introduce underscroe at the start of a capital letter
            var pascalSplit = Regex.Replace(source, @"(?<=[A-Za-z])(?=[A-Z][a-z])|(?<=[a-z0-9])(?=[0-9]?[A-Z])", "_");
            // ensure lowercase
            return pascalSplit.ToLower();
        }
    }
}
