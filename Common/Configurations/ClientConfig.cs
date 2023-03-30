using Newtonsoft.Json;
using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace EternalMusic.Common.Configurations
{
    [Label("Eternal Music Client Configuration")]
    public class ClientConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("Replace Vanilla Music")]
        [Tooltip("Replaces Vanilla Music with the Eternal Mod Soundtrack\n(Dafault: Off)")]
        public bool vanillaMusicReplace = false;

        [SeparatePage]
        [Header("Music Priorities")]
        [Label("Boss Music Priority")]
        [Tooltip("This determines the priority of this mod's boss music overrides.\nThe lowest values prevent the music override from being applied, while high values will make the overrides take full priority.")]
        [DefaultValue(MusicConfig.OverrideBosses)]
        public MusicConfig BossPriority { get; set; }

        [Label("Biome Music Priority")]
        [Tooltip("This determines the priority of this mod's biome music override.\nThe lowest values prevent the music override from being applied, while high values will make the overrides take full priority.")]
        [DefaultValue(MusicConfig.OverrideBiomes)]
        public MusicConfig BiomePriority { get; set; }

        [JsonIgnore]
        public SceneEffectPriority BossScenePriority => FromMusicPriority(BossPriority);

        [JsonIgnore]
        public SceneEffectPriority BiomeScenePriority => FromMusicPriority(BiomePriority);

        private static SceneEffectPriority FromMusicPriority(MusicConfig priority) => priority switch
        {
            MusicConfig.DoNotPlay => SceneEffectPriority.None,
            MusicConfig.OverrideBiomes => SceneEffectPriority.BiomeMedium,
            MusicConfig.OverrideBosses => SceneEffectPriority.BossHigh,
            _ => SceneEffectPriority.None
        };
    }
}