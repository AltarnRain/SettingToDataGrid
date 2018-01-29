// <copyright file="DataHandlerFactoryTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGridTests
{
    using System.Windows.Forms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ninject;
    using SettingToDataGrid.Factories;

    /// <summary>
    /// Tests the DataHandlerFactory
    /// </summary>
    [TestClass]
    public class DataHandlerFactoryTests : TestBase
    {
        /// <summary>
        /// Tests the data handler factory.
        /// </summary>
        [TestMethod]
        public void TestDataHandlerFactoryCreateTest()
        {
            var factory = this.Kernel.Get<DataHandlerFactory>();

            Assert.IsNotNull(factory);
        }

        /// <summary>
        /// Tests the create handler test.
        /// </summary>
        [TestMethod]
        public void TestCreateHandlerTest()
        {
            // Arrange
            var factory = this.Kernel.Get<DataHandlerFactory>();
            var dataGrid = new DataGridView();

            // Act
            var handler = factory.Create<Data>(string.Empty, dataGrid);

            // Assert
            Assert.IsNotNull(handler);
        }

        /// <summary>
        /// Tests the create handler test.
        /// </summary>
        [TestMethod]
        public void TestCreateHandlerAddTest()
        {
            // Arrange
            var factory = this.Kernel.Get<DataHandlerFactory>();
            var dataGrid = new DataGridView();
            var handler = factory.Create<Data>(string.Empty, dataGrid);

            handler.OnDataChanged += (string value) =>
            {
                Assert.IsNotNull(value);
            };

            // Act
            handler.Add(new Data { Name = "Piet", Age = 10 });

            // Assert
            Assert.IsNotNull(handler);
        }
    }
}
