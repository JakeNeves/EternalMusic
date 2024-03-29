using Terraria;
using Terraria.ModLoader;
using EternalMusic.Common.Configurations;

namespace EternalMusic.BiomeMusic.VanillaReplace
{
    public class SnowNightSceneEffect : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/MidnightSnowyFeIlds");

        public override bool IsSceneEffectActive(Player player) => ModContent.GetInstance<ClientConfig>().vanillaMusicReplace && player.ZoneSnow && !Main.dayTime;

        public override SceneEffectPriority Priority => ModContent.GetInstance<ClientConfig>().BiomeScenePriority;
    }
}