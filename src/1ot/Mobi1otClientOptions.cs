using System;

namespace Mobi1ot;

/// <summary>
/// Options for configuring the <see cref="Mobi1otClient"/>
/// </summary>
public class Mobi1otClientOptions
{
    /// <summary>
    /// The username to access 1ot APIs
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// The password to access 1ot APIs
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// The base URL for the 1ot APIs
    /// </summary>
    public Uri BaseUrl { get; set; } = new Uri("https://api.1ot.mobi/");
}
