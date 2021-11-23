using Mobi1ot.Internal;
using Mobi1ot.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mobi1ot;

public partial class Mobi1otClient
{
    /// <summary>
    /// Gets the <see cref="Sim"/> object associated with the given <paramref name="iccid"/> or <paramref name="eid"/>.
    /// </summary>
    /// <param name="iccid">ICCID of the <see cref="Sim"/></param>
    /// <param name="eid">EID of the <see cref="Sim"/></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Mobi1otResponse<Sim>> GetSimAsync(string iccid = null,
                                                        string eid = null,
                                                        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(iccid) && string.IsNullOrWhiteSpace(eid))
            throw new InvalidOperationException($"Either {nameof(iccid)} or {nameof(eid)} must be specified");

        var args = new Dictionary<string, string>();
        if (!string.IsNullOrWhiteSpace(iccid)) args["iccid"] = iccid;
        else args["eid"] = eid;

        var query = QueryHelper.MakeQueryString(args);
        var url = new Uri(options.BaseUrl, $"/v1/get_sim{query}");
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        return await SendAsync<Sim>(request, cancellationToken);
    }

    /// <summary>
    /// Gets <see cref="Sim"/> objects with matching <paramref name="iccids"/> or <paramref name="eids"/>.
    /// </summary>
    /// <param name="iccids">An array ICCIDs representing the <see cref="Sim"/> objects</param>
    /// <param name="eids">An array EIDs representing the <see cref="Sim"/> objects</param>
    /// <param name="offset">Offset query by n objects</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <remarks>
    /// Retrieves the first 1000 instances found in the database.
    /// Optional <paramref name="offset"/> can be used offset the query by skipping the first n <see cref="Sim"/> objects.
    /// </remarks>
    public async Task<Mobi1otResponse<SimCollection>> GetSimsAsync(List<string> iccids = null,
                                                                   List<string> eids = null,
                                                                   int? offset = null,
                                                                   CancellationToken cancellationToken = default)
    {
        if ((iccids == null || iccids.Count == 0) && (eids == null || eids.Count == 0))
            throw new InvalidOperationException($"Either {nameof(iccids)} or {nameof(eids)} must have at least one entry");

        var args = new Dictionary<string, string>();
        if (offset != null) args["offset"] = $"{offset}";
        if (iccids != null && iccids.Count > 0) args["iccid"] = string.Join(",", iccids);
        else string.Join(",", eids);

        var query = QueryHelper.MakeQueryString(args);
        var url = new Uri(options.BaseUrl, $"/v1/get_sims{query}");
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        return await SendAsync<SimCollection>(request, cancellationToken);
    }

    /// <summary>
    /// Gets <see cref="Session"/> objects related to the <see cref="Sim"/> that the <paramref name="offset"/>
    /// or <paramref name="eid"/> represents.
    /// </summary>
    /// <param name="iccid">ICCID of the <see cref="Sim"/></param>
    /// <param name="eid">EID of the <see cref="Sim"/></param>
    /// <param name="offset">Offset query by n objects</param>
    /// <param name="from">Milliseconds from epoch of the earliest objects to return</param>
    /// <param name="to">Milliseconds from epoch of the latest objects to return</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <remarks>
    /// Retrieves the first 1000 <see cref="Session"/> objects found in the database.
    /// When <paramref name="from"/> is not specified, uses the beginning of the current month in UTC as the starting point.
    /// When <paramref name="to"/> is not specified, uses the time of the query as the ending point.
    /// Optional <paramref name="offset"/> can be used offset the query by skipping the first n SESSION objects.
    /// </remarks>
    public async Task<Mobi1otResponse<SessionCollection>> GetSimSessionsAsync(string iccid = null,
                                                                              string eid = null,
                                                                              int? offset = null,
                                                                              long? from = null,
                                                                              long? to = null,
                                                                              CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(iccid) && string.IsNullOrWhiteSpace(eid))
            throw new InvalidOperationException($"Either {nameof(iccid)} or {nameof(eid)} must be specified");

        var args = new Dictionary<string, string>();
        if (!string.IsNullOrWhiteSpace(iccid)) args["iccid"] = iccid;
        else args["eid"] = eid;
        if (offset != null) args["offset"] = $"{offset}";
        if (from != null) args["from"] = $"{from}";
        if (to != null) args["to"] = $"{to}";

        var query = QueryHelper.MakeQueryString(args);
        var url = new Uri(options.BaseUrl, $"/v1/get_sim_sessions{query}");
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        return await SendAsync<SessionCollection>(request, cancellationToken);
    }

    /// <summary>
    /// Gets the <see cref="Cost"/> object associated with the <see cref="Sim"/> that the <paramref name="iccid"/>
    /// or <paramref name="eid"/> represents.
    /// </summary>
    /// <param name="iccid">ICCID of the <see cref="Sim"/></param>
    /// <param name="eid">EID of the <see cref="Sim"/></param>
    /// <param name="month">Month (1-12) of the <see cref="Cost"/> to query</param>
    /// <param name="year">Year of the <see cref="Cost"/> to query</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <remarks>
    /// The <see cref="Cost"/> object shows the monthly cost info associated with a <see cref="Sim"/>.
    /// Parameters <paramref name="month"/> and <paramref name="year"/> can be used to specify a certain month and year.
    /// </remarks>
    public async Task<Mobi1otResponse<Cost>> GetSimCostAsync(string iccid = null,
                                                             string eid = null,
                                                             int? month = null,
                                                             int? year = null,
                                                             CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(iccid) && string.IsNullOrWhiteSpace(eid))
            throw new InvalidOperationException($"Either {nameof(iccid)} or {nameof(eid)} must be specified");

        var args = new Dictionary<string, string>();
        if (!string.IsNullOrWhiteSpace(iccid)) args["iccid"] = iccid;
        else args["eid"] = eid;
        if (month != null) args["month"] = $"{month}";
        if (year != null) args["year"] = $"{year}";

        var query = QueryHelper.MakeQueryString(args);
        var url = new Uri(options.BaseUrl, $"/v1/get_sim_cost{query}");
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        return await SendAsync<Cost>(request, cancellationToken);
    }

    /// <summary>
    /// Gets the <see cref="Cost"/> objects associated with the <see cref="Sim"/>s that the <paramref name="iccids"/>
    /// or <paramref name="eids"/> represents.
    /// </summary>
    /// <param name="iccids">An array ICCIDs of the <see cref="Sim"/>s</param>
    /// <param name="eids">An array EIDs of the <see cref="Sim"/>s</param>
    /// <param name="month">Month (1-12) of the <see cref="Cost"/> to query</param>
    /// <param name="year">Year of the <see cref="Cost"/> to query</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <remarks>
    /// The <see cref="Cost"/> object shows the monthly cost info associated with a <see cref="Sim"/>.
    /// Parameters <paramref name="month"/> and <paramref name="year"/> can be used to specify a certain month and year.
    /// </remarks>
    public async Task<Mobi1otResponse<List<Cost>>> GetSimCostsAsync(List<string> iccids = null,
                                                                    List<string> eids = null,
                                                                    int? month = null,
                                                                    int? year = null,
                                                                    CancellationToken cancellationToken = default)
    {
        if ((iccids == null || iccids.Count == 0) && (eids == null || eids.Count == 0))
            throw new InvalidOperationException($"Either {nameof(iccids)} or {nameof(eids)} must have at least one entry");

        var args = new Dictionary<string, string>();
        if (iccids != null && iccids.Count > 0) args["iccid"] = string.Join(",", iccids);
        else args["eid"] = string.Join(",", eids);
        if (month != null) args["month"] = $"{month}";
        if (year != null) args["year"] = $"{year}";

        var query = QueryHelper.MakeQueryString(args);
        var url = new Uri(options.BaseUrl, $"/v1/get_sim_costs{query}");
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        return await SendAsync<List<Cost>>(request, cancellationToken);
    }

    /// <summary>
    /// Gets all ALERT objects associated with the SIMs in the specified SIM.
    /// </summary>
    /// <param name="iccid">ICCID of the <see cref="Sim"/></param>
    /// <param name="unread">Only return unread alerts</param>
    /// <param name="markRead">Mark the returned alerts read after returning</param>
    /// <param name="offset">Offset query by n objects</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <remarks>
    /// Retrieves the first 1000 instances found in the database.
    /// Optional <paramref name="offset"/> can be used offset the query by skipping the first n ALERT objects.
    /// </remarks>
    public async Task<Mobi1otResponse<AlertCollection>> GetSimAlertsAsync(string iccid,
                                                                          bool? unread = null,
                                                                          bool? markRead = null,
                                                                          int? offset = null,
                                                                          CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(iccid)) throw new ArgumentNullException(nameof(iccid));

        var args = new Dictionary<string, string>
        {
            ["iccid"] = iccid
        };
        if (offset != null) args["offset"] = $"{offset}";
        if (unread != null) args["unread"] = $"{unread}";
        if (markRead != null) args["markRead"] = $"{markRead}";

        var query = QueryHelper.MakeQueryString(args);
        var url = new Uri(options.BaseUrl, $"/v1/get_sim_alerts{query}");
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        return await SendAsync<AlertCollection>(request, cancellationToken);
    }

    /// <summary>
    /// Retrieves diagnostics info of the SIM object that the <paramref name="iccid"/> or <paramref name="eid"/> represents.
    /// Availability of information depends on the SIM.
    /// </summary>
    /// <param name="iccid">ICCID of the <see cref="Sim"/></param>
    /// <param name="eid">EID of the <see cref="Sim"/></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Mobi1otResponse<DiagnosticsReport>> GetDiagnosticsAsync(string iccid = null,
                                                                              string eid = null,
                                                                              CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(iccid) && string.IsNullOrWhiteSpace(eid))
            throw new InvalidOperationException($"Either {nameof(iccid)} or {nameof(eid)} must be specified");

        var args = new Dictionary<string, string>();
        if (!string.IsNullOrWhiteSpace(iccid)) args["iccid"] = iccid;
        else args["eid"] = eid;

        var query = QueryHelper.MakeQueryString(args);
        var url = new Uri(options.BaseUrl, $"/v1/diagnostics{query}");
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        return await SendAsync<DiagnosticsReport>(request, cancellationToken);
    }
}
