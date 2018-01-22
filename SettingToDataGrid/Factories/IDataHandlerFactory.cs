// <copyright file="IDataHandlerFactory.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGrid.Interfaces
{
    using System.Windows.Forms;
    using Ninject;

    /// <summary>
    /// Created a DataHandler
    /// </summary>
    internal interface IDataHandlerFactory
    {
        /// <summary>
        /// Gets the kernel.
        /// </summary>
        /// <value>
        /// The kernel.
        /// </value>
        IKernel Kernel { get; }

        /// <summary>
        /// Creates the specified data.
        /// </summary>
        /// <typeparam name="T">A model</typeparam>
        /// <param name="settingName">Name of the setting.</param>
        /// <param name="dataGridView">The data grid view.</param>
        /// <returns>
        /// A DataHandler
        /// </returns>
        IDataHandler<T> Create<T>(string settingName, DataGridView dataGridView);
    }
}