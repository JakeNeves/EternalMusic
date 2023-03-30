using Terraria;
using Terraria.ModLoader;
using EternalMusic.Common.Configurations;

namespace EternalMusic.BiomeMusic.VanillaReplace
{
    public class DesertNightSceneEffect : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/MidnightDesertEscapade");

        public override bool IsSceneEffectActive(Player player) => ModContent.GetInstance<ClientConfig>().vanillaMusicReplace && player.ZoneDesert && !Main.dayTime;

        public override SceneEffectPriority Priority => ModContent.GetInstance<ClientConfig>().BiomeScenePriority;
    }
}