using BepInEx;

namespace RadiantPlugin
{
    /// <summary>
    /// Actual mod entrypoint
    /// </summary>
    [BepInPlugin("radiant.dressmaker.plugin", "Radiant Commissions", "1.0.0")]
    [BepInDependency("yuu.dressmaker.mods")]
    public sealed class RadiantCommissionPlugin : BaseUnityPlugin
    {
        /// <summary>
        /// Runs when BepInEx loads the plugin
        /// </summary>
        private void Awake()
        {
            Logger.LogInfo("!!!!!! LOOK HERE: UI Plugin loaded.");
        }
    }
}
