using Microsoft.Extensions.Options;
using Mobi1ot;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class IServiceCollectionExtensions
{
    internal class Mobi1otClientValidateOptions : IValidateOptions<Mobi1otClientOptions>
    {
        public ValidateOptionsResult Validate(string name, Mobi1otClientOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.Username))
            {
                return ValidateOptionsResult.Fail($"'{nameof(options.Username)}' must be specified.");
            }

            if (string.IsNullOrWhiteSpace(options.Password))
            {
                return ValidateOptionsResult.Fail($"'{nameof(options.Password)}' must be specified.");
            }

            if (options.BaseUrl == null)
            {
                return ValidateOptionsResult.Fail($"'{nameof(options.BaseUrl)}' must be specified.");
            }

            return ValidateOptionsResult.Success;
        }
    }
}
