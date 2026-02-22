using PauseKey.Configuration;
using UnityEngine;
using UnityEngine.XR;

namespace PauseKey.Core;

internal class PauseModInputBehavior : MonoBehaviour
{
    private static PauseModInputBehavior _instance;
    public static bool IsPressed;
    public static bool IsPressedDown;

    public static void Initialize()
    {
        if (_instance != null) return;
        var go = new GameObject("PauseKey_InputTracker");
        DontDestroyOnLoad(go);
        _instance = go.AddComponent<PauseModInputBehavior>();
    }

    private void Update()
    {
        int binding = PluginConfig.Instance.PauseButton;
        if (binding == 0)
        {
            IsPressed = false;
            IsPressedDown = false;
            return;
        }

        bool left = binding == 1 || binding == 3 || binding == 5 || binding == 7 || binding == 9;
        var device = InputDevices.GetDeviceAtXRNode(left ? XRNode.LeftHand : XRNode.RightHand);

        bool val = false;
        if (device.isValid)
        {
            switch (binding)
            {
                case 1: case 2: device.TryGetFeatureValue(CommonUsages.triggerButton, out val); break;
                case 3: case 4: device.TryGetFeatureValue(CommonUsages.gripButton, out val); break;
                case 5: case 6: device.TryGetFeatureValue(CommonUsages.primaryButton, out val); break;
                case 7: case 8: device.TryGetFeatureValue(CommonUsages.secondaryButton, out val); break;
                case 9: case 10: device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out val); break;
            }
        }

        IsPressedDown = val && !IsPressed;
        IsPressed = val;
    }
}