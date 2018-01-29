// <copyright file="JsonDataSerializer{T}.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGrid.Interfaces
{
    using System.ComponentModel;
    using SettingToDataGrid.Models;

    /// <summary>
    /// Serializes and Deserializes data of model T
    /// </summary>
    /// <typeparam name="T">A model of type T</typeparam>
    /// <seealso cref="IDataSerializer{T}" />
    internal class JsonDataSerializer<T> : IDataSerializer<T>
        where T : class
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>A BindingList of Type T</returns>
        public ContainerModel<T> GetData(string data)
        {
            try
            {
                var container = Newtonsoft.Json.JsonConvert.DeserializeObject<ContainerModel<T>>(data);
                if (container == null)
                {
                    container = new ContainerModel<T>();
                }

                return container;
            }
            catch
            {
                return new ContainerModel<T>();
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <returns>
        /// A string containing the serialized data of BindingList<typeparamref name="T" />
        /// </returns>
        public string GetData(ContainerModel<T> container)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(container);
            return json;
        }
    }
}
