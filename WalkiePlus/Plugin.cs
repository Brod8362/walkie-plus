using BepInEx;
using BepInEx.Unity.Mono;

namespace WalkiePlus;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        // Plugin startup logic
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        // Harmony harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        //
        // {
        //     MethodInfo methodOrig = AccessTools.Method(typeof(HUDManager), "Update");
        //     MethodInfo methodPatch = AccessTools.Method(typeof(CompassUpdater), "Update");
        //     harmony.Patch(methodOrig, new HarmonyMethod(methodPatch));
        //     Logger.LogInfo("Compass updater loaded!");
        // }
    }
}