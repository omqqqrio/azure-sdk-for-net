// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.AppService
{
    /// <summary> A Class representing a SiteSlotInstance along with the instance operations that can be performed on it. </summary>
    public partial class SiteSlotInstance : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SiteSlotInstance"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string instanceId)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _siteSlotInstanceWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteSlotInstanceWebAppsRestClient;
        private readonly WebSiteInstanceStatusData _data;

        /// <summary> Initializes a new instance of the <see cref="SiteSlotInstance"/> class for mocking. </summary>
        protected SiteSlotInstance()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SiteSlotInstance"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SiteSlotInstance(ArmClient client, WebSiteInstanceStatusData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SiteSlotInstance"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SiteSlotInstance(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteSlotInstanceWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string siteSlotInstanceWebAppsApiVersion);
            _siteSlotInstanceWebAppsRestClient = new WebAppsRestOperations(_siteSlotInstanceWebAppsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteSlotInstanceWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Web/sites/slots/instances";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual WebSiteInstanceStatusData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets an object representing a SiteSlotInstanceExtension along with the instance operations that can be performed on it in the SiteSlotInstance. </summary>
        /// <returns> Returns a <see cref="SiteSlotInstanceExtension" /> object. </returns>
        public virtual SiteSlotInstanceExtension GetSiteSlotInstanceExtension()
        {
            return new SiteSlotInstanceExtension(Client, new ResourceIdentifier(Id.ToString() + "/extensions/MSDeploy"));
        }

        /// <summary> Gets a collection of SiteSlotInstanceProcesses in the SiteSlotInstanceProcess. </summary>
        /// <returns> An object representing collection of SiteSlotInstanceProcesses and their operations over a SiteSlotInstanceProcess. </returns>
        public virtual SiteSlotInstanceProcessCollection GetSiteSlotInstanceProcesses()
        {
            return new SiteSlotInstanceProcessCollection(Client, Id);
        }

        /// <summary>
        /// Description for Gets all scale-out instances of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}
        /// Operation Id: WebApps_GetInstanceInfoSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<SiteSlotInstance>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotInstanceWebAppsClientDiagnostics.CreateScope("SiteSlotInstance.Get");
            scope.Start();
            try
            {
                var response = await _siteSlotInstanceWebAppsRestClient.GetInstanceInfoSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _siteSlotInstanceWebAppsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SiteSlotInstance(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets all scale-out instances of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}
        /// Operation Id: WebApps_GetInstanceInfoSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SiteSlotInstance> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotInstanceWebAppsClientDiagnostics.CreateScope("SiteSlotInstance.Get");
            scope.Start();
            try
            {
                var response = _siteSlotInstanceWebAppsRestClient.GetInstanceInfoSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _siteSlotInstanceWebAppsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotInstance(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
