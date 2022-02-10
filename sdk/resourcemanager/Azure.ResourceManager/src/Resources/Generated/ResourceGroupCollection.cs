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

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class representing collection of ResourceGroup and their operations over its parent. </summary>
    public partial class ResourceGroupCollection : ArmCollection, IEnumerable<ResourceGroup>, IAsyncEnumerable<ResourceGroup>
    {
        private readonly ClientDiagnostics _resourceGroupClientDiagnostics;
        private readonly ResourceGroupsRestOperations _resourceGroupRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupCollection"/> class for mocking. </summary>
        protected ResourceGroupCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ResourceGroupCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _resourceGroupClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ResourceGroup.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceGroup.ResourceType, out string resourceGroupApiVersion);
            _resourceGroupRestClient = new ResourceGroupsRestOperations(_resourceGroupClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, resourceGroupApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Subscription.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Subscription.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}
        /// Operation Id: ResourceGroups_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="resourceGroupName"> The name of the resource group to create or update. Can include alphanumeric, underscore, parentheses, hyphen, period (except at end), and Unicode characters that match the allowed characters. </param>
        /// <param name="parameters"> Parameters supplied to the create or update a resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceGroupName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<ResourceGroup>> CreateOrUpdateAsync(bool waitForCompletion, string resourceGroupName, ResourceGroupData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resourceGroupRestClient.CreateOrUpdateAsync(Id.SubscriptionId, resourceGroupName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ResourcesArmOperation<ResourceGroup>(Response.FromValue(new ResourceGroup(Client, response), response.GetRawResponse()));
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
        /// Creates or updates a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}
        /// Operation Id: ResourceGroups_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="resourceGroupName"> The name of the resource group to create or update. Can include alphanumeric, underscore, parentheses, hyphen, period (except at end), and Unicode characters that match the allowed characters. </param>
        /// <param name="parameters"> Parameters supplied to the create or update a resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceGroupName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ResourceGroup> CreateOrUpdate(bool waitForCompletion, string resourceGroupName, ResourceGroupData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resourceGroupRestClient.CreateOrUpdate(Id.SubscriptionId, resourceGroupName, parameters, cancellationToken);
                var operation = new ResourcesArmOperation<ResourceGroup>(Response.FromValue(new ResourceGroup(Client, response), response.GetRawResponse()));
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
        /// Gets a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}
        /// Operation Id: ResourceGroups_Get
        /// </summary>
        /// <param name="resourceGroupName"> The name of the resource group to get. The name is case insensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceGroupName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> is null. </exception>
        public async virtual Task<Response<ResourceGroup>> GetAsync(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupCollection.Get");
            scope.Start();
            try
            {
                var response = await _resourceGroupRestClient.GetAsync(Id.SubscriptionId, resourceGroupName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _resourceGroupClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ResourceGroup(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}
        /// Operation Id: ResourceGroups_Get
        /// </summary>
        /// <param name="resourceGroupName"> The name of the resource group to get. The name is case insensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceGroupName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> is null. </exception>
        public virtual Response<ResourceGroup> Get(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupCollection.Get");
            scope.Start();
            try
            {
                var response = _resourceGroupRestClient.Get(Id.SubscriptionId, resourceGroupName, cancellationToken);
                if (response.Value == null)
                    throw _resourceGroupClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResourceGroup(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all the resource groups for a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups
        /// Operation Id: ResourceGroups_List
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation.&lt;br&gt;&lt;br&gt;You can filter by tag names and values. For example, to filter for a tag name and value, use $filter=tagName eq &apos;tag1&apos; and tagValue eq &apos;Value1&apos;. </param>
        /// <param name="top"> The number of results to return. If null is passed, returns all resource groups. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResourceGroup" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResourceGroup> GetAllAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ResourceGroup>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _resourceGroupRestClient.ListAsync(Id.SubscriptionId, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResourceGroup(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ResourceGroup>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _resourceGroupRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResourceGroup(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all the resource groups for a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups
        /// Operation Id: ResourceGroups_List
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation.&lt;br&gt;&lt;br&gt;You can filter by tag names and values. For example, to filter for a tag name and value, use $filter=tagName eq &apos;tag1&apos; and tagValue eq &apos;Value1&apos;. </param>
        /// <param name="top"> The number of results to return. If null is passed, returns all resource groups. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceGroup" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResourceGroup> GetAll(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<ResourceGroup> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _resourceGroupRestClient.List(Id.SubscriptionId, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResourceGroup(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ResourceGroup> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _resourceGroupRestClient.ListNextPage(nextLink, Id.SubscriptionId, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResourceGroup(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}
        /// Operation Id: ResourceGroups_Get
        /// </summary>
        /// <param name="resourceGroupName"> The name of the resource group to get. The name is case insensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceGroupName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(resourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}
        /// Operation Id: ResourceGroups_Get
        /// </summary>
        /// <param name="resourceGroupName"> The name of the resource group to get. The name is case insensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceGroupName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> is null. </exception>
        public virtual Response<bool> Exists(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(resourceGroupName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}
        /// Operation Id: ResourceGroups_Get
        /// </summary>
        /// <param name="resourceGroupName"> The name of the resource group to get. The name is case insensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceGroupName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> is null. </exception>
        public async virtual Task<Response<ResourceGroup>> GetIfExistsAsync(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _resourceGroupRestClient.GetAsync(Id.SubscriptionId, resourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ResourceGroup>(null, response.GetRawResponse());
                return Response.FromValue(new ResourceGroup(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}
        /// Operation Id: ResourceGroups_Get
        /// </summary>
        /// <param name="resourceGroupName"> The name of the resource group to get. The name is case insensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceGroupName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> is null. </exception>
        public virtual Response<ResourceGroup> GetIfExists(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            using var scope = _resourceGroupClientDiagnostics.CreateScope("ResourceGroupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _resourceGroupRestClient.Get(Id.SubscriptionId, resourceGroupName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ResourceGroup>(null, response.GetRawResponse());
                return Response.FromValue(new ResourceGroup(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ResourceGroup> IEnumerable<ResourceGroup>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ResourceGroup> IAsyncEnumerable<ResourceGroup>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
