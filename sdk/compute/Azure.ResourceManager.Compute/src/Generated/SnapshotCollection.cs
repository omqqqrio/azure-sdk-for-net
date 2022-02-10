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

namespace Azure.ResourceManager.Compute
{
    /// <summary> A class representing collection of Snapshot and their operations over its parent. </summary>
    public partial class SnapshotCollection : ArmCollection, IEnumerable<Snapshot>, IAsyncEnumerable<Snapshot>
    {
        private readonly ClientDiagnostics _snapshotClientDiagnostics;
        private readonly SnapshotsRestOperations _snapshotRestClient;

        /// <summary> Initializes a new instance of the <see cref="SnapshotCollection"/> class for mocking. </summary>
        protected SnapshotCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SnapshotCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SnapshotCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _snapshotClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Compute", Snapshot.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(Snapshot.ResourceType, out string snapshotApiVersion);
            _snapshotRestClient = new SnapshotsRestOperations(_snapshotClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, snapshotApiVersion);
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
        /// Creates or updates a snapshot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/snapshots/{snapshotName}
        /// Operation Id: Snapshots_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The max name length is 80 characters. </param>
        /// <param name="snapshot"> Snapshot object supplied in the body of the Put disk operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="snapshotName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="snapshotName"/> or <paramref name="snapshot"/> is null. </exception>
        public async virtual Task<ArmOperation<Snapshot>> CreateOrUpdateAsync(bool waitForCompletion, string snapshotName, SnapshotData snapshot, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));
            if (snapshot == null)
            {
                throw new ArgumentNullException(nameof(snapshot));
            }

            using var scope = _snapshotClientDiagnostics.CreateScope("SnapshotCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _snapshotRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, snapshotName, snapshot, cancellationToken).ConfigureAwait(false);
                var operation = new ComputeArmOperation<Snapshot>(new SnapshotOperationSource(Client), _snapshotClientDiagnostics, Pipeline, _snapshotRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, snapshotName, snapshot).Request, response, OperationFinalStateVia.Location);
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
        /// Creates or updates a snapshot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/snapshots/{snapshotName}
        /// Operation Id: Snapshots_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The max name length is 80 characters. </param>
        /// <param name="snapshot"> Snapshot object supplied in the body of the Put disk operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="snapshotName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="snapshotName"/> or <paramref name="snapshot"/> is null. </exception>
        public virtual ArmOperation<Snapshot> CreateOrUpdate(bool waitForCompletion, string snapshotName, SnapshotData snapshot, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));
            if (snapshot == null)
            {
                throw new ArgumentNullException(nameof(snapshot));
            }

            using var scope = _snapshotClientDiagnostics.CreateScope("SnapshotCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _snapshotRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, snapshotName, snapshot, cancellationToken);
                var operation = new ComputeArmOperation<Snapshot>(new SnapshotOperationSource(Client), _snapshotClientDiagnostics, Pipeline, _snapshotRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, snapshotName, snapshot).Request, response, OperationFinalStateVia.Location);
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
        /// Gets information about a snapshot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/snapshots/{snapshotName}
        /// Operation Id: Snapshots_Get
        /// </summary>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The max name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="snapshotName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="snapshotName"/> is null. </exception>
        public async virtual Task<Response<Snapshot>> GetAsync(string snapshotName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            using var scope = _snapshotClientDiagnostics.CreateScope("SnapshotCollection.Get");
            scope.Start();
            try
            {
                var response = await _snapshotRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, snapshotName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _snapshotClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Snapshot(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets information about a snapshot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/snapshots/{snapshotName}
        /// Operation Id: Snapshots_Get
        /// </summary>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The max name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="snapshotName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="snapshotName"/> is null. </exception>
        public virtual Response<Snapshot> Get(string snapshotName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            using var scope = _snapshotClientDiagnostics.CreateScope("SnapshotCollection.Get");
            scope.Start();
            try
            {
                var response = _snapshotRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, snapshotName, cancellationToken);
                if (response.Value == null)
                    throw _snapshotClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Snapshot(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists snapshots under a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/snapshots
        /// Operation Id: Snapshots_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Snapshot" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Snapshot> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Snapshot>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _snapshotClientDiagnostics.CreateScope("SnapshotCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _snapshotRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Snapshot(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Snapshot>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _snapshotClientDiagnostics.CreateScope("SnapshotCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _snapshotRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Snapshot(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists snapshots under a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/snapshots
        /// Operation Id: Snapshots_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Snapshot" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Snapshot> GetAll(CancellationToken cancellationToken = default)
        {
            Page<Snapshot> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _snapshotClientDiagnostics.CreateScope("SnapshotCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _snapshotRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Snapshot(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Snapshot> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _snapshotClientDiagnostics.CreateScope("SnapshotCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _snapshotRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Snapshot(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/snapshots/{snapshotName}
        /// Operation Id: Snapshots_Get
        /// </summary>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The max name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="snapshotName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="snapshotName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string snapshotName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            using var scope = _snapshotClientDiagnostics.CreateScope("SnapshotCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(snapshotName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/snapshots/{snapshotName}
        /// Operation Id: Snapshots_Get
        /// </summary>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The max name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="snapshotName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="snapshotName"/> is null. </exception>
        public virtual Response<bool> Exists(string snapshotName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            using var scope = _snapshotClientDiagnostics.CreateScope("SnapshotCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(snapshotName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/snapshots/{snapshotName}
        /// Operation Id: Snapshots_Get
        /// </summary>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The max name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="snapshotName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="snapshotName"/> is null. </exception>
        public async virtual Task<Response<Snapshot>> GetIfExistsAsync(string snapshotName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            using var scope = _snapshotClientDiagnostics.CreateScope("SnapshotCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _snapshotRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, snapshotName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<Snapshot>(null, response.GetRawResponse());
                return Response.FromValue(new Snapshot(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/snapshots/{snapshotName}
        /// Operation Id: Snapshots_Get
        /// </summary>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The max name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="snapshotName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="snapshotName"/> is null. </exception>
        public virtual Response<Snapshot> GetIfExists(string snapshotName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            using var scope = _snapshotClientDiagnostics.CreateScope("SnapshotCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _snapshotRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, snapshotName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<Snapshot>(null, response.GetRawResponse());
                return Response.FromValue(new Snapshot(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Snapshot> IEnumerable<Snapshot>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Snapshot> IAsyncEnumerable<Snapshot>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
