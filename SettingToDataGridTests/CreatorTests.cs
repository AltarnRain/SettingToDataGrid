// <copyright file="CreatorTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGridTests
{
    using System.Windows.Forms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tets the static Creator class
    /// </summary>
    [TestClass]
    public class CreatorTests
    {
        /// <summary>
        /// Tests the creator get.
        /// </summary>
        [TestMethod]
        public void TestCreatorGet()
        {
            // Arrange
            var dataGrid = new DataGridView();

            // Act
            var handler = SettingToDataGrid.Creator.Get<Data>(string.Empty, dataGrid);

            // Assert
            Assert.IsNotNull(handler);
        }
    }
}
