using Terraria;
using Terraria.ModLoader;
using EternalMusic.Common.Configurations;
using Eternal.Common.Systems;

namespace EternalMusic.BiomeMusic
{
    public class CometSceneEffect : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/AstralDiscovery");

        public override bool IsSceneEffectActive(Player player) => ModContent.GetInstance<ZoneSystem>().zoneComet;

        public override SceneEffectPriority Priority => ModContent.GetInstance<ClientConfig>().BiomeScenePriority;
    }
}