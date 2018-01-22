// <copyright file="TestBase.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGridTests
{
    using Ninject;

    /// <summary>
    /// Base for testing
    /// </summary>
    public class TestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestBase" /> class.
        /// </summary>
        public TestBase()
        {
            this.Kernel = new StandardKernel(new Modules());
        }

        /// <summary>
        /// Gets the kernel
        /// </summary>
        /// <value>
        /// The kernel.
        /// </value>
        protected IKernel Kernel { get; }
    }
}
