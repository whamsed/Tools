using System.Collections.Generic;

namespace Tools.Plugin
{
    public interface IPlugin<T>
    {
        string Name { get; set; }
        IPluginSettings PluginSettings { get; set; }
        bool Init();
        List<T> Execute();
        bool Exit();
    }
}