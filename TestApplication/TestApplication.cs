// <copyright file="TestApplication.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

/* An experimental program that uses a BindList as a Datasource linked to a DataGrid.
 * I'm storing a serialized string an in application settings to see if it is possible to serialize and deserialize data.
 * Guess what... it worked.
 * OI
 */

namespace TestApplication
{
    using System;
    using System.Windows.Forms;
    using global::TestApplication.Properties;
    using SettingToDataGrid;
    using SettingToDataGrid.Interfaces;

    /// <summary>
    /// TestApplicationForm
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    internal partial class TestApplication : Form
    {
        /// <summary>
        /// The data row handler
        /// </summary>
        private IDataHandler<TestData> dataRowHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestApplication"/> class.
        /// </summary>
        public TestApplication()
        {
            this.InitializeComponent();
            this.dataRowHandler = Creator.Get<TestData>(Settings.Default.TestData, this.DataGrid);
            this.dataRowHandler.OnDataChanged += this.OnDataChanges;
        }

        /// <summary>
        /// Handles the Click event of the Add control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Add_Click(object sender, EventArgs e)
        {
            this.dataRowHandler.Add(new TestData());
        }

        /// <summary>
        /// Handles the Click event of the Remove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Remove_Click(object sender, EventArgs e)
        {
            var listItem = this.DataGrid.CurrentRow.DataBoundItem as TestData;
            this.dataRowHandler.Remove(listItem);
        }

        /// <summary>
        /// Called when [change].
        /// </summary>
        /// <param name="data">The s.</param>
        private void OnDataChanges(string data)
        {
            Settings.Default.TestData = data;
            Settings.Default.Save();
        }
    }
}
