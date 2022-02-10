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

namespace Azure.ResourceManager.ServiceBus
{
    /// <summary> A class representing collection of ServiceBusAuthorizationRule and their operations over its parent. </summary>
    public partial class NamespaceTopicAuthorizationRuleCollection : ArmCollection, IEnumerable<NamespaceTopicAuthorizationRule>, IAsyncEnumerable<NamespaceTopicAuthorizationRule>
    {
        private readonly ClientDiagnostics _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics;
        private readonly TopicAuthorizationRulesRestOperations _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient;

        /// <summary> Initializes a new instance of the <see cref="NamespaceTopicAuthorizationRuleCollection"/> class for mocking. </summary>
        protected NamespaceTopicAuthorizationRuleCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="NamespaceTopicAuthorizationRuleCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal NamespaceTopicAuthorizationRuleCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ServiceBus", NamespaceTopicAuthorizationRule.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(NamespaceTopicAuthorizationRule.ResourceType, out string namespaceTopicAuthorizationRuleTopicAuthorizationRulesApiVersion);
            _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient = new TopicAuthorizationRulesRestOperations(_namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, namespaceTopicAuthorizationRuleTopicAuthorizationRulesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ServiceBusTopic.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ServiceBusTopic.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates an authorization rule for the specified topic.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}
        /// Operation Id: TopicAuthorizationRules_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="parameters"> The shared access authorization rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<NamespaceTopicAuthorizationRule>> CreateOrUpdateAsync(bool waitForCompletion, string authorizationRuleName, ServiceBusAuthorizationRuleData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(authorizationRuleName, nameof(authorizationRuleName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, authorizationRuleName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ServiceBusArmOperation<NamespaceTopicAuthorizationRule>(Response.FromValue(new NamespaceTopicAuthorizationRule(Client, response), response.GetRawResponse()));
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
        /// Creates an authorization rule for the specified topic.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}
        /// Operation Id: TopicAuthorizationRules_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="parameters"> The shared access authorization rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<NamespaceTopicAuthorizationRule> CreateOrUpdate(bool waitForCompletion, string authorizationRuleName, ServiceBusAuthorizationRuleData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(authorizationRuleName, nameof(authorizationRuleName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, authorizationRuleName, parameters, cancellationToken);
                var operation = new ServiceBusArmOperation<NamespaceTopicAuthorizationRule>(Response.FromValue(new NamespaceTopicAuthorizationRule(Client, response), response.GetRawResponse()));
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
        /// Returns the specified authorization rule.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}
        /// Operation Id: TopicAuthorizationRules_Get
        /// </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> is null. </exception>
        public async virtual Task<Response<NamespaceTopicAuthorizationRule>> GetAsync(string authorizationRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(authorizationRuleName, nameof(authorizationRuleName));

            using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.Get");
            scope.Start();
            try
            {
                var response = await _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, authorizationRuleName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new NamespaceTopicAuthorizationRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns the specified authorization rule.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}
        /// Operation Id: TopicAuthorizationRules_Get
        /// </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> is null. </exception>
        public virtual Response<NamespaceTopicAuthorizationRule> Get(string authorizationRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(authorizationRuleName, nameof(authorizationRuleName));

            using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.Get");
            scope.Start();
            try
            {
                var response = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, authorizationRuleName, cancellationToken);
                if (response.Value == null)
                    throw _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NamespaceTopicAuthorizationRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets authorization rules for a topic.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules
        /// Operation Id: TopicAuthorizationRules_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NamespaceTopicAuthorizationRule" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NamespaceTopicAuthorizationRule> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<NamespaceTopicAuthorizationRule>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new NamespaceTopicAuthorizationRule(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<NamespaceTopicAuthorizationRule>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new NamespaceTopicAuthorizationRule(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets authorization rules for a topic.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules
        /// Operation Id: TopicAuthorizationRules_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NamespaceTopicAuthorizationRule" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NamespaceTopicAuthorizationRule> GetAll(CancellationToken cancellationToken = default)
        {
            Page<NamespaceTopicAuthorizationRule> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new NamespaceTopicAuthorizationRule(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<NamespaceTopicAuthorizationRule> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new NamespaceTopicAuthorizationRule(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}
        /// Operation Id: TopicAuthorizationRules_Get
        /// </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string authorizationRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(authorizationRuleName, nameof(authorizationRuleName));

            using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(authorizationRuleName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}
        /// Operation Id: TopicAuthorizationRules_Get
        /// </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> is null. </exception>
        public virtual Response<bool> Exists(string authorizationRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(authorizationRuleName, nameof(authorizationRuleName));

            using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(authorizationRuleName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}
        /// Operation Id: TopicAuthorizationRules_Get
        /// </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> is null. </exception>
        public async virtual Task<Response<NamespaceTopicAuthorizationRule>> GetIfExistsAsync(string authorizationRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(authorizationRuleName, nameof(authorizationRuleName));

            using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, authorizationRuleName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<NamespaceTopicAuthorizationRule>(null, response.GetRawResponse());
                return Response.FromValue(new NamespaceTopicAuthorizationRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}
        /// Operation Id: TopicAuthorizationRules_Get
        /// </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> is null. </exception>
        public virtual Response<NamespaceTopicAuthorizationRule> GetIfExists(string authorizationRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(authorizationRuleName, nameof(authorizationRuleName));

            using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, authorizationRuleName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<NamespaceTopicAuthorizationRule>(null, response.GetRawResponse());
                return Response.FromValue(new NamespaceTopicAuthorizationRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<NamespaceTopicAuthorizationRule> IEnumerable<NamespaceTopicAuthorizationRule>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<NamespaceTopicAuthorizationRule> IAsyncEnumerable<NamespaceTopicAuthorizationRule>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
