// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Communication.Models;

namespace Azure.ResourceManager.Communication
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    internal partial class SubscriptionResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _communicationServiceClientDiagnostics;
        private CommunicationServiceRestOperations _communicationServiceRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionResourceExtensionClient"/> class for mocking. </summary>
        protected SubscriptionResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics CommunicationServiceClientDiagnostics => _communicationServiceClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Communication", CommunicationServiceResource.ResourceType.Namespace, Diagnostics);
        private CommunicationServiceRestOperations CommunicationServiceRestClient => _communicationServiceRestClient ??= new CommunicationServiceRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(CommunicationServiceResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Checks that the CommunicationService name is valid and is not already in use.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Communication/checkNameAvailability
        /// Operation Id: CommunicationService_CheckNameAvailability
        /// </summary>
        /// <param name="options"> Parameters supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<NameAvailability>> CheckCommunicationNameAvailabilityAsync(NameAvailabilityOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = CommunicationServiceClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.CheckCommunicationNameAvailability");
            scope.Start();
            try
            {
                var response = await CommunicationServiceRestClient.CheckNameAvailabilityAsync(Id.SubscriptionId, options, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks that the CommunicationService name is valid and is not already in use.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Communication/checkNameAvailability
        /// Operation Id: CommunicationService_CheckNameAvailability
        /// </summary>
        /// <param name="options"> Parameters supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NameAvailability> CheckCommunicationNameAvailability(NameAvailabilityOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = CommunicationServiceClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.CheckCommunicationNameAvailability");
            scope.Start();
            try
            {
                var response = CommunicationServiceRestClient.CheckNameAvailability(Id.SubscriptionId, options, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Handles requests to list all resources in a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Communication/communicationServices
        /// Operation Id: CommunicationService_ListBySubscription
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CommunicationServiceResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CommunicationServiceResource> GetCommunicationServicesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<CommunicationServiceResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = CommunicationServiceClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetCommunicationServices");
                scope.Start();
                try
                {
                    var response = await CommunicationServiceRestClient.ListBySubscriptionAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new CommunicationServiceResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<CommunicationServiceResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = CommunicationServiceClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetCommunicationServices");
                scope.Start();
                try
                {
                    var response = await CommunicationServiceRestClient.ListBySubscriptionNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new CommunicationServiceResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Handles requests to list all resources in a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Communication/communicationServices
        /// Operation Id: CommunicationService_ListBySubscription
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CommunicationServiceResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CommunicationServiceResource> GetCommunicationServices(CancellationToken cancellationToken = default)
        {
            Page<CommunicationServiceResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = CommunicationServiceClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetCommunicationServices");
                scope.Start();
                try
                {
                    var response = CommunicationServiceRestClient.ListBySubscription(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new CommunicationServiceResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<CommunicationServiceResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = CommunicationServiceClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetCommunicationServices");
                scope.Start();
                try
                {
                    var response = CommunicationServiceRestClient.ListBySubscriptionNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new CommunicationServiceResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
