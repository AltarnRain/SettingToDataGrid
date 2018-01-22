// <copyright file="IDataHandler.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGrid.Interfaces
{
    using System;

    /// <summary>
    /// DataHandler interface
    /// </summary>
    /// <typeparam name="T">A model</typeparam>
    public interface IDataHandler<T>
    {
        /// <summary>
        /// Gets or sets called when data changed
        /// </summary>
        /// <value>
        /// The on data changed handler.
        /// </value>
        Action<string> OnDataChangedHandler { get; set; }

        /// <summary>
        /// Adds the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        void Add(T data);

        /// <summary>
        /// Removes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        void Remove(T data);
    }
}