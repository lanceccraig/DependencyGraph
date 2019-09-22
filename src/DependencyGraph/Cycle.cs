﻿// -------------------------------------------------------------------------------------------------
// <copyright file="Cycle.cs" company="LanceC">
// Copyright (c) LanceC. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using DependencyGraph.Abstractions;

namespace DependencyGraph
{
    public class Cycle<T>
        where T : IEquatable<T>
    {
        public Cycle(IEnumerable<INode<T>> nodes)
        {
            Nodes = nodes.ToArray();
        }

        public IReadOnlyCollection<INode<T>> Nodes { get; }

        public override string ToString()
            => "\"" + string.Join("\" -> \"", Nodes) + "\"";
    }
}
