﻿using System.Text;

namespace Mobi1ot.Internal;

/// <summary>
/// Collection of helper methods for handling queries
/// </summary>
internal static class QueryHelper
{
    /// <summary>
    /// Make a query string using the given query key and value.
    /// </summary>
    /// <param name="name">The name of the query key.</param>
    /// <param name="value">The query value.</param>
    /// <returns>The query.</returns>
    public static string MakeQueryString(string name, string value) => AddQueryString(string.Empty, name, value);

    /// <summary>
    /// Make a query string using the given keys and values.
    /// </summary>
    /// <param name="queryString">A collection of name value query pairs to use.</param>
    /// <returns>The query.</returns>
    public static string MakeQueryString(IDictionary<string, string> queryString) => AddQueryString(string.Empty, queryString);

    /// <summary>
    /// Append the given query key and value to the URI.
    /// </summary>
    /// <param name="uri">The base URI.</param>
    /// <param name="name">The name of the query key.</param>
    /// <param name="value">The query value.</param>
    /// <returns>The combined result.</returns>
    public static string AddQueryString(string uri, string name, string value)
    {
        if (uri == null) throw new ArgumentNullException(nameof(uri));
        if (name == null) throw new ArgumentNullException(nameof(name));
        if (value == null) throw new ArgumentNullException(nameof(value));

        return AddQueryString(uri, new[] { new KeyValuePair<string, string>(name, value) });
    }

    /// <summary>
    /// Append the given query keys and values to the uri.
    /// </summary>
    /// <param name="uri">The base uri.</param>
    /// <param name="queryString">A collection of name value query pairs to append.</param>
    /// <returns>The combined result.</returns>
    public static string AddQueryString(string uri, IDictionary<string, string> queryString)
    {
        if (uri == null) throw new ArgumentNullException(nameof(uri));
        if (queryString == null) throw new ArgumentNullException(nameof(queryString));

        return AddQueryString(uri, (IEnumerable<KeyValuePair<string, string>>)queryString);
    }

    private static string AddQueryString(string uri, IEnumerable<KeyValuePair<string, string>> queryString)
    {
        if (uri == null) throw new ArgumentNullException(nameof(uri));
        if (queryString == null) throw new ArgumentNullException(nameof(queryString));

        var anchorIndex = uri.IndexOf('#');
        var uriToBeAppended = uri;
        var anchorText = "";
        // If there is an anchor, then the query string must be inserted before its first occurrence.
        if (anchorIndex != -1)
        {
            anchorText = uri.Substring(anchorIndex);
            uriToBeAppended = uri.Substring(0, anchorIndex);
        }

        var queryIndex = uriToBeAppended.IndexOf('?');
        var hasQuery = queryIndex != -1;

        var sb = new StringBuilder();
        sb.Append(uriToBeAppended);
        foreach (var parameter in queryString)
        {
            sb.Append(hasQuery ? '&' : '?');
            sb.Append(Uri.EscapeDataString(parameter.Key));
            sb.Append('=');
            sb.Append(Uri.EscapeDataString(parameter.Value));
            hasQuery = true;
        }

        sb.Append(anchorText);
        return sb.ToString();
    }
}
