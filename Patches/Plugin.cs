using BepInEx;
using HarmonyLib;
using SurgeX.Managers;
using System.ComponentModel;
using System.Reflection;

namespace StupidTemplate.Patches
{
    [Description(StupidTemplate.PluginInfo.Description)]
    [BepInPlugin(StupidTemplate.PluginInfo.GUID, StupidTemplate.PluginInfo.Name, StupidTemplate.PluginInfo.Version)]
    public class HarmonyPatches : BaseUnityPlugin
    {
        public static bool IsPatched { get; private set; }
        private static Harmony instance;

        private void OnEnable()
        {
            if (!IsPatched)
            {
                if (instance == null)
                {
                    instance = new Harmony((StupidTemplate.PluginInfo.GUID));
                }
                instance.PatchAll(Assembly.GetExecutingAssembly());
                IsPatched = true;
            }
        }
        void OnGUI()
        {
            if (IsPatched)
            {
                UiManager.OnGUI();
            }
        }

        private void OnDisable()
        {
            if (instance != null && IsPatched)
            {
                IsPatched = false;
            }
        }
    }
}
