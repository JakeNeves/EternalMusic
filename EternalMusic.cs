using Eternal;
using Eternal.NPCs.Boss.AoI;
using Eternal.NPCs.Boss.BionicBosses;
using Eternal.NPCs.Boss.BionicBosses.Omicron;
using Eternal.NPCs.Boss.CarmaniteScouter;
using Eternal.NPCs.Boss.CosmicApparition;
using Eternal.NPCs.Boss.CosmicEmperor;
using Eternal.NPCs.Boss.Dunekeeper;
using Eternal.NPCs.Boss.Incinerius;
using Eternal.NPCs.Boss.InfernoGuardian;
using Eternal.NPCs.Invasion.MechanicalEnvy;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalMusic
{
	public class EternalMusic : Mod
	{
		internal static EternalMusic instance;

		public override void Unload()
		{
			instance = null;
		}

		public override void Load()
		{
			instance = this;

			#region Music Boxes
			AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/ImperiousShrine"), ItemType("LabrynthMusicBox"), TileType("LabrynthMusicBox"));
			AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/PyroneticPurgatory"), ItemType("IncineriusMusicBox"), TileType("IncineriusMusicBox"));
			AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/DarknessFromDeepBelow"), ItemType("BeneathMusicBox"), TileType("BeneathMusicBox"));
			AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/ImperiousStrike"), ItemType("AoIMusicBox"), TileType("AoIMusicBox"));

			AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/DunesWrath"), ItemType("DunekeeperMusicBox"), TileType("DunekeeperMusicBox"));

			#endregion
		}

		public EternalMusic()
		{

			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true,
				AutoloadBackgrounds = true
			};

		}

		public override void UpdateMusic(ref int music, ref MusicPriority priority)
		{
			if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
			{
				return;
			}

			#region Invasion Music
			if (Main.invasionX == Main.spawnTileX)
			{
				if (EternalWorld.mechanicalEnvyUp)
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/MechanicalEnvy");
			}
			#endregion

			#region Modded Music
			if (Main.LocalPlayer.GetModPlayer<EternalPlayer>().ZoneThunderduneBiome)
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/VitreousSandsofThunder");
				priority = MusicPriority.BiomeMedium;
			}

			if (Main.LocalPlayer.GetModPlayer<EternalPlayer>().ZoneCommet)
			{
				if (!ModContent.GetInstance<EternalMusicConfig>().originalMusic)
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/AstralDiscovery");
					priority = MusicPriority.BiomeMedium;
				}
				else
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/ShatteredStar");
					priority = MusicPriority.BiomeMedium;
				}
			}

			if (Main.LocalPlayer.GetModPlayer<EternalPlayer>().ZoneLabrynth)
			{
				if (!ModContent.GetInstance<EternalMusicConfig>().originalMusic)
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/ImperiousShrine");
					priority = MusicPriority.BiomeMedium;
				}
				else
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/MazesAndLivingSwords");
					priority = MusicPriority.BiomeMedium;
				}
			}

			if (Main.LocalPlayer.GetModPlayer<EternalPlayer>().ZoneBeneath)
			{
				if (!ModContent.GetInstance<EternalMusicConfig>().originalMusic)
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/DarknessFromDeepBelow");
					priority = MusicPriority.BiomeMedium;
				}
				else
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/DeepDark");
					priority = MusicPriority.BiomeMedium;
				}
			}

			/*if (Main.LocalPlayer.GetModPlayer<EternalPlayer>().ZoneAshpit)
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/AshFields");
				priority = MusicPriority.BiomeMedium;
			}*/
			#endregion

			#region Vanilla Music Replacement
			if (ModContent.GetInstance<EternalMusicConfig>().replaceVanillaMusic)
			{
				if (Main.musicVolume != 0)
				{
					if (Main.myPlayer != -1 && !Main.gameMenu && Main.LocalPlayer.active)
					{
						Player player = Main.player[Main.myPlayer];
						if (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight && !Main.LocalPlayer.GetModPlayer<EternalPlayer>().ZoneBeneath)
						{
							music = GetSoundSlot(SoundType.Music, "Sounds/Music/VanillaReplace/MysteriousUnderground");
							priority = MusicPriority.Environment;
						}
						if (player.ZoneSnow && !Main.LocalPlayer.GetModPlayer<EternalPlayer>().ZoneCommet)
						{
							if (!Main.dayTime)
							{
								if (Main.raining)
								{
									music = GetSoundSlot(SoundType.Music, "Sounds/Music/VanillaReplace/WinterStorm");
									priority = MusicPriority.BiomeHigh;
								}
								else
								{
									music = GetSoundSlot(SoundType.Music, "Sounds/Music/VanillaReplace/MidnightSnowyFeilds");
									priority = MusicPriority.BiomeHigh;
								}
							}
							else
							{
								if (Main.raining)
								{
									music = GetSoundSlot(SoundType.Music, "Sounds/Music/VanillaReplace/WinterStorm");
									priority = MusicPriority.BiomeHigh;
								}
								else
								{
									music = GetSoundSlot(SoundType.Music, "Sounds/Music/VanillaReplace/WinterWonderland");
									priority = MusicPriority.BiomeHigh;
								}
							}
						}
						if (player.ZoneDungeon)
						{
							music = GetSoundSlot(SoundType.Music, "Sounds/Music/VanillaReplace/CursedKeep");
							priority = MusicPriority.BiomeMedium;
						}

						if (player.ZoneDesert && !Main.LocalPlayer.GetModPlayer<EternalPlayer>().ZoneCommet)
						{
							if (!Main.dayTime)
							{
								music = GetSoundSlot(SoundType.Music, "Sounds/Music/VanillaReplace/MidnightDesertEscapade");
								priority = MusicPriority.BiomeHigh;
							}
							else
							{
								music = GetSoundSlot(SoundType.Music, "Sounds/Music/VanillaReplace/SandySunshine");
								priority = MusicPriority.BiomeHigh;
							}
						}
						if (!Main.LocalPlayer.GetModPlayer<EternalPlayer>().ZoneCommet && !player.ZoneDungeon && !player.ZoneDesert && !player.ZoneSnow)
						{
							if (!Main.dayTime)
							{
								music = GetSoundSlot(SoundType.Music, "Sounds/Music/VanillaReplace/StarlightStarbright");
								priority = MusicPriority.BiomeHigh;
							}
						}

						if (NPC.AnyNPCs(NPCID.Retinazer) || NPC.AnyNPCs(NPCID.Spazmatism) || NPC.AnyNPCs(NPCID.TheDestroyer) || NPC.AnyNPCs(NPCID.SkeletronPrime))
						{
							music = GetSoundSlot(SoundType.Music, "Sounds/Music/VanillaReplace/MechanicalMayham");
							priority = MusicPriority.BossHigh;
						}
					}
				}
			}
			#endregion

			#region Boss Music
			if (NPC.AnyNPCs(ModContent.NPCType<Atlas>()) || NPC.AnyNPCs(ModContent.NPCType<Borealis>()) || NPC.AnyNPCs(ModContent.NPCType<Omicron>()) || NPC.AnyNPCs(ModContent.NPCType<Orion>()) || NPC.AnyNPCs(ModContent.NPCType<Photon>()) || NPC.AnyNPCs(ModContent.NPCType<Proton>()) || NPC.AnyNPCs(ModContent.NPCType<Polarus>()) || NPC.AnyNPCs(ModContent.NPCType<Quasar>()))
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/ExoMenace");
				priority = MusicPriority.BossHigh;
			}

			if (NPC.AnyNPCs(ModContent.NPCType<AtlasNeox>()) || NPC.AnyNPCs(ModContent.NPCType<BorealisNeox>()) || NPC.AnyNPCs(ModContent.NPCType<OmicronNeox>()) || NPC.AnyNPCs(ModContent.NPCType<OrionNeox>()) || NPC.AnyNPCs(ModContent.NPCType<PhotonNeox>()) || NPC.AnyNPCs(ModContent.NPCType<ProtonNeox>()) || NPC.AnyNPCs(ModContent.NPCType<PolarusNeox>()) || NPC.AnyNPCs(ModContent.NPCType<QuasarNeox>()))
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/NeoxPower");
				priority = MusicPriority.BossHigh;
			}

			if (NPC.AnyNPCs(ModContent.NPCType<ArkofImperious>()))
            {
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/ImperiousStrike");
				priority = MusicPriority.BossHigh;
			}

			if (NPC.AnyNPCs(ModContent.NPCType<MegaCuboidWardingDrone>()))
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/MechanicalEnvy");
				priority = MusicPriority.BossHigh;
			}

			if (NPC.AnyNPCs(ModContent.NPCType<CosmicApparition>()))
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/ApparitionalAccumulation");
				priority = MusicPriority.BossHigh;
			}

			if (NPC.AnyNPCs(ModContent.NPCType<CarmaniteScouter>()) || NPC.AnyNPCs(ModContent.NPCType<InfernoGuardian>()))
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/UnfatefulStrike");
				priority = MusicPriority.BossHigh;
			}

			if (NPC.AnyNPCs(ModContent.NPCType<Dunekeeper>()))
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/DunesWrath");
				priority = MusicPriority.BossHigh;
			}

			if (NPC.AnyNPCs(ModContent.NPCType<Incinerius>()) || NPC.AnyNPCs(ModContent.NPCType<TrueIncinerius>()))
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/PyroneticPurgatory");
				priority = MusicPriority.BossHigh;
			}

			if (NPC.AnyNPCs(ModContent.NPCType<CosmicEmperorMask>()))
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/JourneysConquest");
				priority = MusicPriority.BossHigh;
			}

			if (NPC.AnyNPCs(ModContent.NPCType<CosmicEmperor>()))
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/PlayingPuny");
				priority = MusicPriority.BossHigh;
			}

			if (NPC.AnyNPCs(ModContent.NPCType<CosmicEmperorP3>()))
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/VisionofTerminus");
				priority = MusicPriority.BossHigh;
			}
			#endregion

		}
    }
}