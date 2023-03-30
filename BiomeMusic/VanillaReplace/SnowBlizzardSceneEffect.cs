using Terraria;
using Terraria.ModLoader;
using EternalMusic.Common.Configurations;

namespace EternalMusic.BiomeMusic.VanillaReplace
{
    public class SnowBlizzardSceneEffect : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/WinterStorm");

        public override bool IsSceneEffectActive(Player player) => ModContent.GetInstance<ClientConfig>().vanillaMusicReplace && player.ZoneSnow && Main.raining;

        public override SceneEffectPriority Priority => ModContent.GetInstance<ClientConfig>().BiomeScenePriority;
    }
}