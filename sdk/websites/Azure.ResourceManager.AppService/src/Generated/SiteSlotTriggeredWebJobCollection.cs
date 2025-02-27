// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A class representing a collection of <see cref="SiteSlotTriggeredWebJobResource" /> and their operations.
    /// Each <see cref="SiteSlotTriggeredWebJobResource" /> in the collection will belong to the same instance of <see cref="WebSiteResource" />.
    /// To get a <see cref="SiteSlotTriggeredWebJobCollection" /> instance call the GetSiteSlotTriggeredWebJobs method from an instance of <see cref="WebSiteResource" />.
    /// </summary>
    public partial class SiteSlotTriggeredWebJobCollection : ArmCollection, IEnumerable<SiteSlotTriggeredWebJobResource>, IAsyncEnumerable<SiteSlotTriggeredWebJobResource>
    {
        private readonly ClientDiagnostics _siteSlotTriggeredWebJobWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteSlotTriggeredWebJobWebAppsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SiteSlotTriggeredWebJobCollection"/> class for mocking. </summary>
        protected SiteSlotTriggeredWebJobCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SiteSlotTriggeredWebJobCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SiteSlotTriggeredWebJobCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteSlotTriggeredWebJobWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", SiteSlotTriggeredWebJobResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SiteSlotTriggeredWebJobResource.ResourceType, out string siteSlotTriggeredWebJobWebAppsApiVersion);
            _siteSlotTriggeredWebJobWebAppsRestClient = new WebAppsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, siteSlotTriggeredWebJobWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != WebSiteResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, WebSiteResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Gets a triggered web job by its ID for an app, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}
        /// Operation Id: WebApps_GetTriggeredWebJob
        /// </summary>
        /// <param name="webJobName"> Name of Web Job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public virtual async Task<Response<SiteSlotTriggeredWebJobResource>> GetAsync(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteSlotTriggeredWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotTriggeredWebJobCollection.Get");
            scope.Start();
            try
            {
                var response = await _siteSlotTriggeredWebJobWebAppsRestClient.GetTriggeredWebJobAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, webJobName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotTriggeredWebJobResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets a triggered web job by its ID for an app, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}
        /// Operation Id: WebApps_GetTriggeredWebJob
        /// </summary>
        /// <param name="webJobName"> Name of Web Job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public virtual Response<SiteSlotTriggeredWebJobResource> Get(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteSlotTriggeredWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotTriggeredWebJobCollection.Get");
            scope.Start();
            try
            {
                var response = _siteSlotTriggeredWebJobWebAppsRestClient.GetTriggeredWebJob(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, webJobName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotTriggeredWebJobResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for List triggered web jobs for an app, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs
        /// Operation Id: WebApps_ListTriggeredWebJobs
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteSlotTriggeredWebJobResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteSlotTriggeredWebJobResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SiteSlotTriggeredWebJobResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteSlotTriggeredWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotTriggeredWebJobCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteSlotTriggeredWebJobWebAppsRestClient.ListTriggeredWebJobsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotTriggeredWebJobResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SiteSlotTriggeredWebJobResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteSlotTriggeredWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotTriggeredWebJobCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteSlotTriggeredWebJobWebAppsRestClient.ListTriggeredWebJobsNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotTriggeredWebJobResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Description for List triggered web jobs for an app, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs
        /// Operation Id: WebApps_ListTriggeredWebJobs
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteSlotTriggeredWebJobResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteSlotTriggeredWebJobResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SiteSlotTriggeredWebJobResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteSlotTriggeredWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotTriggeredWebJobCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteSlotTriggeredWebJobWebAppsRestClient.ListTriggeredWebJobs(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotTriggeredWebJobResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SiteSlotTriggeredWebJobResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteSlotTriggeredWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotTriggeredWebJobCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteSlotTriggeredWebJobWebAppsRestClient.ListTriggeredWebJobsNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotTriggeredWebJobResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}
        /// Operation Id: WebApps_GetTriggeredWebJob
        /// </summary>
        /// <param name="webJobName"> Name of Web Job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteSlotTriggeredWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotTriggeredWebJobCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(webJobName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}
        /// Operation Id: WebApps_GetTriggeredWebJob
        /// </summary>
        /// <param name="webJobName"> Name of Web Job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public virtual Response<bool> Exists(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteSlotTriggeredWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotTriggeredWebJobCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(webJobName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}
        /// Operation Id: WebApps_GetTriggeredWebJob
        /// </summary>
        /// <param name="webJobName"> Name of Web Job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public virtual async Task<Response<SiteSlotTriggeredWebJobResource>> GetIfExistsAsync(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteSlotTriggeredWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotTriggeredWebJobCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _siteSlotTriggeredWebJobWebAppsRestClient.GetTriggeredWebJobAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, webJobName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SiteSlotTriggeredWebJobResource>(null, response.GetRawResponse());
                return Response.FromValue(new SiteSlotTriggeredWebJobResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}
        /// Operation Id: WebApps_GetTriggeredWebJob
        /// </summary>
        /// <param name="webJobName"> Name of Web Job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public virtual Response<SiteSlotTriggeredWebJobResource> GetIfExists(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteSlotTriggeredWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotTriggeredWebJobCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _siteSlotTriggeredWebJobWebAppsRestClient.GetTriggeredWebJob(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, webJobName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SiteSlotTriggeredWebJobResource>(null, response.GetRawResponse());
                return Response.FromValue(new SiteSlotTriggeredWebJobResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SiteSlotTriggeredWebJobResource> IEnumerable<SiteSlotTriggeredWebJobResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SiteSlotTriggeredWebJobResource> IAsyncEnumerable<SiteSlotTriggeredWebJobResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
