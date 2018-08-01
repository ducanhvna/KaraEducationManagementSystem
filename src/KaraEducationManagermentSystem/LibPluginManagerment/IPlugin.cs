using CommonNS.CommonStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PluginManagermentNS
{
    /// <summary>
    /// Plugin Interface
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Name of Plugin
        /// </summary>
        string Name { get; }

        /// <summary>
        /// CreateContainer
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IObjectContainers CreateContainer(int key,string name);



    }
}
