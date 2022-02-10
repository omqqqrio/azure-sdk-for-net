﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Contrib.Extensions.PersistentStorage;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal static class PersistentStorageExtensions
    {
        internal static void SaveTelemetry(this IPersistentStorage storage, byte[] content, int leaseTime)
        {
            var blob  = storage.CreateBlob(content, leaseTime);
            if (blob != null)
            {
                // log telemetry saved offline.
                // unsuccessfull message will be logged by persistent storage.
            }
        }
    }
}
