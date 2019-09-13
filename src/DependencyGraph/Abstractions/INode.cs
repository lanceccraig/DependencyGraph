﻿// -------------------------------------------------------------------------------------------------
// <copyright file="INode.cs" company="LanceC">
// Copyright (c) LanceC. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DependencyGraph.Abstractions
{
    /// <summary>
    /// Defines a node on a <see cref="IGraph{T}"/>.
    /// </summary>
    /// <typeparam name="T">The value type of the <see cref="INode{T}"/>.</typeparam>
    public interface INode<T>
        where T : IEquatable<T>
    {
        /// <summary>
        /// Gets the value of the <see cref="INode{T}"/>.
        /// </summary>
        T Value { get; }
    }
}
