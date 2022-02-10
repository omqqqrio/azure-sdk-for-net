// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Sql
{
    internal class VirtualClusterOperationSource : IOperationSource<VirtualCluster>
    {
        private readonly ArmClient _client;

        internal VirtualClusterOperationSource(ArmClient client)
        {
            _client = client;
        }

        VirtualCluster IOperationSource<VirtualCluster>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = VirtualClusterData.DeserializeVirtualClusterData(document.RootElement);
            return new VirtualCluster(_client, data);
        }

        async ValueTask<VirtualCluster> IOperationSource<VirtualCluster>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = VirtualClusterData.DeserializeVirtualClusterData(document.RootElement);
            return new VirtualCluster(_client, data);
        }
    }
}
