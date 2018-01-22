// <copyright file="Modules.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGrid
{
    using Ninject.Modules;
    using SettingToDataGrid.Factories;
    using SettingToDataGrid.Handlers;
    using SettingToDataGrid.Interfaces;

    /// <summary>
    /// Ninject modules
    /// </summary>
    /// <seealso cref="NinjectModule" />
    internal class Modules : NinjectModule
    {
        /// <summary>
        /// Loads this instance.
        /// </summary>
        public override void Load()
        {
            this.Kernel.Bind<IDataHandlerFactory>().To<DataHandlerFactory>().InSingletonScope();
            this.Kernel.Bind(typeof(IDataSerializer<>)).To(typeof(DataSerializer<>)).InSingletonScope();

            // Bind to an interface that employs a generic.
            this.Kernel.Bind(typeof(IDataHandler<>)).To(typeof(DataHandler<>));
        }
    }
}
