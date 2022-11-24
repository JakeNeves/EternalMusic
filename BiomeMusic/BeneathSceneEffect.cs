using Terraria;
using Terraria.ModLoader;
using EternalMusic.Common.Configurations;
using Eternal.Common.Systems;

namespace EternalMusic.BiomeMusic
{
    public class BeneathSceneEffect : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/DarknessFromDeepBelow");

        public override bool IsSceneEffectActive(Player player) => ModContent.GetInstance<ZoneSystem>().zoneBeneath;

        public override SceneEffectPriority Priority => ModContent.GetInstance<ClientConfig>().BiomeScenePriority;
    }
}