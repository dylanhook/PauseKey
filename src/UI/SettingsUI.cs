using BeatSaberMarkupLanguage.Attributes;
using PauseKey.Configuration;
using System.Collections.Generic;

namespace PauseKey.UI;

internal class SettingsUI
{
    public static readonly SettingsUI Instance = new();

    [UIValue("pause-button-choices")]
    private readonly List<object> _choices = new()
    {
        "Default (Menu)", "Left Trigger", "Right Trigger", "Left Grip", "Right Grip",
        "Left Primary", "Right Primary", "Left Secondary", "Right Secondary",
        "Left Stick", "Right Stick"
    };

    [UIValue("pause-button-value")]
    public string PauseButtonValue
    {
        get => (string)_choices[PluginConfig.Instance.PauseButton];
        set => PluginConfig.Instance.PauseButton = _choices.IndexOf(value);
    }
}