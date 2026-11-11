using BepInEx;
using RadiantCommission;
using RadiantUI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RadiantPlugin
{
    /// <summary>
    /// Actual mod entrypoint
    /// </summary>
    [BepInPlugin(PluginConstants.PluginId, PluginConstants.PluginName, "1.0.0")]
    [BepInDependency("yuu.dressmaker.mods")]
    public sealed class RadiantCommissionPlugin : BaseUnityPlugin
    {
        private static CommissionService _comService;
        private static UIService _uiService;


        /// <summary>
        /// Runs when BepInEx loads the plugin
        /// </summary>
        private void Awake()
        {
            Logger.LogInfo($"{PluginConstants.PluginName} loaded.");
            _comService = new CommissionService(Logger);
            _uiService = new UIService(Logger);
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // Log current scene
            Logger.LogInfo($"Scene loaded: {scene.name}");

            if (scene.name != "PatternCutting")
                return;

            GameObject frontDesk = GameObject.Find("FrontDesk");

            if (frontDesk == null)
            {
                Logger.LogError("Could not find FrontDesk");
                return;
            }

            // Found FrontDesk at runtime w/ maybe accessible canvas
            Logger.LogInfo($"Found FrontDesk: {frontDesk.name}");

            // Create Envelope
            _uiService.CreateAndDisplayEnvelope(frontDesk, _comService.GetCommission);
        }
    }
}
