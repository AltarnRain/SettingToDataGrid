// <copyright file="Events.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGrid.Events
{
    /// <summary>
    /// Contains events that need to be public
    /// </summary>
    public class Events
    {
        /// <summary>
        /// Delate for when data is changed in the underlying data.
        /// </summary>
        /// <param name="data">The data.</param>
        public delegate void DataChangedEvent(string data);
    }
}
