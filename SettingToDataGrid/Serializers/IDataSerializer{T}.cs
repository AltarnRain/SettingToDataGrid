// <copyright file="IDataSerializer{T}.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGrid.Interfaces
{
    using System.ComponentModel;

    /// <summary>
    /// Serializes data
    /// </summary>
    /// <typeparam name="T">A model</typeparam>
    internal interface IDataSerializer<T>
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>BindingList with models of type T</returns>
        BindingList<T> GetData(string data);

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="bindingList">The binding list.</param>
        /// <returns>BindingList with models of type T</returns>
        string GetData(BindingList<T> bindingList);
    }
}