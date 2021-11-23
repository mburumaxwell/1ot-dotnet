using System.Net;

namespace Mobi1ot;

/// <summary>
/// 1ot's API Response
/// </summary>
/// <typeparam name="T"></typeparam>
public class Mobi1otResponse<T>
{
    /// <summary>
    /// The resource extracted from the response body
    /// </summary>
    public T? Resource { get; set; }

    /// <summary>
    /// The error extracted from the response body
    /// </summary>
    public Mobi1otError? Error { get; set; }

    /// <summary>
    /// Status code response from the API
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// Indicates whether a request has succeeded
    /// </summary>
    public bool IsSuccessful { get; set; }
}
