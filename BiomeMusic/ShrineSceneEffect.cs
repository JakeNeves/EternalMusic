using Terraria;
using Terraria.ModLoader;
using EternalMusic.Common.Configurations;
using Eternal.Common.Systems;

namespace EternalMusic.BiomeMusic
{
    public class ShrineSceneEffect : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/ImperiousShrine");

        public override bool IsSceneEffectActive(Player player) => ModContent.GetInstance<ZoneSystem>().zoneShrine;

        public override SceneEffectPriority Priority => ModContent.GetInstance<ClientConfig>().BiomeScenePriority;
    }
}