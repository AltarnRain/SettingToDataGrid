// <copyright file="DataHandler.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGrid.Handlers
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using SettingToDataGrid.Interfaces;

    /// <summary>
    /// Handlers data manipulation
    /// </summary>
    /// <typeparam name="T">A model</typeparam>
    /// <seealso cref="IDataHandler{T}" />
    internal class DataHandler<T> : IDataHandler<T>
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
        private BindingList<T> bindingList = new BindingList<T>();

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

            this.bindingList = this.dataSerializer.GetData(data);
            this.bindingSource.DataSource = this.bindingList;
            this.bindingList.ListChanged += this.RaiseOnDataChangedEvent;
            this.dataGridView.CellEndEdit += this.CellEdited;

            dataGridView.DataSource = this.bindingSource;
            dataGridView.AutoGenerateColumns = true;
            dataGridView.AutoSize = true;
        }

        /// <summary>
        /// Gets or sets called when data changed
        /// </summary>
        public Action<string> OnDataChangedHandler { get; set; }

        /// <summary>
        /// Adds the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Add(T data)
        {
            this.bindingList.Add(data);
        }

        /// <summary>
        /// Removes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Remove(T data)
        {
            this.bindingList.Remove(data);
        }

        private void RaiseOnDataChangedEvent(object sender, ListChangedEventArgs e)
        {
            this.OnDataChangedHandler?.Invoke(this.dataSerializer.GetData(this.bindingList));
        }

        private void CellEdited(object sender, DataGridViewCellEventArgs e)
        {
            this.RaiseOnDataChangedEvent(null, null);
        }
    }
}
