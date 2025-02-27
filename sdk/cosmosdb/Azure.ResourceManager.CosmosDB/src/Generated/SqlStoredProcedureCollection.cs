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
using Azure.ResourceManager.CosmosDB.Models;

namespace Azure.ResourceManager.CosmosDB
{
    /// <summary>
    /// A class representing a collection of <see cref="SqlStoredProcedureResource" /> and their operations.
    /// Each <see cref="SqlStoredProcedureResource" /> in the collection will belong to the same instance of <see cref="SqlContainerResource" />.
    /// To get a <see cref="SqlStoredProcedureCollection" /> instance call the GetSqlStoredProcedures method from an instance of <see cref="SqlContainerResource" />.
    /// </summary>
    public partial class SqlStoredProcedureCollection : ArmCollection, IEnumerable<SqlStoredProcedureResource>, IAsyncEnumerable<SqlStoredProcedureResource>
    {
        private readonly ClientDiagnostics _sqlStoredProcedureSqlResourcesClientDiagnostics;
        private readonly SqlResourcesRestOperations _sqlStoredProcedureSqlResourcesRestClient;

        /// <summary> Initializes a new instance of the <see cref="SqlStoredProcedureCollection"/> class for mocking. </summary>
        protected SqlStoredProcedureCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SqlStoredProcedureCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SqlStoredProcedureCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _sqlStoredProcedureSqlResourcesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.CosmosDB", SqlStoredProcedureResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SqlStoredProcedureResource.ResourceType, out string sqlStoredProcedureSqlResourcesApiVersion);
            _sqlStoredProcedureSqlResourcesRestClient = new SqlResourcesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, sqlStoredProcedureSqlResourcesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlContainerResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlContainerResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update an Azure Cosmos DB SQL storedProcedure
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/storedProcedures/{storedProcedureName}
        /// Operation Id: SqlResources_CreateUpdateSqlStoredProcedure
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="storedProcedureName"> Cosmos DB storedProcedure name. </param>
        /// <param name="data"> The parameters to provide for the current SQL storedProcedure. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="storedProcedureName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="storedProcedureName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SqlStoredProcedureResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string storedProcedureName, SqlStoredProcedureCreateUpdateData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(storedProcedureName, nameof(storedProcedureName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _sqlStoredProcedureSqlResourcesClientDiagnostics.CreateScope("SqlStoredProcedureCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _sqlStoredProcedureSqlResourcesRestClient.CreateUpdateSqlStoredProcedureAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, storedProcedureName, data, cancellationToken).ConfigureAwait(false);
                var operation = new CosmosDBArmOperation<SqlStoredProcedureResource>(new SqlStoredProcedureOperationSource(Client), _sqlStoredProcedureSqlResourcesClientDiagnostics, Pipeline, _sqlStoredProcedureSqlResourcesRestClient.CreateCreateUpdateSqlStoredProcedureRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, storedProcedureName, data).Request, response, OperationFinalStateVia.Location);
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
        /// Create or update an Azure Cosmos DB SQL storedProcedure
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/storedProcedures/{storedProcedureName}
        /// Operation Id: SqlResources_CreateUpdateSqlStoredProcedure
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="storedProcedureName"> Cosmos DB storedProcedure name. </param>
        /// <param name="data"> The parameters to provide for the current SQL storedProcedure. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="storedProcedureName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="storedProcedureName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SqlStoredProcedureResource> CreateOrUpdate(WaitUntil waitUntil, string storedProcedureName, SqlStoredProcedureCreateUpdateData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(storedProcedureName, nameof(storedProcedureName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _sqlStoredProcedureSqlResourcesClientDiagnostics.CreateScope("SqlStoredProcedureCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _sqlStoredProcedureSqlResourcesRestClient.CreateUpdateSqlStoredProcedure(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, storedProcedureName, data, cancellationToken);
                var operation = new CosmosDBArmOperation<SqlStoredProcedureResource>(new SqlStoredProcedureOperationSource(Client), _sqlStoredProcedureSqlResourcesClientDiagnostics, Pipeline, _sqlStoredProcedureSqlResourcesRestClient.CreateCreateUpdateSqlStoredProcedureRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, storedProcedureName, data).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the SQL storedProcedure under an existing Azure Cosmos DB database account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/storedProcedures/{storedProcedureName}
        /// Operation Id: SqlResources_GetSqlStoredProcedure
        /// </summary>
        /// <param name="storedProcedureName"> Cosmos DB storedProcedure name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="storedProcedureName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="storedProcedureName"/> is null. </exception>
        public virtual async Task<Response<SqlStoredProcedureResource>> GetAsync(string storedProcedureName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(storedProcedureName, nameof(storedProcedureName));

            using var scope = _sqlStoredProcedureSqlResourcesClientDiagnostics.CreateScope("SqlStoredProcedureCollection.Get");
            scope.Start();
            try
            {
                var response = await _sqlStoredProcedureSqlResourcesRestClient.GetSqlStoredProcedureAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, storedProcedureName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SqlStoredProcedureResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the SQL storedProcedure under an existing Azure Cosmos DB database account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/storedProcedures/{storedProcedureName}
        /// Operation Id: SqlResources_GetSqlStoredProcedure
        /// </summary>
        /// <param name="storedProcedureName"> Cosmos DB storedProcedure name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="storedProcedureName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="storedProcedureName"/> is null. </exception>
        public virtual Response<SqlStoredProcedureResource> Get(string storedProcedureName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(storedProcedureName, nameof(storedProcedureName));

            using var scope = _sqlStoredProcedureSqlResourcesClientDiagnostics.CreateScope("SqlStoredProcedureCollection.Get");
            scope.Start();
            try
            {
                var response = _sqlStoredProcedureSqlResourcesRestClient.GetSqlStoredProcedure(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, storedProcedureName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SqlStoredProcedureResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the SQL storedProcedure under an existing Azure Cosmos DB database account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/storedProcedures
        /// Operation Id: SqlResources_ListSqlStoredProcedures
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SqlStoredProcedureResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlStoredProcedureResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SqlStoredProcedureResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlStoredProcedureSqlResourcesClientDiagnostics.CreateScope("SqlStoredProcedureCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sqlStoredProcedureSqlResourcesRestClient.ListSqlStoredProceduresAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlStoredProcedureResource(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Lists the SQL storedProcedure under an existing Azure Cosmos DB database account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/storedProcedures
        /// Operation Id: SqlResources_ListSqlStoredProcedures
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlStoredProcedureResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlStoredProcedureResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SqlStoredProcedureResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlStoredProcedureSqlResourcesClientDiagnostics.CreateScope("SqlStoredProcedureCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sqlStoredProcedureSqlResourcesRestClient.ListSqlStoredProcedures(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlStoredProcedureResource(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/storedProcedures/{storedProcedureName}
        /// Operation Id: SqlResources_GetSqlStoredProcedure
        /// </summary>
        /// <param name="storedProcedureName"> Cosmos DB storedProcedure name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="storedProcedureName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="storedProcedureName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string storedProcedureName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(storedProcedureName, nameof(storedProcedureName));

            using var scope = _sqlStoredProcedureSqlResourcesClientDiagnostics.CreateScope("SqlStoredProcedureCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(storedProcedureName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/storedProcedures/{storedProcedureName}
        /// Operation Id: SqlResources_GetSqlStoredProcedure
        /// </summary>
        /// <param name="storedProcedureName"> Cosmos DB storedProcedure name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="storedProcedureName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="storedProcedureName"/> is null. </exception>
        public virtual Response<bool> Exists(string storedProcedureName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(storedProcedureName, nameof(storedProcedureName));

            using var scope = _sqlStoredProcedureSqlResourcesClientDiagnostics.CreateScope("SqlStoredProcedureCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(storedProcedureName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/storedProcedures/{storedProcedureName}
        /// Operation Id: SqlResources_GetSqlStoredProcedure
        /// </summary>
        /// <param name="storedProcedureName"> Cosmos DB storedProcedure name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="storedProcedureName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="storedProcedureName"/> is null. </exception>
        public virtual async Task<Response<SqlStoredProcedureResource>> GetIfExistsAsync(string storedProcedureName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(storedProcedureName, nameof(storedProcedureName));

            using var scope = _sqlStoredProcedureSqlResourcesClientDiagnostics.CreateScope("SqlStoredProcedureCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _sqlStoredProcedureSqlResourcesRestClient.GetSqlStoredProcedureAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, storedProcedureName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SqlStoredProcedureResource>(null, response.GetRawResponse());
                return Response.FromValue(new SqlStoredProcedureResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/storedProcedures/{storedProcedureName}
        /// Operation Id: SqlResources_GetSqlStoredProcedure
        /// </summary>
        /// <param name="storedProcedureName"> Cosmos DB storedProcedure name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="storedProcedureName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="storedProcedureName"/> is null. </exception>
        public virtual Response<SqlStoredProcedureResource> GetIfExists(string storedProcedureName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(storedProcedureName, nameof(storedProcedureName));

            using var scope = _sqlStoredProcedureSqlResourcesClientDiagnostics.CreateScope("SqlStoredProcedureCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _sqlStoredProcedureSqlResourcesRestClient.GetSqlStoredProcedure(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, storedProcedureName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SqlStoredProcedureResource>(null, response.GetRawResponse());
                return Response.FromValue(new SqlStoredProcedureResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SqlStoredProcedureResource> IEnumerable<SqlStoredProcedureResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SqlStoredProcedureResource> IAsyncEnumerable<SqlStoredProcedureResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
