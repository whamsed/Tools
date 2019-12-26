using System.Collections.Generic;

namespace Tools.Plugin
{
    public interface IPlugin
    {
        string Name { get; set; }
        IPluginSettings PluginSettings { get; set; }
        bool Init();
        List<string> Execute();
        bool Exit();
    }
}