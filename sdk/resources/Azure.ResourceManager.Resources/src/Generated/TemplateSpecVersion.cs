// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A Class representing a TemplateSpecVersion along with the instance operations that can be performed on it. </summary>
    public partial class TemplateSpecVersion : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="TemplateSpecVersion"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string templateSpecName, string templateSpecVersion)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}/versions/{templateSpecVersion}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _templateSpecVersionClientDiagnostics;
        private readonly TemplateSpecVersionsRestOperations _templateSpecVersionRestClient;
        private readonly TemplateSpecVersionData _data;

        /// <summary> Initializes a new instance of the <see cref="TemplateSpecVersion"/> class for mocking. </summary>
        protected TemplateSpecVersion()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "TemplateSpecVersion"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal TemplateSpecVersion(ArmClient client, TemplateSpecVersionData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="TemplateSpecVersion"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal TemplateSpecVersion(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _templateSpecVersionClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string templateSpecVersionApiVersion);
            _templateSpecVersionRestClient = new TemplateSpecVersionsRestOperations(_templateSpecVersionClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, templateSpecVersionApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Resources/templateSpecs/versions";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual TemplateSpecVersionData Data
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
        /// Gets a Template Spec version from a specific Template Spec.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}/versions/{templateSpecVersion}
        /// Operation Id: TemplateSpecVersions_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<TemplateSpecVersion>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _templateSpecVersionClientDiagnostics.CreateScope("TemplateSpecVersion.Get");
            scope.Start();
            try
            {
                var response = await _templateSpecVersionRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _templateSpecVersionClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new TemplateSpecVersion(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a Template Spec version from a specific Template Spec.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}/versions/{templateSpecVersion}
        /// Operation Id: TemplateSpecVersions_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TemplateSpecVersion> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _templateSpecVersionClientDiagnostics.CreateScope("TemplateSpecVersion.Get");
            scope.Start();
            try
            {
                var response = _templateSpecVersionRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _templateSpecVersionClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TemplateSpecVersion(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a specific version from a Template Spec. When operation completes, status code 200 returned without content.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}/versions/{templateSpecVersion}
        /// Operation Id: TemplateSpecVersions_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _templateSpecVersionClientDiagnostics.CreateScope("TemplateSpecVersion.Delete");
            scope.Start();
            try
            {
                var response = await _templateSpecVersionRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new ResourcesArmOperation(response);
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
        /// Deletes a specific version from a Template Spec. When operation completes, status code 200 returned without content.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}/versions/{templateSpecVersion}
        /// Operation Id: TemplateSpecVersions_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _templateSpecVersionClientDiagnostics.CreateScope("TemplateSpecVersion.Delete");
            scope.Start();
            try
            {
                var response = _templateSpecVersionRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new ResourcesArmOperation(response);
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

        /// <summary>
        /// Updates Template Spec Version tags with specified values.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}/versions/{templateSpecVersion}
        /// Operation Id: TemplateSpecVersions_Update
        /// </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<TemplateSpecVersion>> UpdateAsync(IDictionary<string, string> tags = null, CancellationToken cancellationToken = default)
        {
            using var scope = _templateSpecVersionClientDiagnostics.CreateScope("TemplateSpecVersion.Update");
            scope.Start();
            try
            {
                var response = await _templateSpecVersionRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, tags, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new TemplateSpecVersion(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates Template Spec Version tags with specified values.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}/versions/{templateSpecVersion}
        /// Operation Id: TemplateSpecVersions_Update
        /// </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TemplateSpecVersion> Update(IDictionary<string, string> tags = null, CancellationToken cancellationToken = default)
        {
            using var scope = _templateSpecVersionClientDiagnostics.CreateScope("TemplateSpecVersion.Update");
            scope.Start();
            try
            {
                var response = _templateSpecVersionRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, tags, cancellationToken);
                return Response.FromValue(new TemplateSpecVersion(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
