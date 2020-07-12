using Mobi1ot.Internal;
using Mobi1ot.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mobi1ot
{
    public partial class Mobi1otClient
    {
        /// <summary>
        /// Changes the name associated with the <see cref="Sim"/> object that the <paramref name="iccids"/>
        /// or <paramref name="eids"/> represents.
        /// </summary>
        /// <param name="name">Name of the SIM</param>
        /// <param name="iccids">An array ICCIDs of the <see cref="Sim"/>s</param>
        /// <param name="eids">An array EIDs of the <see cref="Sim"/>s</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Mobi1otResponse<object>> SetSimNameAsync(string name,
                                                                   List<string> iccids = null,
                                                                   List<string> eids = null,
                                                                   CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if ((iccids == null || iccids.Count == 0) && (eids == null || eids.Count == 0))
                throw new InvalidOperationException($"Either {nameof(iccids)} or {nameof(eids)} must have at least one entry");

            var args = new Dictionary<string, string>
            {
                ["name"] = name,
            };
            if (iccids != null && iccids.Count > 0) args["iccid"] = string.Join(",", iccids);
            else args["eid"] = string.Join(",", eids);

            var query = QueryHelper.MakeQueryString(args);
            var url = new Uri(options.BaseUrl, $"/v1/set_name{query}");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            return await SendAsync<object>(request, cancellationToken);
        }

        /// <summary>
        /// Changes the group associated with the <see cref="Sim"/> object that the <paramref name="iccids"/>
        /// or <paramref name="eid"/> represents.
        /// </summary>
        /// <param name="group">Name of the group</param>
        /// <param name="iccids">ICCID of the <see cref="Sim"/></param>
        /// <param name="eid">EID of the <see cref="Sim"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Mobi1otResponse<object>> SetSimGroupAsync(string group,
                                                                    List<string> iccids = null,
                                                                    string eid = null,
                                                                    CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(group)) throw new ArgumentNullException(nameof(group));
            if ((iccids == null || iccids.Count == 0) && string.IsNullOrWhiteSpace(eid))
                throw new InvalidOperationException($"Either {nameof(iccids)} or {nameof(eid)} must be specified");

            var args = new Dictionary<string, string>
            {
                ["group"] = group,
            };
            if (iccids != null && iccids.Count > 0) args["iccid"] = string.Join(",", iccids);
            else args["eid"] = eid;

            var query = QueryHelper.MakeQueryString(args);
            var url = new Uri(options.BaseUrl, $"/v1/set_group{query}");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            return await SendAsync<object>(request, cancellationToken);
        }

        /// <summary>
        /// Requests the <see cref="Sim"/> object that the <paramref name="iccids"/> or <paramref name="eids"/> represents
        /// to be put in a suspended state.
        /// </summary>
        /// <param name="iccids">An array ICCIDs of the <see cref="Sim"/>s</param>
        /// <param name="eids">An array EIDs of the <see cref="Sim"/>s</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Mobi1otResponse<object>> SuspendAsync(List<string> iccids = null,
                                                                List<string> eids = null,
                                                                CancellationToken cancellationToken = default)
        {
            if ((iccids == null || iccids.Count == 0) && (eids == null || eids.Count == 0))
                throw new InvalidOperationException($"Either {nameof(iccids)} or {nameof(eids)} must have at least one entry");

            var args = new Dictionary<string, string>();
            if (iccids != null && iccids.Count > 0) args["iccid"] = string.Join(",", iccids);
            else args["eid"] = string.Join(",", eids);

            var query = QueryHelper.MakeQueryString(args);
            var url = new Uri(options.BaseUrl, $"/v1/suspend{query}");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            return await SendAsync<object>(request, cancellationToken);
        }

        /// <summary>
        /// Requests the <see cref="Sim"/> object that the <paramref name="iccids"/> or <paramref name="eids"/> represents
        /// to be resumed.
        /// </summary>
        /// <param name="iccids">An array ICCIDs of the <see cref="Sim"/>s</param>
        /// <param name="eids">An array EIDs of the <see cref="Sim"/>s</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Mobi1otResponse<object>> ResumeAsync(List<string> iccids = null,
                                                               List<string> eids = null,
                                                               CancellationToken cancellationToken = default)
        {
            if ((iccids == null || iccids.Count == 0) && (eids == null || eids.Count == 0))
                throw new InvalidOperationException($"Either {nameof(iccids)} or {nameof(eids)} must have at least one entry");

            var args = new Dictionary<string, string>();
            if (iccids != null && iccids.Count > 0) args["iccid"] = string.Join(",", iccids);
            else args["eid"] = string.Join(",", eids);

            var query = QueryHelper.MakeQueryString(args);
            var url = new Uri(options.BaseUrl, $"/v1/resume{query}");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            return await SendAsync<object>(request, cancellationToken);
        }

        /// <summary>
        /// Requests the <see cref="Sim"/> object that the <paramref name="iccids"/> or <paramref name="eids"/> represents
        /// to be put in a deactivated state.
        /// </summary>
        /// <param name="iccids">An array ICCIDs of the <see cref="Sim"/>s</param>
        /// <param name="eids">An array EIDs of the <see cref="Sim"/>s</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Mobi1otResponse<object>> DeactivateAsync(List<string> iccids = null,
                                                                   List<string> eids = null,
                                                                   CancellationToken cancellationToken = default)
        {
            if ((iccids == null || iccids.Count == 0) && (eids == null || eids.Count == 0))
                throw new InvalidOperationException($"Either {nameof(iccids)} or {nameof(eids)} must have at least one entry");

            var args = new Dictionary<string, string>();
            if (iccids != null && iccids.Count > 0) args["iccid"] = string.Join(",", iccids);
            else args["eid"] = string.Join(",", eids);

            var query = QueryHelper.MakeQueryString(args);
            var url = new Uri(options.BaseUrl, $"/v1/deactivate{query}");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            return await SendAsync<object>(request, cancellationToken);
        }

        /// <summary>
        /// Requests the <see cref="Sim"/> object that the <paramref name="iccids"/> or <paramref name="eids"/> represents
        /// to be activated.
        /// </summary>
        /// <param name="iccids">An array ICCIDs of the <see cref="Sim"/>s</param>
        /// <param name="eids">An array EIDs of the <see cref="Sim"/>s</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Mobi1otResponse<object>> ActivateAsync(List<string> iccids = null,
                                                                 List<string> eids = null,
                                                                 CancellationToken cancellationToken = default)
        {
            if ((iccids == null || iccids.Count == 0) && (eids == null || eids.Count == 0))
                throw new InvalidOperationException($"Either {nameof(iccids)} or {nameof(eids)} must have at least one entry");

            var args = new Dictionary<string, string>();
            if (iccids != null && iccids.Count > 0) args["iccid"] = string.Join(",", iccids);
            else args["eid"] = string.Join(",", eids);

            var query = QueryHelper.MakeQueryString(args);
            var url = new Uri(options.BaseUrl, $"/v1/activate{query}");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            return await SendAsync<object>(request, cancellationToken);
        }

        /// <summary>
        /// Requests the <see cref="Sim"/> object that the <paramref name="iccids"/> or <paramref name="eids"/> represents
        /// to be put in TEST mode.
        /// </summary>
        /// <param name="iccids">An array ICCIDs of the <see cref="Sim"/>s</param>
        /// <param name="eids">An array EIDs of the <see cref="Sim"/>s</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Mobi1otResponse<object>> TestAsync(List<string> iccids = null,
                                                             List<string> eids = null,
                                                             CancellationToken cancellationToken = default)
        {
            if ((iccids == null || iccids.Count == 0) && (eids == null || eids.Count == 0))
                throw new InvalidOperationException($"Either {nameof(iccids)} or {nameof(eids)} must have at least one entry");

            var args = new Dictionary<string, string>();
            if (iccids != null && iccids.Count > 0) args["iccid"] = string.Join(",", iccids);
            else args["eid"] = string.Join(",", eids);

            var query = QueryHelper.MakeQueryString(args);
            var url = new Uri(options.BaseUrl, $"/v1/test{query}");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            return await SendAsync<object>(request, cancellationToken);
        }

        /// <summary>
        /// Requests the <see cref="Sim"/> object that the <paramref name="iccids"/> or <paramref name="eids"/> represents
        /// to be reset.
        /// </summary>
        /// <param name="iccids">An array ICCIDs of the <see cref="Sim"/>s</param>
        /// <param name="eids">An array EIDs of the <see cref="Sim"/>s</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Mobi1otResponse<object>> ResetAsync(List<string> iccids = null,
                                                              List<string> eids = null,
                                                              CancellationToken cancellationToken = default)
        {
            if ((iccids == null || iccids.Count == 0) && (eids == null || eids.Count == 0))
                throw new InvalidOperationException($"Either {nameof(iccids)} or {nameof(eids)} must have at least one entry");

            var args = new Dictionary<string, string>();
            if (iccids != null && iccids.Count > 0) args["iccid"] = string.Join(",", iccids);
            else args["eid"] = string.Join(",", eids);

            var query = QueryHelper.MakeQueryString(args);
            var url = new Uri(options.BaseUrl, $"/v1/reset{query}");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            return await SendAsync<object>(request, cancellationToken);
        }

        /// <summary>
        /// Requests the <see cref="Sim"/> object that the <paramref name="iccids"/> or <paramref name="eids"/> represents
        /// to be closed (this is final, the SIM(s) can not be reactivated).
        /// </summary>
        /// <param name="iccids">An array ICCIDs of the <see cref="Sim"/>s</param>
        /// <param name="eids">An array EIDs of the <see cref="Sim"/>s</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Mobi1otResponse<object>> CloseAsync(List<string> iccids = null,
                                                              List<string> eids = null,
                                                              CancellationToken cancellationToken = default)
        {
            if ((iccids == null || iccids.Count == 0) && (eids == null || eids.Count == 0))
                throw new InvalidOperationException($"Either {nameof(iccids)} or {nameof(eids)} must have at least one entry");

            var args = new Dictionary<string, string>();
            if (iccids != null && iccids.Count > 0) args["iccid"] = string.Join(",", iccids);
            else args["eid"] = string.Join(",", eids);

            var query = QueryHelper.MakeQueryString(args);
            var url = new Uri(options.BaseUrl, $"/v1/close{query}");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            return await SendAsync<object>(request, cancellationToken);
        }

        /// <summary>
        /// Requests to send an SMS with the <paramref name="message"/> specified that the <paramref name="iccids"/>
        /// or <paramref name="eids"/> represents.
        /// </summary>
        /// <param name="message">The message to be sent to the 'SIM' as an SMS</param>
        /// <param name="iccids">An array ICCIDs of the <see cref="Sim"/>s</param>
        /// <param name="eids">An array EIDs of the <see cref="Sim"/>s</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Mobi1otResponse<MessageSendResult>> SendSmsAsync(string message,
                                                                           List<string> iccids = null,
                                                                           List<string> eids = null,
                                                                           CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));
            if ((iccids == null || iccids.Count == 0) && (eids == null || eids.Count == 0))
                throw new InvalidOperationException($"Either {nameof(iccids)} or {nameof(eids)} must have at least one entry");

            var args = new Dictionary<string, string>
            {
                ["message"] = message,
            };
            if (iccids != null && iccids.Count > 0) args["iccid"] = string.Join(",", iccids);
            else args["eid"] = string.Join(",", eids);

            var query = QueryHelper.MakeQueryString(args);
            var url = new Uri(options.BaseUrl, $"/v1/sendSms{query}");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            return await SendAsync<MessageSendResult>(request, cancellationToken);
        }

        /// <summary>
        /// Changes the data limit of the <see cref="Sim"/> object that the <paramref name="iccids"/>
        /// or <paramref name="eids"/> represents.
        /// </summary>
        /// <param name="limit">The new data limit in megabytes</param>
        /// <param name="iccids">An array ICCIDs of the <see cref="Sim"/>s</param>
        /// <param name="eids">An array EIDs of the <see cref="Sim"/>s</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Mobi1otResponse<MessageSendResult>> SetDataLimitAsync(int limit,
                                                                                List<string> iccids = null,
                                                                                List<string> eids = null,
                                                                                CancellationToken cancellationToken = default)
        {
            if ((iccids == null || iccids.Count == 0) && (eids == null || eids.Count == 0))
                throw new InvalidOperationException($"Either {nameof(iccids)} or {nameof(eids)} must have at least one entry");

            var args = new Dictionary<string, string>
            {
                ["limit"] = $"{limit}",
            };
            if (iccids != null && iccids.Count > 0) args["iccid"] = string.Join(",", iccids);
            else args["eid"] = string.Join(",", eids);

            var query = QueryHelper.MakeQueryString(args);
            var url = new Uri(options.BaseUrl, $"/v1/set_data_limit{query}");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            return await SendAsync<MessageSendResult>(request, cancellationToken);
        }

        /// <summary>
        /// Requests a given <see cref="ProfileAction"/> for the <see cref="Sim"/> object that the <paramref name="iccids"/>
        /// or <paramref name="eids"/> represents.
        /// </summary>
        /// <param name="profile">
        /// The profile to be acted upon.
        /// Valid names can be queried using <see cref="GetAvailableProfilesAsync(CancellationToken)"/>
        /// or by looking at the <see cref="Sim.DownloadedProfiles"/>.
        /// </param>
        /// <param name="action">The profile transaction type to be requested</param>
        /// <param name="iccids">An array ICCIDs of the <see cref="Sim"/>s</param>
        /// <param name="eids">An array EIDs of the <see cref="Sim"/>s</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Mobi1otResponse<object>> ESimProfileAsync(string profile,
                                                                    ProfileAction action,
                                                                    List<string> iccids = null,
                                                                    List<string> eids = null,
                                                                    CancellationToken cancellationToken = default)
        {
            if ((iccids == null || iccids.Count == 0) && (eids == null || eids.Count == 0))
                throw new InvalidOperationException($"Either {nameof(iccids)} or {nameof(eids)} must have at least one entry");

            var args = new Dictionary<string, string>
            {
                ["profile"] = $"{profile}",
                ["action"] = action.GetQueryValue(),
            };
            if (iccids != null && iccids.Count > 0) args["iccid"] = string.Join(",", iccids);
            else args["eid"] = string.Join(",", eids);

            var query = QueryHelper.MakeQueryString(args);
            var url = new Uri(options.BaseUrl, $"/v1/esim_profile{query}");
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            return await SendAsync<object>(request, cancellationToken);
        }
    }
}
