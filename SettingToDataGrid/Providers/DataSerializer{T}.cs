// <copyright file="DataSerializer{T}.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGrid.Interfaces
{
    using System.ComponentModel;

    /// <summary>
    /// Serializes and Deserializes data of model T
    /// </summary>
    /// <typeparam name="T">A model of type T</typeparam>
    /// <seealso cref="IDataSerializer{T}" />
    internal class DataSerializer<T> : IDataSerializer<T>
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>A BindingList of Type T</returns>
        public BindingList<T> GetData(string data)
        {
            var bindingList = Newtonsoft.Json.JsonConvert.DeserializeObject<BindingList<T>>(data);

            if (bindingList == null)
            {
                bindingList = new BindingList<T>();
            }

            return bindingList;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="bindingList">The binding list.</param>
        /// <returns>A string containing the serialized data of BindingList<typeparamref name="T"/></returns>
        public string GetData(BindingList<T> bindingList)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(bindingList);
        }
    }
}
