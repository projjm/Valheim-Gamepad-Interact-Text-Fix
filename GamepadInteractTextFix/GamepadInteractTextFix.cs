using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace GamepadInteractTextFix
{

    [BepInPlugin("projjm.gamepadInteractTextFix", "Gamepad Interact Text Fix", "1.0.0")]
    [BepInProcess("valheim.exe")]
    public class GamepadInteractTextFix : BaseUnityPlugin
    {
        private static ConfigEntry<string> customInteractText;
        private static ConfigEntry<bool> onlyWhenGamepadActive;

        private static string CustomText;

        private readonly Harmony Harmony = new Harmony("projjm.combattargetingsystem");
        private void Awake()
        {
            Harmony.PatchAll();
            customInteractText = Config.Bind<string>("General", "customInteractButton", "PS_X" , "Test");
            onlyWhenGamepadActive = Config.Bind<bool>("General", "onlyWhenGamepadActive", true, "Enable the mod only when a gamepad is active");
            UpdateInteractButton();
        }

        void OnDestroy()
        {
            Harmony.UnpatchSelf();
        }

        private void UpdateInteractButton()
        {
            switch(customInteractText.Value)
            {
                case "PS_X":
                    CustomText = "✕";
                    break;
                case "PS_SQUARE":
                    CustomText = "☐";
                    break;
                case "PS_TRIANGLE":
                    CustomText = "▲";
                    break;
                case "PS_CIRCLE":
                    CustomText = "◯";
                    break;
                case "DPAD_UP":
                    CustomText = "▲";
                    break;
                case "DPAD_DOWN":
                    CustomText = "▼";
                    break;
                case "DPAD_LEFT":
                    CustomText = "◀";
                    break;
                case "DPAD_RIGHT":
                    CustomText = "▶";
                    break;
                case "JOYSTICK_RIGHT":
                    CustomText = "Ⓡ";
                    break;
                case "JOYSTICK_LEFT":
                    CustomText = "Ⓛ";
                    break;
                default:
                    CustomText = customInteractText.Value;
                    break;
            }
        }

        [HarmonyPatch(typeof(Localization), nameof(Localization.GetBoundKeyString))]
        class InteractTextFix
        {
            public static bool Prefix(Localization __instance, string bindingName, ref string __result)
            {
                if (onlyWhenGamepadActive.Value && !ZInput.IsGamepadActive())
                    return true;

                if (bindingName == "Use")
                {
                    __result = CustomText;
                    return false;
                }
                return true;
            }
        }
        
    }




}

