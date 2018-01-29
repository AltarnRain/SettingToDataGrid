// <copyright file="DataHandlerFactory.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGrid.Factories
{
    using System.Windows.Forms;
    using Ninject;
    using Ninject.Parameters;
    using SettingToDataGrid.Interfaces;

    /// <summary>
    /// Created DataHandler objects
    /// </summary>
    /// <seealso cref="IDataHandlerFactory" />
    internal class DataHandlerFactory : IDataHandlerFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataHandlerFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public DataHandlerFactory(IKernel kernel)
        {
            this.Kernel = kernel;
        }

        /// <summary>
        /// Gets the kernel.
        /// </summary>
        /// <value>
        /// The kernel.
        /// </value>
        private IKernel Kernel { get; }

        /// <summary>
        /// Creates the specified data.
        /// </summary>
        /// <typeparam name="T">A model</typeparam>
        /// <param name="settingName">Name of the setting.</param>
        /// <param name="dataGridView">The data grid view.</param>
        /// <returns>
        /// DataHAndler for type T
        /// </returns>
        public IDataHandler<T> Create<T>(string settingName, DataGridView dataGridView)
            where T : class
        {
            return this.Kernel.Get<IDataHandler<T>>(new ConstructorArgument("data", settingName), new ConstructorArgument("dataGridView", dataGridView));
        }
    }
}
