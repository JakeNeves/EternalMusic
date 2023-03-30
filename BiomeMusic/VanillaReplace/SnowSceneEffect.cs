using Terraria;
using Terraria.ModLoader;
using EternalMusic.Common.Configurations;

namespace EternalMusic.BiomeMusic.VanillaReplace
{
    public class SnowSceneEffect : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/WinterWonderland");

        public override bool IsSceneEffectActive(Player player) => ModContent.GetInstance<ClientConfig>().vanillaMusicReplace && player.ZoneSnow;

        public override SceneEffectPriority Priority => ModContent.GetInstance<ClientConfig>().BiomeScenePriority;
    }
}