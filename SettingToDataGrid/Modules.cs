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
        private readonly bool useXmlSerialization;

        /// <summary>
        /// Initializes a new instance of the <see cref="Modules" /> class.
        /// </summary>
        /// <param name="useXmlSerialization">if set to <c>true</c> [use XML serialization].</param>
        public Modules(bool useXmlSerialization = false)
        {
            this.useXmlSerialization = useXmlSerialization;
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        public override void Load()
        {
            this.Kernel.Bind<IDataHandlerFactory>().To<DataHandlerFactory>().InSingletonScope();
            if (this.useXmlSerialization)
            {
                this.Kernel.Bind(typeof(IDataSerializer<>)).To(typeof(XmlDataSerializer<>)).InSingletonScope();
            }
            else
            {
                this.Kernel.Bind(typeof(IDataSerializer<>)).To(typeof(JsonDataSerializer<>)).InSingletonScope();
            }

            // Bind to an interface that employs a generic.
            this.Kernel.Bind(typeof(IDataHandler<>)).To(typeof(DataHandler<>));
        }
    }
}
