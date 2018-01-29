// <copyright file="ContainerModel.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGrid.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Container model for GridData
    /// </summary>
    /// <typeparam name="T">Any class</typeparam>
    public class ContainerModel<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerModel{T}"/> class.
        /// </summary>
        public ContainerModel()
        {
            this.Data = new BindingList<T>();
            this.ColumnWidths = new List<int?>();
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public BindingList<T> Data { get; set; }

        /// <summary>
        /// Gets or sets the column widths.
        /// </summary>
        /// <value>
        /// The column widths.
        /// </value>
        public List<int?> ColumnWidths { get; set; }
    }
}
