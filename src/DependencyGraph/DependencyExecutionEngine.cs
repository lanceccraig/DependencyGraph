// -------------------------------------------------------------------------------------------------
// <copyright file="DependencyExecutionEngine.cs" company="LanceC">
// Copyright (c) LanceC. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LanceC.DependencyGraph.Internal.Abstractions;

namespace LanceC.DependencyGraph
{
    internal class DependencyExecutionEngine<T> : IDependencyExecutionEngine<T>
        where T : IEquatable<T>
    {
        private readonly IGraphFactory<T> _graphFactory;

        public DependencyExecutionEngine(IGraphFactory<T> graphFactory)
        {
            _graphFactory = graphFactory;
        }

        public async Task ExecuteAll(IEnumerable<IDependencyExecution<T>> executions, CancellationToken cancellationToken = default)
        {
            var graph = _graphFactory.Create();
            foreach (var execution in executions)
            {
                graph.GetOrAddNode(execution.Key);
                foreach (var dependentKey in execution.DependentKeys)
                {
                    graph.GetOrAddNode(dependentKey);
                    graph.AddEdge(execution.Key, dependentKey);
                }
            }

            var sortedExecutionKeys = graph.TopologicalSort();
            foreach (var executionKey in sortedExecutionKeys)
            {
                var execution = executions.Single(exec => exec.Key.Equals(executionKey));
                await execution
                    .Execute(cancellationToken)
                    .ConfigureAwait(false);
            }
        }
    }
}
