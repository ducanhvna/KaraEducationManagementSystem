using CommonNS.CommonStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManagermentNS
{
    /// <summary>
    /// Interface of Library
    /// </summary>
    public static class PluginManagement
    {
        /// <summary>
        /// Item count
        /// </summary>
        private static int ItemCount { get {
                return m_ItemCount;
                
            } } 
        private static Dictionary<string, IPlugin> _Plugins = null;
        private static int m_ItemCount;

        /// <summary>
        /// Load Plugin
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static ICollection<IPlugin> LoadPlugins(string path)
        {
            m_ItemCount = 0;
            _Plugins = new Dictionary<string, IPlugin>();
            //ICollection<IPlugin> plugins = PluginLoader.LoadPlugins("Plugins");
            ICollection<IPlugin> plugins = PluginLoader.LoadPlugins(path);
            foreach (var item in plugins)
            {
                _Plugins.Add(item.Name, item);
            }
            return plugins;
        }

        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<string, IPlugin> Plugins
        {
            get
            {
                return _Plugins;
            }
        }

        /// <summary>
        /// Create plugin
        /// </summary>
        /// <param name="contanerName"></param>
        /// <returns></returns>
        public static IObjectContainers CreatePlugin(string contanerName)
        {
            var plugin = Plugins[contanerName];
            if(plugin != null)
            {
                try
                {
                    var result = plugin.CreateContainer(m_ItemCount, contanerName);
                    if (result != null)
                    {
                        m_ItemCount++;
                        return result;
                    }
                    return null;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
