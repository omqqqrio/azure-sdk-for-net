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
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing collection of ConnectionMonitor and their operations over its parent. </summary>
    public partial class ConnectionMonitorCollection : ArmCollection, IEnumerable<ConnectionMonitor>, IAsyncEnumerable<ConnectionMonitor>
    {
        private readonly ClientDiagnostics _connectionMonitorClientDiagnostics;
        private readonly ConnectionMonitorsRestOperations _connectionMonitorRestClient;

        /// <summary> Initializes a new instance of the <see cref="ConnectionMonitorCollection"/> class for mocking. </summary>
        protected ConnectionMonitorCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ConnectionMonitorCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ConnectionMonitorCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _connectionMonitorClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ConnectionMonitor.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ConnectionMonitor.ResourceType, out string connectionMonitorApiVersion);
            _connectionMonitorRestClient = new ConnectionMonitorsRestOperations(_connectionMonitorClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, connectionMonitorApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != NetworkWatcher.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, NetworkWatcher.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update a connection monitor.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkWatchers/{networkWatcherName}/connectionMonitors/{connectionMonitorName}
        /// Operation Id: ConnectionMonitors_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="parameters"> Parameters that define the operation to create a connection monitor. </param>
        /// <param name="migrate"> Value indicating whether connection monitor V1 should be migrated to V2 format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="connectionMonitorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionMonitorName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<ConnectionMonitor>> CreateOrUpdateAsync(bool waitForCompletion, string connectionMonitorName, ConnectionMonitorInput parameters, string migrate = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(connectionMonitorName, nameof(connectionMonitorName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _connectionMonitorClientDiagnostics.CreateScope("ConnectionMonitorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _connectionMonitorRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, connectionMonitorName, parameters, migrate, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<ConnectionMonitor>(new ConnectionMonitorOperationSource(Client), _connectionMonitorClientDiagnostics, Pipeline, _connectionMonitorRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, connectionMonitorName, parameters, migrate).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Create or update a connection monitor.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkWatchers/{networkWatcherName}/connectionMonitors/{connectionMonitorName}
        /// Operation Id: ConnectionMonitors_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="parameters"> Parameters that define the operation to create a connection monitor. </param>
        /// <param name="migrate"> Value indicating whether connection monitor V1 should be migrated to V2 format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="connectionMonitorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionMonitorName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ConnectionMonitor> CreateOrUpdate(bool waitForCompletion, string connectionMonitorName, ConnectionMonitorInput parameters, string migrate = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(connectionMonitorName, nameof(connectionMonitorName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _connectionMonitorClientDiagnostics.CreateScope("ConnectionMonitorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _connectionMonitorRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, connectionMonitorName, parameters, migrate, cancellationToken);
                var operation = new NetworkArmOperation<ConnectionMonitor>(new ConnectionMonitorOperationSource(Client), _connectionMonitorClientDiagnostics, Pipeline, _connectionMonitorRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, connectionMonitorName, parameters, migrate).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Gets a connection monitor by name.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkWatchers/{networkWatcherName}/connectionMonitors/{connectionMonitorName}
        /// Operation Id: ConnectionMonitors_Get
        /// </summary>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="connectionMonitorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionMonitorName"/> is null. </exception>
        public async virtual Task<Response<ConnectionMonitor>> GetAsync(string connectionMonitorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(connectionMonitorName, nameof(connectionMonitorName));

            using var scope = _connectionMonitorClientDiagnostics.CreateScope("ConnectionMonitorCollection.Get");
            scope.Start();
            try
            {
                var response = await _connectionMonitorRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, connectionMonitorName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _connectionMonitorClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ConnectionMonitor(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a connection monitor by name.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkWatchers/{networkWatcherName}/connectionMonitors/{connectionMonitorName}
        /// Operation Id: ConnectionMonitors_Get
        /// </summary>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="connectionMonitorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionMonitorName"/> is null. </exception>
        public virtual Response<ConnectionMonitor> Get(string connectionMonitorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(connectionMonitorName, nameof(connectionMonitorName));

            using var scope = _connectionMonitorClientDiagnostics.CreateScope("ConnectionMonitorCollection.Get");
            scope.Start();
            try
            {
                var response = _connectionMonitorRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, connectionMonitorName, cancellationToken);
                if (response.Value == null)
                    throw _connectionMonitorClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ConnectionMonitor(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all connection monitors for the specified Network Watcher.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkWatchers/{networkWatcherName}/connectionMonitors
        /// Operation Id: ConnectionMonitors_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ConnectionMonitor" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ConnectionMonitor> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ConnectionMonitor>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _connectionMonitorClientDiagnostics.CreateScope("ConnectionMonitorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _connectionMonitorRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ConnectionMonitor(Client, value)), null, response.GetRawResponse());
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
        /// Lists all connection monitors for the specified Network Watcher.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkWatchers/{networkWatcherName}/connectionMonitors
        /// Operation Id: ConnectionMonitors_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ConnectionMonitor" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ConnectionMonitor> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ConnectionMonitor> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _connectionMonitorClientDiagnostics.CreateScope("ConnectionMonitorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _connectionMonitorRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ConnectionMonitor(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkWatchers/{networkWatcherName}/connectionMonitors/{connectionMonitorName}
        /// Operation Id: ConnectionMonitors_Get
        /// </summary>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="connectionMonitorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionMonitorName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string connectionMonitorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(connectionMonitorName, nameof(connectionMonitorName));

            using var scope = _connectionMonitorClientDiagnostics.CreateScope("ConnectionMonitorCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(connectionMonitorName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkWatchers/{networkWatcherName}/connectionMonitors/{connectionMonitorName}
        /// Operation Id: ConnectionMonitors_Get
        /// </summary>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="connectionMonitorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionMonitorName"/> is null. </exception>
        public virtual Response<bool> Exists(string connectionMonitorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(connectionMonitorName, nameof(connectionMonitorName));

            using var scope = _connectionMonitorClientDiagnostics.CreateScope("ConnectionMonitorCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(connectionMonitorName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkWatchers/{networkWatcherName}/connectionMonitors/{connectionMonitorName}
        /// Operation Id: ConnectionMonitors_Get
        /// </summary>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="connectionMonitorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionMonitorName"/> is null. </exception>
        public async virtual Task<Response<ConnectionMonitor>> GetIfExistsAsync(string connectionMonitorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(connectionMonitorName, nameof(connectionMonitorName));

            using var scope = _connectionMonitorClientDiagnostics.CreateScope("ConnectionMonitorCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _connectionMonitorRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, connectionMonitorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ConnectionMonitor>(null, response.GetRawResponse());
                return Response.FromValue(new ConnectionMonitor(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkWatchers/{networkWatcherName}/connectionMonitors/{connectionMonitorName}
        /// Operation Id: ConnectionMonitors_Get
        /// </summary>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="connectionMonitorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionMonitorName"/> is null. </exception>
        public virtual Response<ConnectionMonitor> GetIfExists(string connectionMonitorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(connectionMonitorName, nameof(connectionMonitorName));

            using var scope = _connectionMonitorClientDiagnostics.CreateScope("ConnectionMonitorCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _connectionMonitorRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, connectionMonitorName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ConnectionMonitor>(null, response.GetRawResponse());
                return Response.FromValue(new ConnectionMonitor(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ConnectionMonitor> IEnumerable<ConnectionMonitor>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ConnectionMonitor> IAsyncEnumerable<ConnectionMonitor>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
