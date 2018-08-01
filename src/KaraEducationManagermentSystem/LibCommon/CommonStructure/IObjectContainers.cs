using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace CommonNS.CommonStructure
{
    /// <summary>
    /// Object containers
    /// </summary>
    public interface IObjectContainers
    {
        /// <summary>
        /// Container key
        /// </summary>
        int Key { get; set; }

        /// <summary>
        /// Name of Container
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// sub items
        /// </summary>
        ObservableCollection<IObjectContainers> SubItems { get; }

        /// <summary>
        /// Entity Relationship Diagrm view
        /// </summary>
        UserControl DiagramView { get; }

        /// <summary>
        /// Properties View
        /// </summary>
        UserControl PropertiesView { get; }

        /// <summary>
        /// Command View
        /// </summary>
        UserControl CommandView { get; }
    }
}
