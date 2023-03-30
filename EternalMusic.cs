using Terraria.ModLoader;
using Terraria.ID;
using EternalMusic.Common.Configurations;

namespace EternalMusic
{
	public class EternalMusic : Mod
	{
		public override void Load()
		{
			#region Replace Vanilla Music with Eternal Music
			if (ModContent.GetInstance<ClientConfig>().vanillaMusicReplace) {
				// M3CH4N1C4L M4YH4M
				AddContent(new BossMusicEffect("MechanicalMayham", NPCID.SkeletronPrime, NPCID.TheDestroyer, NPCID.Retinazer, NPCID.Spazmatism));

				// Vulgarous Devistation
				AddContent(new BossMusicEffect("VulgarousDevistation", NPCID.KingSlime, NPCID.EyeofCthulhu, NPCID.EaterofWorldsHead, NPCID.BrainofCthulhu, NPCID.QueenBee, NPCID.SkeletronHead, NPCID.Deerclops));
			}
			#endregion

			AddContent(new BossMusicEffect("ApparitionalAccumulation", ModContent.NPCType<Eternal.Content.NPCs.Boss.CosmicApparition.CosmicApparition>()));
			AddContent(new BossMusicEffect("ImperiousStrike", ModContent.NPCType<Eternal.Content.NPCs.Boss.AoI.ArkofImperious>()));

			AddContent(new BossMusicEffect("NeoxPower", ModContent.NPCType<Eternal.Content.NPCs.Boss.NeoxMechs.Atlas>(), ModContent.NPCType<Eternal.Content.NPCs.Boss.NeoxMechs.Polarus>(), ModContent.NPCType<Eternal.Content.NPCs.Boss.NeoxMechs.Orion>()));
		}
	}
}