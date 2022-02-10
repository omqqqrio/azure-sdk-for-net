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
    /// <summary> A class representing collection of DiskAccess and their operations over its parent. </summary>
    public partial class DiskAccessCollection : ArmCollection, IEnumerable<DiskAccess>, IAsyncEnumerable<DiskAccess>
    {
        private readonly ClientDiagnostics _diskAccessClientDiagnostics;
        private readonly DiskAccessesRestOperations _diskAccessRestClient;

        /// <summary> Initializes a new instance of the <see cref="DiskAccessCollection"/> class for mocking. </summary>
        protected DiskAccessCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DiskAccessCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DiskAccessCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _diskAccessClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Compute", DiskAccess.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(DiskAccess.ResourceType, out string diskAccessApiVersion);
            _diskAccessRestClient = new DiskAccessesRestOperations(_diskAccessClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, diskAccessApiVersion);
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
        /// Creates or updates a disk access resource
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}
        /// Operation Id: DiskAccesses_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The maximum name length is 80 characters. </param>
        /// <param name="diskAccess"> disk access object supplied in the body of the Put disk access operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskAccessName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> or <paramref name="diskAccess"/> is null. </exception>
        public async virtual Task<ArmOperation<DiskAccess>> CreateOrUpdateAsync(bool waitForCompletion, string diskAccessName, DiskAccessData diskAccess, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(diskAccessName, nameof(diskAccessName));
            if (diskAccess == null)
            {
                throw new ArgumentNullException(nameof(diskAccess));
            }

            using var scope = _diskAccessClientDiagnostics.CreateScope("DiskAccessCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _diskAccessRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, diskAccessName, diskAccess, cancellationToken).ConfigureAwait(false);
                var operation = new ComputeArmOperation<DiskAccess>(new DiskAccessOperationSource(Client), _diskAccessClientDiagnostics, Pipeline, _diskAccessRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, diskAccessName, diskAccess).Request, response, OperationFinalStateVia.Location);
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
        /// Creates or updates a disk access resource
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}
        /// Operation Id: DiskAccesses_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The maximum name length is 80 characters. </param>
        /// <param name="diskAccess"> disk access object supplied in the body of the Put disk access operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskAccessName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> or <paramref name="diskAccess"/> is null. </exception>
        public virtual ArmOperation<DiskAccess> CreateOrUpdate(bool waitForCompletion, string diskAccessName, DiskAccessData diskAccess, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(diskAccessName, nameof(diskAccessName));
            if (diskAccess == null)
            {
                throw new ArgumentNullException(nameof(diskAccess));
            }

            using var scope = _diskAccessClientDiagnostics.CreateScope("DiskAccessCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _diskAccessRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, diskAccessName, diskAccess, cancellationToken);
                var operation = new ComputeArmOperation<DiskAccess>(new DiskAccessOperationSource(Client), _diskAccessClientDiagnostics, Pipeline, _diskAccessRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, diskAccessName, diskAccess).Request, response, OperationFinalStateVia.Location);
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
        /// Gets information about a disk access resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}
        /// Operation Id: DiskAccesses_Get
        /// </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskAccessName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> is null. </exception>
        public async virtual Task<Response<DiskAccess>> GetAsync(string diskAccessName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(diskAccessName, nameof(diskAccessName));

            using var scope = _diskAccessClientDiagnostics.CreateScope("DiskAccessCollection.Get");
            scope.Start();
            try
            {
                var response = await _diskAccessRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, diskAccessName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _diskAccessClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new DiskAccess(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets information about a disk access resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}
        /// Operation Id: DiskAccesses_Get
        /// </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskAccessName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> is null. </exception>
        public virtual Response<DiskAccess> Get(string diskAccessName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(diskAccessName, nameof(diskAccessName));

            using var scope = _diskAccessClientDiagnostics.CreateScope("DiskAccessCollection.Get");
            scope.Start();
            try
            {
                var response = _diskAccessRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, diskAccessName, cancellationToken);
                if (response.Value == null)
                    throw _diskAccessClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DiskAccess(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all the disk access resources under a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses
        /// Operation Id: DiskAccesses_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DiskAccess" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DiskAccess> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DiskAccess>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _diskAccessClientDiagnostics.CreateScope("DiskAccessCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _diskAccessRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DiskAccess(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DiskAccess>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _diskAccessClientDiagnostics.CreateScope("DiskAccessCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _diskAccessRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DiskAccess(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all the disk access resources under a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses
        /// Operation Id: DiskAccesses_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DiskAccess" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DiskAccess> GetAll(CancellationToken cancellationToken = default)
        {
            Page<DiskAccess> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _diskAccessClientDiagnostics.CreateScope("DiskAccessCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _diskAccessRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DiskAccess(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DiskAccess> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _diskAccessClientDiagnostics.CreateScope("DiskAccessCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _diskAccessRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DiskAccess(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}
        /// Operation Id: DiskAccesses_Get
        /// </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskAccessName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string diskAccessName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(diskAccessName, nameof(diskAccessName));

            using var scope = _diskAccessClientDiagnostics.CreateScope("DiskAccessCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(diskAccessName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}
        /// Operation Id: DiskAccesses_Get
        /// </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskAccessName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> is null. </exception>
        public virtual Response<bool> Exists(string diskAccessName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(diskAccessName, nameof(diskAccessName));

            using var scope = _diskAccessClientDiagnostics.CreateScope("DiskAccessCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(diskAccessName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}
        /// Operation Id: DiskAccesses_Get
        /// </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskAccessName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> is null. </exception>
        public async virtual Task<Response<DiskAccess>> GetIfExistsAsync(string diskAccessName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(diskAccessName, nameof(diskAccessName));

            using var scope = _diskAccessClientDiagnostics.CreateScope("DiskAccessCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _diskAccessRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, diskAccessName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<DiskAccess>(null, response.GetRawResponse());
                return Response.FromValue(new DiskAccess(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}
        /// Operation Id: DiskAccesses_Get
        /// </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskAccessName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> is null. </exception>
        public virtual Response<DiskAccess> GetIfExists(string diskAccessName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(diskAccessName, nameof(diskAccessName));

            using var scope = _diskAccessClientDiagnostics.CreateScope("DiskAccessCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _diskAccessRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, diskAccessName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<DiskAccess>(null, response.GetRawResponse());
                return Response.FromValue(new DiskAccess(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DiskAccess> IEnumerable<DiskAccess>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DiskAccess> IAsyncEnumerable<DiskAccess>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
