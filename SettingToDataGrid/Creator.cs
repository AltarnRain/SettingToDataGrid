// <copyright file="Creator.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGrid
{
    using System.Windows.Forms;
    using Ninject;
    using SettingToDataGrid.Interfaces;

    /// <summary>
    /// Wrapper class that handles ninjection and returns a DataHandler
    /// </summary>
    public static class Creator
    {
        /// <summary>
        /// Gets the specified data.
        /// </summary>
        /// <typeparam name="T">Data model</typeparam>
        /// <param name="data">The data.</param>
        /// <param name="dataGridView">The data grid view.</param>
        /// <param name="useXmlSerialization">if set to <c>true</c> [use XML serialization].</param>
        /// <returns>
        /// An IDataHander
        /// </returns>
        public static IDataHandler<T> Get<T>(string data, DataGridView dataGridView, bool useXmlSerialization = false)
        {
            using (var kernel = new StandardKernel(new Modules(useXmlSerialization)))
            {
                var factory = kernel.Get<IDataHandlerFactory>();

                return factory.Create<T>(data, dataGridView);
            }
        }
    }
}
