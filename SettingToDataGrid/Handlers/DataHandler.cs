// <copyright file="DataHandler.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGrid.Handlers
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using SettingToDataGrid.Interfaces;
    using SettingToDataGrid.Models;
    using static SettingToDataGrid.Events.Events;

    /// <summary>
    /// Handlers data manipulation
    /// </summary>
    /// <typeparam name="T">A model</typeparam>
    /// <seealso cref="IDataHandler{T}" />
    internal class DataHandler<T> : IDataHandler<T>
        where T : class
    {
        /// <summary>
        /// The data provider
        /// </summary>
        private readonly IDataSerializer<T> dataSerializer;

        /// <summary>
        /// The setting name
        /// </summary>
        private readonly string settingName;

        /// <summary>
        /// The data grid view
        /// </summary>
        private readonly DataGridView dataGridView;

        /// <summary>
        /// The binding list
        /// </summary>
        private ContainerModel<T> container = new ContainerModel<T>();

        /// <summary>
        /// The binding source
        /// </summary>
        private BindingSource bindingSource = new BindingSource();

        /// <summary>
        /// Initializes a new instance of the <see cref="DataHandler{T}" /> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        /// <param name="data">Name of the setting.</param>
        /// <param name="dataGridView">The data grid view.</param>
        public DataHandler(IDataSerializer<T> dataProvider, string data, DataGridView dataGridView)
        {
            this.dataSerializer = dataProvider;
            this.settingName = data;
            this.dataGridView = dataGridView;

            this.container = this.dataSerializer.GetData(data);
            this.bindingSource.DataSource = this.container.Data;
            this.container.Data.ListChanged += this.RaiseOnDataChangedEvent;
            this.dataGridView.CellEndEdit += this.CellEdited;
            this.dataGridView.ColumnWidthChanged += this.ColumnWidthChanges;

            dataGridView.DataSource = this.bindingSource;
            dataGridView.AutoGenerateColumns = true;
            dataGridView.AutoSize = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;

            this.SetColumnWidths(dataGridView);
        }

        /// <summary>
        /// Gets or sets called when data changed
        /// </summary>
        public event DataChangedEvent OnDataChanged;

        /// <summary>
        /// Adds the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Add(T data)
        {
            this.container.Data.Add(data);
        }

        /// <summary>
        /// Removes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Remove(T data)
        {
            this.container.Data.Remove(data);
        }

        /// <summary>
        /// Removes the selected row.
        /// </summary>
        public void RemoveSelectedRow()
        {
            if (this.dataGridView.CurrentRow != null)
            {
                var dataRow = this.dataGridView.CurrentRow.DataBoundItem as T;
                this.Remove(dataRow);
            }
        }

        /// <summary>
        /// Returns the current data in an IEnumerable<typeparamref name="T">Any class</typeparamref>.
        /// </summary>
        /// <returns>IEnumerable<typeparamref name="T"/></returns>
        public IEnumerable<T> GetData()
        {
            return this.container.Data.AsEnumerable<T>();
        }

        /// <summary>
        /// Raises the on data changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ListChangedEventArgs"/> instance containing the event data.</param>
        private void RaiseOnDataChangedEvent(object sender, ListChangedEventArgs e)
        {
            this.OnDataChanged?.Invoke(this.dataSerializer.GetData(this.container));
        }

        /// <summary>
        /// Cells the edited.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void CellEdited(object sender, DataGridViewCellEventArgs e)
        {
            this.RaiseOnDataChangedEvent(null, null);
        }

        /// <summary>
        /// Columns the width changes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewColumnEventArgs"/> instance containing the event data.</param>
        private void ColumnWidthChanges(object sender, DataGridViewColumnEventArgs e)
        {
            this.container.ColumnWidths.Clear();

            foreach (var col in this.dataGridView.Columns.Cast<DataGridViewColumn>())
            {
                this.container.ColumnWidths.Add(col.Width);
            }

            this.RaiseOnDataChangedEvent(null, null);
        }

        /// <summary>
        /// Sets the column widths.
        /// </summary>
        /// <param name="dataGridView">The data grid view.</param>
        private void SetColumnWidths(DataGridView dataGridView)
        {
            if (this.container.ColumnWidths.Count > 0)
            {
                foreach (var col in dataGridView.Columns.Cast<DataGridViewColumn>())
                {
                    if (this.container.ColumnWidths[col.Index].HasValue)
                    {
                        col.Width = this.container.ColumnWidths[col.Index].Value;
                    }
                }
            }
        }
    }
}
