﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Deployment.Definition;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Rest.Azure;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    internal class DeploymentsImpl : IDeployments
    {
        private IResourceManager resourceManager;

        public IResourceManager Manager
        {
            get
            {
                return resourceManager;
            }
        }

        public IDeploymentsOperations Inner
        {
            get
            {
                return Manager.Inner.Deployments;
            }
        }

        internal DeploymentsImpl(IResourceManager resourceManager)
        {
            this.resourceManager = resourceManager;
        }

        public bool CheckExistence(string resourceGroupName, string deploymentName)
        {
            return Manager.Deployments.CheckExistence(resourceGroupName, deploymentName);
        }

        public IBlank Define(string name)
        {
            return CreateFluentModel(name);
        }

        public void DeleteById(string id)
        {
            DeleteByIdAsync(id).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public void DeleteByGroup(string groupName, string name)
        {
            DeleteByGroupAsync(groupName, name).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await DeleteByGroupAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        public async Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Deployments.DeleteAsync(groupName, name, cancellationToken);
        }

        public IDeployment GetByGroup(string resourceGroupName, string name)
        {
            return GetByGroupAsync(resourceGroupName, name).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async Task<IDeployment> GetByGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var deploymentExtendedInner = await Manager.Inner.Deployments.GetAsync(resourceGroupName, name, cancellationToken);
            return CreateFluentModel(deploymentExtendedInner);
        }

        public IDeployment GetById(string id)
        {
            return GetByIdAsync(id).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async Task<IDeployment> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await GetByGroupAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        public IDeployment GetByName(string name)
        {
            var resourceGroups = resourceManager.ResourceGroups.List();
            foreach (var resourceGroup in resourceGroups)
            {
                try
                {
                    var deploymentExtendedInner = Manager.Inner.Deployments.Get(resourceGroup.Name, name);
                    if (deploymentExtendedInner != null)
                    {
                        return CreateFluentModel(deploymentExtendedInner);
                    }
                }
                catch (CloudException)
                {
                }
            }
            return null;
        }

        public Task<IDeployment> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        public IEnumerable<IDeployment> List()
        {
            return resourceManager.ResourceGroups.List()
                                                 .SelectMany(rg => ListByGroup(rg.Name));
        }

        public IEnumerable<IDeployment> ListByGroup(string resourceGroupName)
        {
            return Manager.Inner.Deployments.List(resourceGroupName)
                                            .AsContinuousCollection(link => Manager.Inner.Deployments.ListNext(link))
                                            .Select(inner => CreateFluentModel(inner));
        }

        public Task<IEnumerable<IDeployment>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        private DeploymentImpl CreateFluentModel(DeploymentExtendedInner deploymentExtendedInner)
        {
            return new DeploymentImpl(deploymentExtendedInner, resourceManager);
        }

        private DeploymentImpl CreateFluentModel(string name)
        {
            return new DeploymentImpl(
                    new DeploymentExtendedInner
                    {
                        Name = name
                    },
                    resourceManager
                );
        }
    }
}