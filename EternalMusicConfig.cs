using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace EternalMusic
{
    /// <summary>
    /// The Eternal Music Addon Configurations, can be toggled while running/debugging Terraria
    /// </summary>
    [BackgroundColor(5, 20, 60)]
    [Label("Eternal Music Addon Mod Configuration")]
    public class EternalMusicConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        /// <summary>
        /// Music Configuration to toggle between the new and the old soundtrack
        /// </summary>
        [SeparatePage]
        [Header("Music Configuration")]
        [DefaultValue(false)]
        [Label("Old Eternal Soundtrack")]
        [BackgroundColor(71, 245, 169)]
        [Tooltip("Determines when to use the old soundtrack over the new soundtrack...\n(Default: Off)")]
        public bool originalMusic = false;

        /// <summary>
        /// Music Configuration to toggle between the Eternal Mod and the base game Soundtrack
        /// </summary>
        [DefaultValue(false)]
        [BackgroundColor(71, 245, 169)]
        [Label("Replace Vanilla Music with Eternal Music [c/008060:(WIP)]")]
        [Tooltip("Toggle Between the Vanilla Music and the Eternal Mod Music...\n(Default: Off)")]
        public bool replaceVanillaMusic = false;
    }
}
