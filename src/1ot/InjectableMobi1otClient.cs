using Microsoft.Extensions.Options;
using System.Net.Http;

namespace Mobi1ot;

/// <summary>
/// A wrapped <see cref="Mobi1otClient"/> with single constructor to inject an <see cref="HttpClient"/>
/// whose lifetime is managed externally, e.g. by an DI container.
/// </summary>
internal class InjectableMobi1otClient : Mobi1otClient
{
    public InjectableMobi1otClient(HttpClient httpClient, IOptions<Mobi1otClientOptions> optionsAccessor)
        : base(optionsAccessor.Value, httpClient) { }
}
