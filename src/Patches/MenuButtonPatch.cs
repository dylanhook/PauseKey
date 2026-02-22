using HarmonyLib;
using PauseKey.Configuration;
using PauseKey.Core;

namespace PauseKey.Patches;

[HarmonyPatch(typeof(UnityXRHelper))]
internal class MenuButtonPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(UnityXRHelper.GetMenuButton))]
    private static void GetMenuButtonPostfix(ref bool __result)
    {
        if (PluginConfig.Instance.PauseButton != 0)
        {
            __result = PauseModInputBehavior.IsPressed;
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(UnityXRHelper.GetMenuButtonDown))]
    private static void GetMenuButtonDownPostfix(ref bool __result)
    {
        if (PluginConfig.Instance.PauseButton != 0)
        {
            __result = PauseModInputBehavior.IsPressedDown;
        }
    }
}