// <copyright file="IDataHandler.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGrid.Interfaces
{
    using System;
    using System.Collections.Generic;
    using SettingToDataGrid.Handlers;
    using static SettingToDataGrid.Events.Events;

    /// <summary>
    /// DataHandler interface
    /// </summary>
    /// <typeparam name="T">A model</typeparam>
    public interface IDataHandler<T>
        where T : class
    {
        /// <summary>
        /// Occurs when [on data changed].
        /// </summary>
        event DataChangedEvent OnDataChanged;

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

        /// <summary>
        /// Removes the selected row.
        /// </summary>
        void RemoveSelectedRow();

        /// <summary>
        /// Returns the current data in an IEnumerable<typeparamref name="T">Any class</typeparamref>.
        /// </summary>
        /// <returns>IEnumerable<typeparamref name="T"/></returns>
        IEnumerable<T> GetData();
    }
}