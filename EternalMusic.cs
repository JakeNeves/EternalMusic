using Eternal;
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
			if (!ModContent.GetInstance<EternalMusicConfig>().originalMusic)
			{
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/New/ImperiousShrine"), ItemType("LabrynthMusicBox"), TileType("LabrynthMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/New/PyroneticPurgatory"), ItemType("IncineriusMusicBox"), TileType("IncineriusMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/New/DarknessFromDeepBelow"), ItemType("BeneathMusicBox"), TileType("BeneathMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/New/ImperiousStrike"), ItemType("AoIMusicBox"), TileType("AoIMusicBox"));
			}
			else
			{
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/MazesAndLivingSwords"), ItemType("LabrynthMusicBox"), TileType("LabrynthMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/DeepDark"), ItemType("BeneathMusicBox"), TileType("BeneathMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/FieryBattler"), ItemType("IncineriusMusicBox"), TileType("IncineriusMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/BladeofBrutality"), ItemType("AoIMusicBox"), TileType("AoIMusicBox"));
			}


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

			#region Modded Music
			if (Main.LocalPlayer.GetModPlayer<EternalPlayer>().ZoneThunderduneBiome)
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/VitreousSandsofThunder");
				priority = MusicPriority.BiomeMedium;
			}

			if (Main.LocalPlayer.GetModPlayer<EternalPlayer>().ZoneCommet)
			{
				if (!ModContent.GetInstance<EternalConfig>().originalMusic)
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/New/AstralDiscovery");
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
				if (!ModContent.GetInstance<EternalConfig>().originalMusic)
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/New/ImperiousShrine");
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
				if (!ModContent.GetInstance<EternalConfig>().originalMusic)
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/New/DarknessFromDeepBelow");
					priority = MusicPriority.BiomeMedium;
				}
				else
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/DeepDark");
					priority = MusicPriority.BiomeMedium;
				}
			}

			if (Main.LocalPlayer.GetModPlayer<EternalPlayer>().ZoneAshpit)
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/AshFields");
				priority = MusicPriority.BiomeMedium;
			}
			#endregion

			#region Vanilla Music Replacement
			if (ModContent.GetInstance<EternalConfig>().replaceVanillaMusic)
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

		}
	}
}