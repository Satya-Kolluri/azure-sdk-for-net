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
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing a collection of <see cref="TemplateSpecResource" /> and their operations.
    /// Each <see cref="TemplateSpecResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="TemplateSpecCollection" /> instance call the GetTemplateSpecs method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class TemplateSpecCollection : ArmCollection, IEnumerable<TemplateSpecResource>, IAsyncEnumerable<TemplateSpecResource>
    {
        private readonly ClientDiagnostics _templateSpecClientDiagnostics;
        private readonly TemplateSpecsRestOperations _templateSpecRestClient;

        /// <summary> Initializes a new instance of the <see cref="TemplateSpecCollection"/> class for mocking. </summary>
        protected TemplateSpecCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TemplateSpecCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TemplateSpecCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _templateSpecClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", TemplateSpecResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(TemplateSpecResource.ResourceType, out string templateSpecApiVersion);
            _templateSpecRestClient = new TemplateSpecsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, templateSpecApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a Template Spec.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}
        /// Operation Id: TemplateSpecs_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="templateSpecName"> Name of the Template Spec. </param>
        /// <param name="data"> Template Spec supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="templateSpecName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="templateSpecName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<TemplateSpecResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string templateSpecName, TemplateSpecData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(templateSpecName, nameof(templateSpecName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _templateSpecRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, templateSpecName, data, cancellationToken).ConfigureAwait(false);
                var operation = new ResourcesArmOperation<TemplateSpecResource>(Response.FromValue(new TemplateSpecResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates a Template Spec.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}
        /// Operation Id: TemplateSpecs_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="templateSpecName"> Name of the Template Spec. </param>
        /// <param name="data"> Template Spec supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="templateSpecName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="templateSpecName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<TemplateSpecResource> CreateOrUpdate(WaitUntil waitUntil, string templateSpecName, TemplateSpecData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(templateSpecName, nameof(templateSpecName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _templateSpecRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, templateSpecName, data, cancellationToken);
                var operation = new ResourcesArmOperation<TemplateSpecResource>(Response.FromValue(new TemplateSpecResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a Template Spec with a given name.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}
        /// Operation Id: TemplateSpecs_Get
        /// </summary>
        /// <param name="templateSpecName"> Name of the Template Spec. </param>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="templateSpecName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="templateSpecName"/> is null. </exception>
        public virtual async Task<Response<TemplateSpecResource>> GetAsync(string templateSpecName, TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(templateSpecName, nameof(templateSpecName));

            using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.Get");
            scope.Start();
            try
            {
                var response = await _templateSpecRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, templateSpecName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TemplateSpecResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a Template Spec with a given name.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}
        /// Operation Id: TemplateSpecs_Get
        /// </summary>
        /// <param name="templateSpecName"> Name of the Template Spec. </param>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="templateSpecName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="templateSpecName"/> is null. </exception>
        public virtual Response<TemplateSpecResource> Get(string templateSpecName, TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(templateSpecName, nameof(templateSpecName));

            using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.Get");
            scope.Start();
            try
            {
                var response = _templateSpecRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, templateSpecName, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TemplateSpecResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all the Template Specs within the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs
        /// Operation Id: TemplateSpecs_ListByResourceGroup
        /// </summary>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TemplateSpecResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TemplateSpecResource> GetAllAsync(TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<TemplateSpecResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _templateSpecRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TemplateSpecResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<TemplateSpecResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _templateSpecRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TemplateSpecResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all the Template Specs within the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs
        /// Operation Id: TemplateSpecs_ListByResourceGroup
        /// </summary>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TemplateSpecResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TemplateSpecResource> GetAll(TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            Page<TemplateSpecResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _templateSpecRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TemplateSpecResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<TemplateSpecResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _templateSpecRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TemplateSpecResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}
        /// Operation Id: TemplateSpecs_Get
        /// </summary>
        /// <param name="templateSpecName"> Name of the Template Spec. </param>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="templateSpecName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="templateSpecName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string templateSpecName, TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(templateSpecName, nameof(templateSpecName));

            using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(templateSpecName, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}
        /// Operation Id: TemplateSpecs_Get
        /// </summary>
        /// <param name="templateSpecName"> Name of the Template Spec. </param>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="templateSpecName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="templateSpecName"/> is null. </exception>
        public virtual Response<bool> Exists(string templateSpecName, TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(templateSpecName, nameof(templateSpecName));

            using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(templateSpecName, expand: expand, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}
        /// Operation Id: TemplateSpecs_Get
        /// </summary>
        /// <param name="templateSpecName"> Name of the Template Spec. </param>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="templateSpecName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="templateSpecName"/> is null. </exception>
        public virtual async Task<Response<TemplateSpecResource>> GetIfExistsAsync(string templateSpecName, TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(templateSpecName, nameof(templateSpecName));

            using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _templateSpecRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, templateSpecName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<TemplateSpecResource>(null, response.GetRawResponse());
                return Response.FromValue(new TemplateSpecResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}
        /// Operation Id: TemplateSpecs_Get
        /// </summary>
        /// <param name="templateSpecName"> Name of the Template Spec. </param>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="templateSpecName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="templateSpecName"/> is null. </exception>
        public virtual Response<TemplateSpecResource> GetIfExists(string templateSpecName, TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(templateSpecName, nameof(templateSpecName));

            using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _templateSpecRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, templateSpecName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<TemplateSpecResource>(null, response.GetRawResponse());
                return Response.FromValue(new TemplateSpecResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TemplateSpecResource> IEnumerable<TemplateSpecResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TemplateSpecResource> IAsyncEnumerable<TemplateSpecResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
