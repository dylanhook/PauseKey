using BeatSaberMarkupLanguage.Settings;
using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using PauseKey.Configuration;
using PauseKey.Core;
using PauseKey.UI;

namespace PauseKey;

[Plugin(RuntimeOptions.SingleStartInit)]
public class Plugin
{
    private Harmony _harmony;

    [Init]
    public void Init(Config config)
    {
        PluginConfig.Instance = config.Generated<PluginConfig>();
    }

    [OnStart]
    public void OnApplicationStart()
    {
        _harmony = new Harmony("com.dylan.PauseKey");
        _harmony.PatchAll(typeof(Plugin).Assembly);

        PauseModInputBehavior.Initialize();

        BeatSaberMarkupLanguage.Util.MainMenuAwaiter.MainMenuInitializing += OnMainMenuInit;
    }

    private void OnMainMenuInit()
    {
        BSMLSettings.Instance.AddSettingsMenu("Pause Key", "PauseKey.Resources.BSML.SettingsUI.bsml", SettingsUI.Instance);
    }

    [OnExit]
    public void OnApplicationQuit()
    {
        _harmony?.UnpatchSelf();
        BSMLSettings.Instance.RemoveSettingsMenu(SettingsUI.Instance);
    }
}