using System.Reflection;
using BepInEx;
using HarmonyLib;
using WalkiePlus.Patches;

namespace WalkiePlus;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        // Plugin startup logic
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
        
        {
            MethodInfo methodOrig = AccessTools.Method(typeof(HUDManager), "Update");
            MethodInfo methodPatch = AccessTools.Method(typeof(CompassUpdater), "CompassUpdate");
            harmony.Patch(methodOrig, new HarmonyMethod(methodPatch));
            Logger.LogInfo("Compass updater loaded!");
        }
    }
}