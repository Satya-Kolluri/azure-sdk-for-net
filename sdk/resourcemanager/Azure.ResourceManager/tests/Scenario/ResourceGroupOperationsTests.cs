﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ResourceGroupOperationsTests : ResourceManagerTestBase
    {
        public ResourceGroupOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        [SyncOnly]
        public void NoDataValidation()
        {
            ////subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/myRg
            var resource = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Guid.NewGuid()}/resourceGroups/fakeRg"));
            Assert.Throws<InvalidOperationException>(() => { var data = resource.Data; });
        }

        [TestCase]
        [RecordedTest]
        public async Task DeleteRg()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgOp.Value;
            await rg.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartDeleteRg()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgOp.Value;
            var deleteOp = await rg.DeleteAsync(WaitUntil.Started);
            var response = deleteOp.GetRawResponse();
            Assert.AreEqual(202, response.Status);
            await deleteOp.UpdateStatusAsync();
            await deleteOp.WaitForCompletionResponseAsync();
            await deleteOp.WaitForCompletionResponseAsync(TimeSpan.FromSeconds(2));
        }

        [TestCase]
        [RecordedTest]
        public void StartDeleteNonExistantRg()
        {
            var rgOp = InstrumentClientExtension(Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/fake")));
            var deleteOpTask = rgOp.DeleteAsync(WaitUntil.Started);
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await deleteOpTask);
            Assert.AreEqual(404, exception.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            ResourceGroupResource rg2 = await rg1.GetAsync();
            Assert.AreEqual(rg1.Data.Name, rg2.Data.Name);
            Assert.AreEqual(rg1.Data.Id, rg2.Data.Id);
            Assert.AreEqual(rg1.Data.ResourceType, rg2.Data.ResourceType);
            Assert.AreEqual(rg1.Data.Properties.ProvisioningState, rg2.Data.Properties.ProvisioningState);
            Assert.AreEqual(rg1.Data.Location, rg2.Data.Location);
            Assert.AreEqual(rg1.Data.ManagedBy, rg2.Data.ManagedBy);
            Assert.AreEqual(rg1.Data.Tags, rg2.Data.Tags);

            ResourceIdentifier fakeId = new ResourceIdentifier(rg1.Data.Id.ToString() + "x");
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await Client.GetResourceGroupResource(new ResourceIdentifier(fakeId)).GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            var rgName = Recording.GenerateAssetName("testrg");
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            var parameters = new PatchableResourceGroupData
            {
                Name = rgName
            };
            ResourceGroupResource rg2 = await rg1.UpdateAsync(parameters);
            Assert.AreEqual(rg1.Data.Name, rg2.Data.Name);
            Assert.AreEqual(rg1.Data.Id, rg2.Data.Id);
            Assert.AreEqual(rg1.Data.ResourceType, rg2.Data.ResourceType);
            Assert.AreEqual(rg1.Data.Properties.ProvisioningState, rg2.Data.Properties.ProvisioningState);
            Assert.AreEqual(rg1.Data.Location, rg2.Data.Location);
            Assert.AreEqual(rg1.Data.ManagedBy, rg2.Data.ManagedBy);
            Assert.AreEqual(rg1.Data.Tags, rg2.Data.Tags);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg1.UpdateAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartExportTemplate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgOp.Value;
            var parameters = new ExportTemplate();
            parameters.Resources.Add("*");
            var expOp = await rg.ExportTemplateAsync(WaitUntil.Started, parameters);
            await expOp.WaitForCompletionAsync();

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var expOp = await rg.ExportTemplateAsync(WaitUntil.Started, null);
                _ = await expOp.WaitForCompletionAsync();
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task AddTag()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            Assert.AreEqual(0, rg1.Data.Tags.Count);
            ResourceGroupResource rg2 = await rg1.AddTagAsync("key", "value");
            Assert.AreEqual(1, rg2.Data.Tags.Count);
            Assert.IsTrue(rg2.Data.Tags.Contains(new KeyValuePair<string, string>("key", "value")));
            Assert.AreEqual(rg1.Data.Name, rg2.Data.Name);
            Assert.AreEqual(rg1.Data.Id, rg2.Data.Id);
            Assert.AreEqual(rg1.Data.ResourceType, rg2.Data.ResourceType);
            Assert.AreEqual(rg1.Data.Properties.ProvisioningState, rg2.Data.Properties.ProvisioningState);
            Assert.AreEqual(rg1.Data.Location, rg2.Data.Location);
            Assert.AreEqual(rg1.Data.ManagedBy, rg2.Data.ManagedBy);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg1.AddTagAsync(null, "value"));
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => _ = await rg1.AddTagAsync(" ", "value"));
            Assert.AreEqual(400, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task SetTags()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            Assert.AreEqual(0, rg1.Data.Tags.Count);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value"}
            };
            ResourceGroupResource rg2 = await rg1.SetTagsAsync(tags);
            Assert.AreEqual(tags, rg2.Data.Tags);
            Assert.AreEqual(rg1.Data.Name, rg2.Data.Name);
            Assert.AreEqual(rg1.Data.Id, rg2.Data.Id);
            Assert.AreEqual(rg1.Data.ResourceType, rg2.Data.ResourceType);
            Assert.AreEqual(rg1.Data.Properties.ProvisioningState, rg2.Data.Properties.ProvisioningState);
            Assert.AreEqual(rg1.Data.Location, rg2.Data.Location);
            Assert.AreEqual(rg1.Data.ManagedBy, rg2.Data.ManagedBy);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg1.SetTagsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task RemoveTag()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            var tags = new Dictionary<string, string>()
            {
                { "k1", "v1"},
                { "k2", "v2"}
            };
            rg1 = await rg1.SetTagsAsync(tags);
            ResourceGroupResource rg2 = await rg1.RemoveTagAsync("k1");
            var tags2 = new Dictionary<string, string>()
            {
                { "k2", "v2"}
            };
            Assert.AreEqual(tags2, rg2.Data.Tags);
            Assert.AreEqual(rg1.Data.Name, rg2.Data.Name);
            Assert.AreEqual(rg1.Data.Id, rg2.Data.Id);
            Assert.AreEqual(rg1.Data.ResourceType, rg2.Data.ResourceType);
            Assert.AreEqual(rg1.Data.Properties.ProvisioningState, rg2.Data.Properties.ProvisioningState);
            Assert.AreEqual(rg1.Data.Location, rg2.Data.Location);
            Assert.AreEqual(rg1.Data.ManagedBy, rg2.Data.ManagedBy);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg1.RemoveTagAsync(null));
            Assert.DoesNotThrowAsync(async () => rg2 = await rg1.RemoveTagAsync(" "));
            //removing something that wasn't there should not have changed the tags
            Assert.AreEqual(tags2, rg2.Data.Tags);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListAvailableLocations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgOp.Value;
            var locations = await rg.GetAvailableLocationsAsync();
            int count = 0;
            foreach (var location in locations.Value)
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task MoveResources()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            var rg2Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            ResourceGroupResource rg2 = rg2Op.Value;
            var genericResources = subscription.GetGenericResourcesAsync();
            var aset = await CreateGenericAvailabilitySetAsync(rg1.Id);

            int countRg1 = await GetResourceCountAsync(rg1.GetGenericResourcesAsync());
            int countRg2 = await GetResourceCountAsync(rg2.GetGenericResourcesAsync());
            Assert.AreEqual(1, countRg1);
            Assert.AreEqual(0, countRg2);

            var moveInfo = new ResourcesMoveInfo();
            moveInfo.TargetResourceGroup = rg2.Id;
            moveInfo.Resources.Add(aset.Id);
            _ = await rg1.MoveResourcesAsync(WaitUntil.Completed, moveInfo);

            countRg1 = await GetResourceCountAsync(rg1.GetGenericResourcesAsync());
            countRg2 = await GetResourceCountAsync(rg2.GetGenericResourcesAsync());
            Assert.AreEqual(0, countRg1);
            Assert.AreEqual(1, countRg2);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg1.MoveResourcesAsync(WaitUntil.Completed, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartMoveResources()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            var rg2Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            ResourceGroupResource rg2 = rg2Op.Value;
            var genericResources = subscription.GetGenericResourcesAsync();
            var asetOp = await StartCreateGenericAvailabilitySetAsync(rg1.Id);
            GenericResource aset = await asetOp.WaitForCompletionAsync();

            int countRg1 = await GetResourceCountAsync(rg1.GetGenericResourcesAsync());
            int countRg2 = await GetResourceCountAsync(rg2.GetGenericResourcesAsync());
            Assert.AreEqual(1, countRg1);
            Assert.AreEqual(0, countRg2);

            var moveInfo = new ResourcesMoveInfo();
            moveInfo.TargetResourceGroup = rg2.Id;
            moveInfo.Resources.Add(aset.Id);
            var moveOp = await rg1.MoveResourcesAsync(WaitUntil.Started, moveInfo);
            _ = await moveOp.WaitForCompletionResponseAsync();

            countRg1 = await GetResourceCountAsync(rg1.GetGenericResourcesAsync());
            countRg2 = await GetResourceCountAsync(rg2.GetGenericResourcesAsync());
            Assert.AreEqual(0, countRg1);
            Assert.AreEqual(1, countRg2);

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var moveOp = await rg1.MoveResourcesAsync(WaitUntil.Started, null);
                _ = await moveOp.WaitForCompletionResponseAsync();
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task ValidateMoveResources()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            var rg2Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            ResourceGroupResource rg2 = rg2Op.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg1.Id);

            var moveInfo = new ResourcesMoveInfo();
            moveInfo.TargetResourceGroup = rg2.Id;
            moveInfo.Resources.Add(aset.Id);
            var validateOp = await rg1.ValidateMoveResourcesAsync(WaitUntil.Completed, moveInfo);
            Response response = validateOp.GetRawResponse();

            Assert.AreEqual(204, response.Status);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg1.ValidateMoveResourcesAsync(WaitUntil.Completed, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartValidateMoveResources()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            var rg2Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            ResourceGroupResource rg2 = rg2Op.Value;
            var asetOp = await StartCreateGenericAvailabilitySetAsync(rg1.Id);
            GenericResource aset = await asetOp.WaitForCompletionAsync();

            var moveInfo = new ResourcesMoveInfo();
            moveInfo.TargetResourceGroup = rg2.Id;
            moveInfo.Resources.Add(aset.Id);
            var validateOp = await rg1.ValidateMoveResourcesAsync(WaitUntil.Started, moveInfo);
            Response response = await validateOp.WaitForCompletionResponseAsync();

            Assert.AreEqual(204, response.Status);

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var moveOp = await rg1.ValidateMoveResourcesAsync(WaitUntil.Started, null);
                _ = await moveOp.WaitForCompletionResponseAsync();
            });
        }
    }
}
