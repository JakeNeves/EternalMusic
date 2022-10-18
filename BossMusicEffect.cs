using Terraria;
using Terraria.ModLoader;
using EternalMusic.Common.Configurations;

namespace EternalMusic 
{
    /// <summary>
    /// Replaces existing boss music with custom music
    /// </summary>
    [Autoload(false)]
    public class BossMusicEffect : ModSceneEffect 
    {
        private readonly string musicName;

        private readonly int[] activeNpcIds;

        public BossMusicEffect(string musicName, params int[] activeNpcIds)
        {
            this.musicName = musicName;
            this.activeNpcIds = activeNpcIds;
        }

        public override string Name => base.Name + $"/{musicName}";

        public override int Music => MusicLoader.GetMusicSlot(Mod, $"Assets/Music/{musicName}");

        public override bool IsSceneEffectActive(Player player)
        {
            for (int i = 0; i < activeNpcIds.Length; i++)
            {
                if (NPC.AnyNPCs(activeNpcIds[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public override SceneEffectPriority Priority => ModContent.GetInstance<ClientConfig>().BossScenePriority;
    }
}