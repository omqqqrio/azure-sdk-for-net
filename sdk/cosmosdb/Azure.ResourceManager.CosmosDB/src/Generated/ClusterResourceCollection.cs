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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.CosmosDB
{
    /// <summary> A class representing collection of ClusterResource and their operations over its parent. </summary>
    public partial class ClusterResourceCollection : ArmCollection, IEnumerable<ClusterResource>, IAsyncEnumerable<ClusterResource>
    {
        private readonly ClientDiagnostics _clusterResourceCassandraClustersClientDiagnostics;
        private readonly CassandraClustersRestOperations _clusterResourceCassandraClustersRestClient;

        /// <summary> Initializes a new instance of the <see cref="ClusterResourceCollection"/> class for mocking. </summary>
        protected ClusterResourceCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ClusterResourceCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ClusterResourceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _clusterResourceCassandraClustersClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.CosmosDB", ClusterResource.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ClusterResource.ResourceType, out string clusterResourceCassandraClustersApiVersion);
            _clusterResourceCassandraClustersRestClient = new CassandraClustersRestOperations(_clusterResourceCassandraClustersClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, clusterResourceCassandraClustersApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update a managed Cassandra cluster. When updating, you must specify all writable properties. To update only some properties, use PATCH.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}
        /// Operation Id: CassandraClusters_CreateUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="body"> The properties specifying the desired state of the managed Cassandra cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> or <paramref name="body"/> is null. </exception>
        public async virtual Task<ArmOperation<ClusterResource>> CreateOrUpdateAsync(bool waitForCompletion, string clusterName, ClusterResourceData body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var scope = _clusterResourceCassandraClustersClientDiagnostics.CreateScope("ClusterResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _clusterResourceCassandraClustersRestClient.CreateUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, clusterName, body, cancellationToken).ConfigureAwait(false);
                var operation = new CosmosDBArmOperation<ClusterResource>(new ClusterResourceOperationSource(Client), _clusterResourceCassandraClustersClientDiagnostics, Pipeline, _clusterResourceCassandraClustersRestClient.CreateCreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, clusterName, body).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
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
        /// Create or update a managed Cassandra cluster. When updating, you must specify all writable properties. To update only some properties, use PATCH.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}
        /// Operation Id: CassandraClusters_CreateUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="body"> The properties specifying the desired state of the managed Cassandra cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> or <paramref name="body"/> is null. </exception>
        public virtual ArmOperation<ClusterResource> CreateOrUpdate(bool waitForCompletion, string clusterName, ClusterResourceData body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var scope = _clusterResourceCassandraClustersClientDiagnostics.CreateScope("ClusterResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _clusterResourceCassandraClustersRestClient.CreateUpdate(Id.SubscriptionId, Id.ResourceGroupName, clusterName, body, cancellationToken);
                var operation = new CosmosDBArmOperation<ClusterResource>(new ClusterResourceOperationSource(Client), _clusterResourceCassandraClustersClientDiagnostics, Pipeline, _clusterResourceCassandraClustersRestClient.CreateCreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, clusterName, body).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
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
        /// Get the properties of a managed Cassandra cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}
        /// Operation Id: CassandraClusters_Get
        /// </summary>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> is null. </exception>
        public async virtual Task<Response<ClusterResource>> GetAsync(string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));

            using var scope = _clusterResourceCassandraClustersClientDiagnostics.CreateScope("ClusterResourceCollection.Get");
            scope.Start();
            try
            {
                var response = await _clusterResourceCassandraClustersRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, clusterName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clusterResourceCassandraClustersClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ClusterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the properties of a managed Cassandra cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}
        /// Operation Id: CassandraClusters_Get
        /// </summary>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> is null. </exception>
        public virtual Response<ClusterResource> Get(string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));

            using var scope = _clusterResourceCassandraClustersClientDiagnostics.CreateScope("ClusterResourceCollection.Get");
            scope.Start();
            try
            {
                var response = _clusterResourceCassandraClustersRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, clusterName, cancellationToken);
                if (response.Value == null)
                    throw _clusterResourceCassandraClustersClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ClusterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List all managed Cassandra clusters in this resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters
        /// Operation Id: CassandraClusters_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ClusterResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ClusterResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ClusterResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clusterResourceCassandraClustersClientDiagnostics.CreateScope("ClusterResourceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _clusterResourceCassandraClustersRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ClusterResource(Client, value)), null, response.GetRawResponse());
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
        /// List all managed Cassandra clusters in this resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters
        /// Operation Id: CassandraClusters_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ClusterResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ClusterResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ClusterResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clusterResourceCassandraClustersClientDiagnostics.CreateScope("ClusterResourceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _clusterResourceCassandraClustersRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ClusterResource(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}
        /// Operation Id: CassandraClusters_Get
        /// </summary>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));

            using var scope = _clusterResourceCassandraClustersClientDiagnostics.CreateScope("ClusterResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(clusterName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}
        /// Operation Id: CassandraClusters_Get
        /// </summary>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> is null. </exception>
        public virtual Response<bool> Exists(string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));

            using var scope = _clusterResourceCassandraClustersClientDiagnostics.CreateScope("ClusterResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(clusterName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}
        /// Operation Id: CassandraClusters_Get
        /// </summary>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> is null. </exception>
        public async virtual Task<Response<ClusterResource>> GetIfExistsAsync(string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));

            using var scope = _clusterResourceCassandraClustersClientDiagnostics.CreateScope("ClusterResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _clusterResourceCassandraClustersRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, clusterName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ClusterResource>(null, response.GetRawResponse());
                return Response.FromValue(new ClusterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}
        /// Operation Id: CassandraClusters_Get
        /// </summary>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> is null. </exception>
        public virtual Response<ClusterResource> GetIfExists(string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));

            using var scope = _clusterResourceCassandraClustersClientDiagnostics.CreateScope("ClusterResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _clusterResourceCassandraClustersRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, clusterName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ClusterResource>(null, response.GetRawResponse());
                return Response.FromValue(new ClusterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ClusterResource> IEnumerable<ClusterResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ClusterResource> IAsyncEnumerable<ClusterResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
