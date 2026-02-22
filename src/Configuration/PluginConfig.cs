using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace PauseKey.Configuration;

internal class PluginConfig
{
    public static PluginConfig Instance { get; set; } = null!;

    public virtual int PauseButton { get; set; } = 0;
}