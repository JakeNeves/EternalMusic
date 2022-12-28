using Terraria.ModLoader;
using Terraria.ID;
using Eternal.Content.NPCs.Boss;
using Eternal.Content.Biomes;

namespace EternalMusic
{
	public class EternalMusic : Mod
	{
		public override void Load()
		{
			AddContent(new BossMusicEffect("MechanicalMayham", NPCID.SkeletronPrime, NPCID.TheDestroyer, NPCID.Retinazer, NPCID.Spazmatism));
			AddContent(new BossMusicEffect("ApparitionalAccumulation", ModContent.NPCType<Eternal.Content.NPCs.Boss.CosmicApparition.CosmicApparition>()));
			AddContent(new BossMusicEffect("ImperiousStrike", ModContent.NPCType<Eternal.Content.NPCs.Boss.AoI.ArkofImperious>()));

			AddContent(new BossMusicEffect("NeoxPower", ModContent.NPCType<Eternal.Content.NPCs.Boss.NeoxMechs.Atlas>(), ModContent.NPCType<Eternal.Content.NPCs.Boss.NeoxMechs.Polarus>(), ModContent.NPCType<Eternal.Content.NPCs.Boss.NeoxMechs.Orion>()));
		}
	}
}