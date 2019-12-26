namespace Tools.Plugin
{
    public interface IPluginSettings
    {
        bool IsActive { get; set; }
        long Timeout { get; set; }
    }
}