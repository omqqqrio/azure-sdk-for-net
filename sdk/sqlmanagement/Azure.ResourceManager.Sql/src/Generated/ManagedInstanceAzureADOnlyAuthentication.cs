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
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A Class representing a ManagedInstanceAzureADOnlyAuthentication along with the instance operations that can be performed on it. </summary>
    public partial class ManagedInstanceAzureADOnlyAuthentication : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ManagedInstanceAzureADOnlyAuthentication"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string authenticationName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/azureADOnlyAuthentications/{authenticationName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _managedInstanceAzureADOnlyAuthenticationClientDiagnostics;
        private readonly ManagedInstanceAzureADOnlyAuthenticationsRestOperations _managedInstanceAzureADOnlyAuthenticationRestClient;
        private readonly ManagedInstanceAzureADOnlyAuthenticationData _data;

        /// <summary> Initializes a new instance of the <see cref="ManagedInstanceAzureADOnlyAuthentication"/> class for mocking. </summary>
        protected ManagedInstanceAzureADOnlyAuthentication()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ManagedInstanceAzureADOnlyAuthentication"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ManagedInstanceAzureADOnlyAuthentication(ArmClient client, ManagedInstanceAzureADOnlyAuthenticationData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ManagedInstanceAzureADOnlyAuthentication"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ManagedInstanceAzureADOnlyAuthentication(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _managedInstanceAzureADOnlyAuthenticationClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string managedInstanceAzureADOnlyAuthenticationApiVersion);
            _managedInstanceAzureADOnlyAuthenticationRestClient = new ManagedInstanceAzureADOnlyAuthenticationsRestOperations(_managedInstanceAzureADOnlyAuthenticationClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, managedInstanceAzureADOnlyAuthenticationApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Sql/managedInstances/azureADOnlyAuthentications";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ManagedInstanceAzureADOnlyAuthenticationData Data
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

        /// <summary>
        /// Gets a specific Azure Active Directory only authentication property.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/azureADOnlyAuthentications/{authenticationName}
        /// Operation Id: ManagedInstanceAzureADOnlyAuthentications_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ManagedInstanceAzureADOnlyAuthentication>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _managedInstanceAzureADOnlyAuthenticationClientDiagnostics.CreateScope("ManagedInstanceAzureADOnlyAuthentication.Get");
            scope.Start();
            try
            {
                var response = await _managedInstanceAzureADOnlyAuthenticationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _managedInstanceAzureADOnlyAuthenticationClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ManagedInstanceAzureADOnlyAuthentication(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a specific Azure Active Directory only authentication property.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/azureADOnlyAuthentications/{authenticationName}
        /// Operation Id: ManagedInstanceAzureADOnlyAuthentications_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManagedInstanceAzureADOnlyAuthentication> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _managedInstanceAzureADOnlyAuthenticationClientDiagnostics.CreateScope("ManagedInstanceAzureADOnlyAuthentication.Get");
            scope.Start();
            try
            {
                var response = _managedInstanceAzureADOnlyAuthenticationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _managedInstanceAzureADOnlyAuthenticationClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagedInstanceAzureADOnlyAuthentication(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing server Active Directory only authentication property.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/azureADOnlyAuthentications/{authenticationName}
        /// Operation Id: ManagedInstanceAzureADOnlyAuthentications_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _managedInstanceAzureADOnlyAuthenticationClientDiagnostics.CreateScope("ManagedInstanceAzureADOnlyAuthentication.Delete");
            scope.Start();
            try
            {
                var response = await _managedInstanceAzureADOnlyAuthenticationRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation(_managedInstanceAzureADOnlyAuthenticationClientDiagnostics, Pipeline, _managedInstanceAzureADOnlyAuthenticationRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing server Active Directory only authentication property.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/azureADOnlyAuthentications/{authenticationName}
        /// Operation Id: ManagedInstanceAzureADOnlyAuthentications_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _managedInstanceAzureADOnlyAuthenticationClientDiagnostics.CreateScope("ManagedInstanceAzureADOnlyAuthentication.Delete");
            scope.Start();
            try
            {
                var response = _managedInstanceAzureADOnlyAuthenticationRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SqlArmOperation(_managedInstanceAzureADOnlyAuthenticationClientDiagnostics, Pipeline, _managedInstanceAzureADOnlyAuthenticationRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
