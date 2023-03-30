using Terraria;
using Terraria.ModLoader;
using EternalMusic.Common.Configurations;

namespace EternalMusic.BiomeMusic.VanillaReplace
{
    public class DesertSceneEffect : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/SandySunshine");

        public override bool IsSceneEffectActive(Player player) => ModContent.GetInstance<ClientConfig>().vanillaMusicReplace && player.ZoneDesert;

        public override SceneEffectPriority Priority => ModContent.GetInstance<ClientConfig>().BiomeScenePriority;
    }
}