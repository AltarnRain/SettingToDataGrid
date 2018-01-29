// <copyright file="IDataSerializer{T}.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGrid.Interfaces
{
    using SettingToDataGrid.Models;

    /// <summary>
    /// Serializes data
    /// </summary>
    /// <typeparam name="T">A model</typeparam>
    internal interface IDataSerializer<T>
        where T : class
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>BindingList with models of type T</returns>
        ContainerModel<T> GetData(string data);

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// BindingList with models of type T
        /// </returns>
        string GetData(ContainerModel<T> model);
    }
}