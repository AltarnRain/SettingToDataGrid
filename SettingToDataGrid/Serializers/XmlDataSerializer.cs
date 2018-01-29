// <copyright file="XmlDataSerializer.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace SettingToDataGrid
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using SettingToDataGrid.Interfaces;
    using SettingToDataGrid.Models;

    /// <summary>
    /// Xml Serializer
    /// </summary>
    /// <typeparam name="T">A model</typeparam>
    /// <seealso cref="SettingToDataGrid.Interfaces.IDataSerializer{T}" />
    internal class XmlDataSerializer<T> : IDataSerializer<T>
        where T : class
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>
        /// BindingList with models of type T
        /// </returns>
        public ContainerModel<T> GetData(string data)
        {
            if (data == null)
            {
                return null;
            }

            try
            {
                var xmlSerializer = new XmlSerializer(typeof(BindingList<T>));
                var stringReader = new StringReader(data);

                using (var reader = XmlReader.Create(stringReader))
                {
                    var returnValue = xmlSerializer.Deserialize(reader) as ContainerModel<T>;

                    if (returnValue == null)
                    {
                        throw new InvalidCastException("Invalid model cast");
                    }
                    else
                    {
                        return returnValue;
                    }
                }
            }
            catch
            {
                return new ContainerModel<T>();
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="bindingList">The binding list.</param>
        /// <returns>
        /// BindingList with models of type T
        /// </returns>
        /// <exception cref="Exception">An error occurred</exception>
        public string GetData(ContainerModel<T> bindingList)
        {
            if (bindingList == null)
            {
                return string.Empty;
            }

            try
            {
                var xmlserializer = new XmlSerializer(typeof(ContainerModel<T>));
                var stringWriter = new StringWriter();

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "\t";

                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    xmlserializer.Serialize(writer, bindingList);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }
    }
}