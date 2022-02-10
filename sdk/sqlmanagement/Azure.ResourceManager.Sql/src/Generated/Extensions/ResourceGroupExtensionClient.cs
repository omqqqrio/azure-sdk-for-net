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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    internal partial class ResourceGroupExtensionClient : ArmResource
    {
        private ClientDiagnostics _longTermRetentionBackupsClientDiagnostics;
        private LongTermRetentionBackupsRestOperations _longTermRetentionBackupsRestClient;
        private ClientDiagnostics _longTermRetentionManagedInstanceBackupsClientDiagnostics;
        private LongTermRetentionManagedInstanceBackupsRestOperations _longTermRetentionManagedInstanceBackupsRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupExtensionClient"/> class for mocking. </summary>
        protected ResourceGroupExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceGroupExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics LongTermRetentionBackupsClientDiagnostics => _longTermRetentionBackupsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Sql", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
        private LongTermRetentionBackupsRestOperations LongTermRetentionBackupsRestClient => _longTermRetentionBackupsRestClient ??= new LongTermRetentionBackupsRestOperations(LongTermRetentionBackupsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri);
        private ClientDiagnostics LongTermRetentionManagedInstanceBackupsClientDiagnostics => _longTermRetentionManagedInstanceBackupsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Sql", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
        private LongTermRetentionManagedInstanceBackupsRestOperations LongTermRetentionManagedInstanceBackupsRestClient => _longTermRetentionManagedInstanceBackupsRestClient ??= new LongTermRetentionManagedInstanceBackupsRestOperations(LongTermRetentionManagedInstanceBackupsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            Client.TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of InstanceFailoverGroups in the InstanceFailoverGroup. </summary>
        /// <param name="locationName"> The name of the region where the resource is located. </param>
        /// <returns> An object representing collection of InstanceFailoverGroups and their operations over a InstanceFailoverGroup. </returns>
        public virtual InstanceFailoverGroupCollection GetInstanceFailoverGroups(string locationName)
        {
            return new InstanceFailoverGroupCollection(Client, Id, locationName);
        }

        /// <summary> Gets a collection of InstancePools in the InstancePool. </summary>
        /// <returns> An object representing collection of InstancePools and their operations over a InstancePool. </returns>
        public virtual InstancePoolCollection GetInstancePools()
        {
            return new InstancePoolCollection(Client, Id);
        }

        /// <summary> Gets a collection of ResourceGroupLongTermRetentionBackups in the ResourceGroupLongTermRetentionBackup. </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="longTermRetentionServerName"> The name of the server. </param>
        /// <param name="longTermRetentionDatabaseName"> The name of the database. </param>
        /// <returns> An object representing collection of ResourceGroupLongTermRetentionBackups and their operations over a ResourceGroupLongTermRetentionBackup. </returns>
        public virtual ResourceGroupLongTermRetentionBackupCollection GetResourceGroupLongTermRetentionBackups(string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName)
        {
            return new ResourceGroupLongTermRetentionBackupCollection(Client, Id, locationName, longTermRetentionServerName, longTermRetentionDatabaseName);
        }

        /// <summary> Gets a collection of ResourceGroupLongTermRetentionManagedInstanceBackups in the ResourceGroupLongTermRetentionManagedInstanceBackup. </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="managedInstanceName"> The name of the managed instance. </param>
        /// <param name="databaseName"> The name of the managed database. </param>
        /// <returns> An object representing collection of ResourceGroupLongTermRetentionManagedInstanceBackups and their operations over a ResourceGroupLongTermRetentionManagedInstanceBackup. </returns>
        public virtual ResourceGroupLongTermRetentionManagedInstanceBackupCollection GetResourceGroupLongTermRetentionManagedInstanceBackups(string locationName, string managedInstanceName, string databaseName)
        {
            return new ResourceGroupLongTermRetentionManagedInstanceBackupCollection(Client, Id, locationName, managedInstanceName, databaseName);
        }

        /// <summary> Gets a collection of ManagedInstances in the ManagedInstance. </summary>
        /// <returns> An object representing collection of ManagedInstances and their operations over a ManagedInstance. </returns>
        public virtual ManagedInstanceCollection GetManagedInstances()
        {
            return new ManagedInstanceCollection(Client, Id);
        }

        /// <summary> Gets a collection of ServerTrustGroups in the ServerTrustGroup. </summary>
        /// <param name="locationName"> The name of the region where the resource is located. </param>
        /// <returns> An object representing collection of ServerTrustGroups and their operations over a ServerTrustGroup. </returns>
        public virtual ServerTrustGroupCollection GetServerTrustGroups(string locationName)
        {
            return new ServerTrustGroupCollection(Client, Id, locationName);
        }

        /// <summary> Gets a collection of VirtualClusters in the VirtualCluster. </summary>
        /// <returns> An object representing collection of VirtualClusters and their operations over a VirtualCluster. </returns>
        public virtual VirtualClusterCollection GetVirtualClusters()
        {
            return new VirtualClusterCollection(Client, Id);
        }

        /// <summary> Gets a collection of SqlServers in the SqlServer. </summary>
        /// <returns> An object representing collection of SqlServers and their operations over a SqlServer. </returns>
        public virtual SqlServerCollection GetSqlServers()
        {
            return new SqlServerCollection(Client, Id);
        }

        /// <summary>
        /// Lists the long term retention backups for a given location.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionBackups
        /// Operation Id: LongTermRetentionBackups_ListByResourceGroupLocation
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionBackup" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubscriptionLongTermRetentionBackup> GetLongTermRetentionBackupsByResourceGroupLocationAsync(string locationName, bool? onlyLatestPerDatabase = null, DatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SubscriptionLongTermRetentionBackup>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetLongTermRetentionBackupsByResourceGroupLocation");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionBackupsRestClient.ListByResourceGroupLocationAsync(Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionBackup(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SubscriptionLongTermRetentionBackup>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetLongTermRetentionBackupsByResourceGroupLocation");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionBackupsRestClient.ListByResourceGroupLocationNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionBackup(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the long term retention backups for a given location.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionBackups
        /// Operation Id: LongTermRetentionBackups_ListByResourceGroupLocation
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionBackup" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubscriptionLongTermRetentionBackup> GetLongTermRetentionBackupsByResourceGroupLocation(string locationName, bool? onlyLatestPerDatabase = null, DatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            Page<SubscriptionLongTermRetentionBackup> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetLongTermRetentionBackupsByResourceGroupLocation");
                scope.Start();
                try
                {
                    var response = LongTermRetentionBackupsRestClient.ListByResourceGroupLocation(Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionBackup(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SubscriptionLongTermRetentionBackup> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetLongTermRetentionBackupsByResourceGroupLocation");
                scope.Start();
                try
                {
                    var response = LongTermRetentionBackupsRestClient.ListByResourceGroupLocationNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionBackup(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the long term retention backups for a given server.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionBackups
        /// Operation Id: LongTermRetentionBackups_ListByResourceGroupServer
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="longTermRetentionServerName"> The name of the server. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionBackup" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubscriptionLongTermRetentionBackup> GetLongTermRetentionBackupsByResourceGroupServerAsync(string locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = null, DatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SubscriptionLongTermRetentionBackup>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetLongTermRetentionBackupsByResourceGroupServer");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionBackupsRestClient.ListByResourceGroupServerAsync(Id.SubscriptionId, Id.ResourceGroupName, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionBackup(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SubscriptionLongTermRetentionBackup>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetLongTermRetentionBackupsByResourceGroupServer");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionBackupsRestClient.ListByResourceGroupServerNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionBackup(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the long term retention backups for a given server.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionBackups
        /// Operation Id: LongTermRetentionBackups_ListByResourceGroupServer
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="longTermRetentionServerName"> The name of the server. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionBackup" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubscriptionLongTermRetentionBackup> GetLongTermRetentionBackupsByResourceGroupServer(string locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = null, DatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            Page<SubscriptionLongTermRetentionBackup> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetLongTermRetentionBackupsByResourceGroupServer");
                scope.Start();
                try
                {
                    var response = LongTermRetentionBackupsRestClient.ListByResourceGroupServer(Id.SubscriptionId, Id.ResourceGroupName, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionBackup(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SubscriptionLongTermRetentionBackup> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = LongTermRetentionBackupsClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetLongTermRetentionBackupsByResourceGroupServer");
                scope.Start();
                try
                {
                    var response = LongTermRetentionBackupsRestClient.ListByResourceGroupServerNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, longTermRetentionServerName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionBackup(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the long term retention backups for a given managed instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionManagedInstanceBackups
        /// Operation Id: LongTermRetentionManagedInstanceBackups_ListByResourceGroupInstance
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="managedInstanceName"> The name of the managed instance. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackup" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubscriptionLongTermRetentionManagedInstanceBackup> GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstanceAsync(string locationName, string managedInstanceName, bool? onlyLatestPerDatabase = null, DatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SubscriptionLongTermRetentionManagedInstanceBackup>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionManagedInstanceBackupsRestClient.ListByResourceGroupInstanceAsync(Id.SubscriptionId, Id.ResourceGroupName, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionManagedInstanceBackup(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SubscriptionLongTermRetentionManagedInstanceBackup>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionManagedInstanceBackupsRestClient.ListByResourceGroupInstanceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionManagedInstanceBackup(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the long term retention backups for a given managed instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionManagedInstanceBackups
        /// Operation Id: LongTermRetentionManagedInstanceBackups_ListByResourceGroupInstance
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="managedInstanceName"> The name of the managed instance. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackup" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubscriptionLongTermRetentionManagedInstanceBackup> GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance(string locationName, string managedInstanceName, bool? onlyLatestPerDatabase = null, DatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            Page<SubscriptionLongTermRetentionManagedInstanceBackup> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance");
                scope.Start();
                try
                {
                    var response = LongTermRetentionManagedInstanceBackupsRestClient.ListByResourceGroupInstance(Id.SubscriptionId, Id.ResourceGroupName, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionManagedInstanceBackup(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SubscriptionLongTermRetentionManagedInstanceBackup> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance");
                scope.Start();
                try
                {
                    var response = LongTermRetentionManagedInstanceBackupsRestClient.ListByResourceGroupInstanceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, managedInstanceName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionManagedInstanceBackup(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the long term retention backups for managed databases in a given location.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstanceBackups
        /// Operation Id: LongTermRetentionManagedInstanceBackups_ListByResourceGroupLocation
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackup" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubscriptionLongTermRetentionManagedInstanceBackup> GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocationAsync(string locationName, bool? onlyLatestPerDatabase = null, DatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SubscriptionLongTermRetentionManagedInstanceBackup>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocation");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionManagedInstanceBackupsRestClient.ListByResourceGroupLocationAsync(Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionManagedInstanceBackup(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SubscriptionLongTermRetentionManagedInstanceBackup>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocation");
                scope.Start();
                try
                {
                    var response = await LongTermRetentionManagedInstanceBackupsRestClient.ListByResourceGroupLocationNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionManagedInstanceBackup(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the long term retention backups for managed databases in a given location.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstanceBackups
        /// Operation Id: LongTermRetentionManagedInstanceBackups_ListByResourceGroupLocation
        /// </summary>
        /// <param name="locationName"> The location of the database. </param>
        /// <param name="onlyLatestPerDatabase"> Whether or not to only get the latest backup for each database. </param>
        /// <param name="databaseState"> Whether to query against just live databases, just deleted databases, or all databases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionLongTermRetentionManagedInstanceBackup" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubscriptionLongTermRetentionManagedInstanceBackup> GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocation(string locationName, bool? onlyLatestPerDatabase = null, DatabaseState? databaseState = null, CancellationToken cancellationToken = default)
        {
            Page<SubscriptionLongTermRetentionManagedInstanceBackup> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocation");
                scope.Start();
                try
                {
                    var response = LongTermRetentionManagedInstanceBackupsRestClient.ListByResourceGroupLocation(Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionManagedInstanceBackup(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SubscriptionLongTermRetentionManagedInstanceBackup> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = LongTermRetentionManagedInstanceBackupsClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocation");
                scope.Start();
                try
                {
                    var response = LongTermRetentionManagedInstanceBackupsRestClient.ListByResourceGroupLocationNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, locationName, onlyLatestPerDatabase, databaseState, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionLongTermRetentionManagedInstanceBackup(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
