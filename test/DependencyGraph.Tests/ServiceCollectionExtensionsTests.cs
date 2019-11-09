// -------------------------------------------------------------------------------------------------
// <copyright file="ServiceCollectionExtensionsTests.cs" company="LanceC">
// Copyright (c) LanceC. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using LanceC.DependencyGraph.Internal.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace LanceC.DependencyGraph.Tests
{
    public class ServiceCollectionExtensionsTests
    {
        [Fact]
        public void AddDependencyGraph_ForProvidedServiceCollection_RegistersCycleDetector()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddDependencyGraph();

            // Assert
            var serviceProvider = services.BuildServiceProvider();
            var cycleDetector = serviceProvider.GetService<ICycleDetector<string>>();
            Assert.NotNull(cycleDetector);
        }

        [Fact]
        public void AddDependencyGraph_ForProvidedServiceCollection_RegistersGraphFactory()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddDependencyGraph();

            // Assert
            var serviceProvider = services.BuildServiceProvider();
            var graphFactory = serviceProvider.GetService<IGraphFactory<string>>();
            Assert.NotNull(graphFactory);
        }

        [Fact]
        public void AddDependencyGraph_ForProvidedServiceCollection_RegistersDependencyExecutionEngine()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddDependencyGraph();

            // Assert
            var serviceProvider = services.BuildServiceProvider();
            var dependencyExecutionEngine = serviceProvider.GetService<IDependencyExecutionEngine<string>>();
            Assert.NotNull(dependencyExecutionEngine);
        }
    }
}
