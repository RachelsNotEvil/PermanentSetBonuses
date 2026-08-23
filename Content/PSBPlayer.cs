using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using PermanentSetBonuses.IO;
using System.Collections.Generic;
using PermanentSetBonuses.Config;

namespace PermanentSetBonuses.Content
{
	public enum ArmorSet
	{
		Wood,
		BorealWood,
		PalmWood,
		RichMahogany,
		Copper,
		Tin,
		Iron,
		Lead,
		Ebonwood,
		Shadewood,
		Silver,
		Tungsten,
		Gold,
		Platinum,
		Cactus,
		Pumpkin,
		Ninja,
		Wizard
	}

	public struct ArmorSetParameters
	{
		//Empty array will indicate any equipment is valid for that slot.
		public int[] validHelmets;
		public int[] validChests;
		public int[] validGreaves;
		public int maxXP;
		public byte textR;
		public byte textG;
		public byte textB;
		public int[] bonusWeapons;
		public bool enabled;
	}

	public class PSBPlayer : ModPlayer
	{
		//EXP values for each of the armor sets
		public int[] setXP;
		public bool[] activeSets;
		protected ArmorSet? armorSet;
		protected bool expBonus;
		protected int maxXP;
		protected byte textR;
		protected byte textG;
		protected byte textB;
		public Dictionary<ArmorSet, ArmorSetParameters> armorData;

		//Set up initial/default state
		public override void SetStaticDefaults()
		{
			if (setXP == null)
			{
				setXP = new int[System.Enum.GetNames(typeof(ArmorSet)).Length];
			}
			if (activeSets == null)
			{
				activeSets = new bool[setXP.Length];
			}
			armorSet = null;
			expBonus = false;
			maxXP = 0;
			textR = 240;
			textG = 240;
			textB = 240;
			armorData = InitialArmorData();
		}

		public Dictionary<ArmorSet, ArmorSetParameters> InitialArmorData()
		{
			return new Dictionary<ArmorSet, ArmorSetParameters>()
			{
				{ArmorSet.Wood, new ArmorSetParameters { validHelmets = new int[] {ItemID.WoodHelmet}, validChests = new int[] {ItemID.WoodBreastplate}, validGreaves = new int[] {ItemID.WoodGreaves}, maxXP = ModContent.GetInstance<ArmorSetConfig>().WoodEXP, textR = 151, textG = 107, textB = 75, bonusWeapons = new int[] {ItemID.WoodenSword, ItemID.WoodenBow, ItemID.WoodenHammer, ItemID.WoodYoyo}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnableWood}},
				{ArmorSet.BorealWood, new ArmorSetParameters { validHelmets = new int[] {ItemID.BorealWoodHelmet}, validChests = new int[] {ItemID.BorealWoodBreastplate}, validGreaves = new int[] {ItemID.BorealWoodGreaves}, maxXP = ModContent.GetInstance<ArmorSetConfig>().BorealEXP, textR = 107, textG = 86, textB = 71, bonusWeapons = new int[] {ItemID.BorealWoodSword, ItemID.BorealWoodBow, ItemID.BorealWoodHammer, ItemID.WoodYoyo}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnableBorealWood}},
				{ArmorSet.PalmWood, new ArmorSetParameters { validHelmets = new int[] {ItemID.PalmWoodHelmet}, validChests = new int[] {ItemID.PalmWoodBreastplate}, validGreaves = new int[] {ItemID.PalmWoodGreaves}, maxXP = ModContent.GetInstance<ArmorSetConfig>().PalmEXP, textR = 182, textG = 141, textB = 86, bonusWeapons = new int[] {ItemID.PalmWoodBow, ItemID.PalmWoodSword, ItemID.PalmWoodHammer, ItemID.WoodYoyo}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnablePalmWood}},
				{ArmorSet.RichMahogany, new ArmorSetParameters { validHelmets = new int[] {ItemID.RichMahoganyHelmet}, validChests = new int[] {ItemID.RichMahoganyBreastplate}, validGreaves = new int[] {ItemID.RichMahoganyGreaves}, maxXP = ModContent.GetInstance<ArmorSetConfig>().MahoganyEXP, textR = 163, textG = 99, textB = 104, bonusWeapons = new int[] {ItemID.RichMahoganyBow, ItemID.RichMahoganySword, ItemID.RichMahoganyHammer, ItemID.WoodYoyo}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnableMahogany}},
				{ArmorSet.Copper, new ArmorSetParameters { validHelmets = new int[] {ItemID.CopperHelmet}, validChests = new int[] {ItemID.CopperChainmail}, validGreaves = new int[] {ItemID.CopperGreaves}, maxXP = ModContent.GetInstance<ArmorSetConfig>().CopperEXP, textR = 255, textG = 146, textB = 97, bonusWeapons = new int[] {ItemID.CopperAxe, ItemID.CopperBow, ItemID.CopperHammer, ItemID.CopperPickaxe, ItemID.CopperShortsword, ItemID.CopperBroadsword, ItemID.AmethystStaff}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnableCopper}},
				{ArmorSet.Tin, new ArmorSetParameters { validHelmets = new int[] {ItemID.TinHelmet}, validChests = new int[] {ItemID.TinChainmail}, validGreaves = new int[] {ItemID.TinGreaves}, maxXP = ModContent.GetInstance<ArmorSetConfig>().TinEXP, textR = 228, textG = 219, textB = 162, bonusWeapons = new int[] {ItemID.TinAxe, ItemID.TinBow, ItemID.TinHammer, ItemID.TinPickaxe, ItemID.TinShortsword, ItemID.TinBroadsword, ItemID.TopazStaff}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnableTin}},
				{ArmorSet.Iron, new ArmorSetParameters { validHelmets = new int[] {ItemID.IronHelmet, ItemID.AncientIronHelmet}, validChests = new int[] {ItemID.IronChainmail}, validGreaves = new int[] {ItemID.IronGreaves}, maxXP = ModContent.GetInstance<ArmorSetConfig>().IronEXP, textR = 181, textG = 164, textB = 149, bonusWeapons = new int[] {ItemID.IronAxe, ItemID.IronBow, ItemID.IronPickaxe, ItemID.IronHammer, ItemID.IronShortsword, ItemID.IronBroadsword}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnableIron}},
				{ArmorSet.Lead, new ArmorSetParameters { validHelmets = new int[] {ItemID.LeadHelmet}, validChests = new int[] {ItemID.LeadChainmail}, validGreaves = new int[] {ItemID.LeadGreaves}, maxXP = ModContent.GetInstance<ArmorSetConfig>().LeadEXP, textR = 142, textG = 161, textB = 158, bonusWeapons = new int[] {ItemID.LeadBow, ItemID.LeadAxe, ItemID.LeadPickaxe, ItemID.LeadHammer, ItemID.LeadShortsword, ItemID.LeadBroadsword}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnableLead}},
				{ArmorSet.Ebonwood, new ArmorSetParameters { validHelmets = new int[] {ItemID.EbonwoodHelmet}, validChests = new int[] {ItemID.EbonwoodBreastplate}, validGreaves = new int[] {ItemID.EbonwoodGreaves}, maxXP = ModContent.GetInstance<ArmorSetConfig>().EbonEXP, textR = 153, textG = 137, textB = 165, bonusWeapons = new int[] {ItemID.EbonwoodBow, ItemID.EbonwoodHammer, ItemID.EbonwoodSword, ItemID.WoodYoyo}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnableEbonwood}},
				{ArmorSet.Shadewood, new ArmorSetParameters { validHelmets = new int[] {ItemID.ShadewoodHelmet}, validChests = new int[] {ItemID.ShadewoodBreastplate}, validGreaves = new int[] {ItemID.ShadewoodGreaves}, maxXP = ModContent.GetInstance<ArmorSetConfig>().ShadeEXP, textR = 117, textG = 134, textB = 149, bonusWeapons = new int[] {ItemID.ShadewoodBow, ItemID.ShadewoodHammer, ItemID.ShadewoodSword, ItemID.WoodYoyo}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnableShadewood}},
				{ArmorSet.Silver, new ArmorSetParameters { validHelmets = new int[] {ItemID.SilverHelmet}, validChests = new int[] {ItemID.SilverChainmail}, validGreaves = new int[] {ItemID.SilverGreaves}, maxXP = ModContent.GetInstance<ArmorSetConfig>().SilverEXP, textR = 171, textG = 182, textB = 183, bonusWeapons = new int[] {ItemID.SilverAxe, ItemID.SilverPickaxe, ItemID.SilverHammer, ItemID.SilverBow, ItemID.SilverShortsword, ItemID.SilverBroadsword, ItemID.SapphireStaff}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnableSilver}},
				{ArmorSet.Tungsten, new ArmorSetParameters { validHelmets = new int[] {ItemID.TungstenHelmet}, validChests = new int[] {ItemID.TungstenChainmail}, validGreaves = new int[] {ItemID.TungstenGreaves}, maxXP = ModContent.GetInstance<ArmorSetConfig>().TungstenEXP, textR = 202, textG = 233, textB = 207, bonusWeapons = new int[] {ItemID.TungstenAxe, ItemID.TungstenPickaxe, ItemID.TungstenHammer, ItemID.TungstenBow, ItemID.TungstenShortsword, ItemID.TungstenBroadsword, ItemID.EmeraldStaff}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnableTungsten}},
				{ArmorSet.Gold, new ArmorSetParameters { validHelmets = new int[] {ItemID.GoldHelmet, ItemID.AncientGoldHelmet}, validChests = new int[] {ItemID.GoldChainmail}, validGreaves = new int[] {ItemID.GoldGreaves}, maxXP = ModContent.GetInstance<ArmorSetConfig>().GoldEXP, textR = 255, textG = 249, textB = 183, bonusWeapons = new int[] {ItemID.GoldAxe, ItemID.GoldPickaxe, ItemID.GoldHammer, ItemID.GoldBow, ItemID.GoldShortsword, ItemID.GoldBroadsword, ItemID.FlinxStaff, ItemID.RubyStaff}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnableGold}},
				{ArmorSet.Platinum, new ArmorSetParameters { validHelmets = new int[] {ItemID.PlatinumHelmet}, validChests = new int[] {ItemID.PlatinumChainmail}, validGreaves = new int[] {ItemID.PlatinumGreaves}, maxXP = ModContent.GetInstance<ArmorSetConfig>().PlatinumEXP, textR = 246, textG = 216, textB = 235, bonusWeapons = new int[] {ItemID.PlatinumAxe, ItemID.PlatinumPickaxe, ItemID.PlatinumHammer, ItemID.PlatinumBow, ItemID.PlatinumShortsword, ItemID.PlatinumBroadsword, ItemID.FlinxStaff, ItemID.DiamondStaff}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnablePlatinum}},
				{ArmorSet.Cactus, new ArmorSetParameters {validHelmets = new int[] {ItemID.CactusHelmet}, validChests = new int[] {ItemID.CactusBreastplate}, validGreaves = new int[] {ItemID.CactusLeggings}, maxXP = ModContent.GetInstance<ArmorSetConfig>().CactusEXP, textR = 120, textG = 250, textB = 120, bonusWeapons = new int[] {ItemID.CactusPickaxe, ItemID.CactusSword}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnableCactus}},
				{ArmorSet.Pumpkin, new ArmorSetParameters {validHelmets = new int[] {ItemID.PumpkinHelmet}, validChests = new int[] {ItemID.PumpkinBreastplate}, validGreaves = new int[] {ItemID.PumpkinLeggings}, maxXP = ModContent.GetInstance<ArmorSetConfig>().PumpkinEXP, textR = 200, textG = 150, textB = 100, bonusWeapons = new int[] {ItemID.TheHorsemansBlade, ItemID.JackOLanternLauncher}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnablePumpkin}},
				{ArmorSet.Ninja, new ArmorSetParameters {validHelmets = new int[] {ItemID.NinjaHood}, validChests = new int[] {ItemID.NinjaShirt}, validGreaves = new int[] {ItemID.NinjaPants}, maxXP = ModContent.GetInstance<ArmorSetConfig>().NinjaEXP, textR = 190, textG = 190, textB = 200, bonusWeapons = new int[] {ItemID.SlimeGun, ItemID.SlimeStaff, ItemID.Shuriken, ItemID.Katana}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnableNinja}},
				{ArmorSet.Wizard, new ArmorSetParameters {validHelmets = new int[] {ItemID.WizardHat, ItemID.MagicHat}, validChests = new int[] {ItemID.AmethystRobe, ItemID.TopazRobe, ItemID.SapphireRobe, ItemID.EmeraldRobe, ItemID.RubyRobe, ItemID.AmberRobe, ItemID.DiamondRobe, ItemID.GypsyRobe}, validGreaves = new int[] {}, maxXP = ModContent.GetInstance<ArmorSetConfig>().WizardEXP, textR = 250, textG = 250, textB = 250, bonusWeapons = new int[] {ItemID.AmethystStaff, ItemID.TopazStaff, ItemID.SapphireStaff, ItemID.EmeraldStaff, ItemID.RubyStaff, ItemID.AmberStaff, ItemID.DiamondStaff}, enabled = ModContent.GetInstance<ArmorSetConfig>().EnableWizard}}
			};
		}

		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (XPViewKeybinds.CheckCurrentSet.JustPressed)
			{
				if (armorSet == null)
				{
					Main.NewText("No armor set is equipped.");
				} else
				{
					Main.NewText(setXP[(int)armorSet] + " / " + maxXP + " EXP to master " + armorSet, textR, textG, textB);
				}
			}
		}

		//Does the checks for if this NPC is able to gain EXP toward an armor set and awards that EXP
		public void ClaimKill(Player player, NPC npc)
		{
			int expAward = GetEXP(npc);
			if (expBonus)
			{
				if (Main.hardMode)
				{
					expAward = (int)((double)expAward * 1.25);
				} else
				{
					expAward = (int)((double)expAward * 1.1);
				}
			}

			if (armorSet != null)
			{
				//This whole block of code right here is a good argument for switching from null
				//to a "None" value.
				if (!armorData[(ArmorSet)armorSet].enabled)
				{
					return;
				}
				if (setXP[(int)armorSet] < maxXP)
				{
					setXP[(int)armorSet] += expAward;
					//If this is our first time reaching max, get an award
					if (setXP[(int)armorSet] >= maxXP)
					{
						setXP[(int)armorSet] = maxXP;
						activeSets[(int)armorSet] = true;
						if (player.whoAmI == Main.myPlayer)
						{
							//Replace this with a new method: SendMaxMessage()
							Main.NewText("A new armor was mastered!", textR, textG, textB);
						}
					}
				}
			}
		}//end ClaimKill

		public override void PostUpdateEquips()
		{
			ArmorSet? newSet = null;
			bool newExpBonus = false;
			//Player player = Main.LocalPlayer;
			if (armorData == null)
			{
				armorData = InitialArmorData();
			}
			foreach (KeyValuePair<ArmorSet, ArmorSetParameters> checkedSet in armorData)
			{
				ArmorSet set = checkedSet.Key;
				ArmorSetParameters setParams = checkedSet.Value;
				bool headMatch = false;
				bool chestMatch = false;
				bool legsMatch = false;
				if (setParams.validHelmets.Length == 0)
				{
					headMatch = true;
				} else 
				{
					foreach (int helmet in setParams.validHelmets)
					{
						if (helmet == Player.armor[0].type)
						{
							headMatch = true;
							break;
						}
					}
				}
				if (setParams.validChests.Length == 0)
				{
					chestMatch = true;
				} else
				{
					foreach (int chest in setParams.validChests)
					{
						if (chest == Player.armor[1].type)
						{
							chestMatch = true;
							break;
						}
					}
				}
				if (setParams.validGreaves.Length == 0)
				{
					legsMatch = true;
				} else
				{
					foreach (int legs in setParams.validGreaves)
					{
						if (legs == Player.armor[2].type)
						{
							legsMatch = true;
							break;
						}
					}
				}
				if (headMatch && chestMatch && legsMatch)
				{
					textR = setParams.textR;
					textG = setParams.textG;
					textB = setParams.textB;
					maxXP = setParams.maxXP;
					newSet = set;
				}
			}//end armor type search loop

			if (newSet == null)
			{
				textR = 240;
				textG = 240;
				textB = 240;
			} else
			{
				foreach (int weapon in armorData[newSet ?? ArmorSet.Wood].bonusWeapons)
				{
					if (weapon == Player.HeldItem.type)
					{
						newExpBonus = true;
						break;
					}
				}
			}

			armorSet = newSet;
			expBonus = newExpBonus;
		}//end PostUpdateEquips

		//Returns the EXP award amount based on the enemy type
		protected static int GetEXP(NPC npc)
		{
			if (npc.friendly || npc.townNPC || npc.isLikeATownNPC || npc.CountsAsACritter)
			{
				return 0;
			}
			switch (npc.type)
			{
				case NPCID.JungleSlime:
				case NPCID.PurpleSlime:
				case NPCID.BlackSlime:
				case NPCID.DemonEye:
				case NPCID.Zombie:
				case NPCID.BigTwiggyZombie:
				case NPCID.SmallTwiggyZombie:
				case NPCID.BigSwampZombie:
				case NPCID.SmallSwampZombie:
				case NPCID.BigSlimedZombie:
				case NPCID.SmallSlimedZombie:
				case NPCID.BigPincushionZombie:
				case NPCID.SmallPincushionZombie:
				case NPCID.BigBaldZombie:
				case NPCID.SmallBaldZombie:
				case NPCID.BigZombie:
				case NPCID.SmallZombie:
				case NPCID.CaveBat:
				case NPCID.Piranha:
				case NPCID.Vulture:
				case NPCID.IceSlime:
				case NPCID.ZombieEskimo:
				case NPCID.SnowFlinx:
				case NPCID.PincushionZombie:
				case NPCID.SlimedZombie:
				case NPCID.SwampZombie:
				case NPCID.TwiggyZombie:
				case NPCID.CataractEye:
				case NPCID.SleepyEye:
				case NPCID.DialatedEye:
				case NPCID.GreenEye:
				case NPCID.PurpleEye:
				case NPCID.DemonEye2:
				case NPCID.PurpleEye2:
				case NPCID.GreenEye2:
				case NPCID.DialatedEye2:
				case NPCID.SleepyEye2:
				case NPCID.CataractEye2:
				case NPCID.FemaleZombie:
				case NPCID.CochinealBeetle:
				case NPCID.CyanBeetle:
				case NPCID.LacBeetle:
				case NPCID.ZombieRaincoat:
				case NPCID.UmbrellaSlime:
				case NPCID.Raven:
				case NPCID.DemonEyeOwl:
				case NPCID.DemonEyeSpaceship:
				case NPCID.ZombieDoctor:
				case NPCID.ZombieSuperman:
				case NPCID.ZombiePixie:
				case NPCID.ZombieXmas:
				case NPCID.ZombieSweater:
				case NPCID.GraniteFlyer:
				case NPCID.TorchZombie:
				case NPCID.Dandelion:
				case NPCID.MaggotZombie:
				case NPCID.Skeleton:
				case NPCID.HeadacheSkeleton:
				case NPCID.MisassembledSkeleton:
				case NPCID.PantlessSkeleton:
				case NPCID.MeteorHead:
				case NPCID.GoblinThief:
				case NPCID.UndeadMiner:
				case NPCID.Antlion:
				case NPCID.SeaSnail:
				case NPCID.Squid:
				case NPCID.SandSlime:
				case NPCID.FlyingAntlion:
				case NPCID.BigPantlessSkeleton:
				case NPCID.SmallPantlessSkeleton:
				case NPCID.BigMisassembledSkeleton:
				case NPCID.SmallMisassembledSkeleton:
				case NPCID.BigHeadacheSkeleton:
				case NPCID.SmallHeadacheSkeleton:
				case NPCID.SmallSkeleton:
					return 11;
				case NPCID.BigEater:
				case NPCID.LittleEater:
				case NPCID.EaterofSouls:
				case NPCID.GiantWormHead:
				case NPCID.GoblinWarrior:
				case NPCID.GoblinSorcerer:
				case NPCID.ManEater:
				case NPCID.JungleBat:
				case NPCID.Snatcher:
				case NPCID.BlueJellyfish:
				case NPCID.PinkJellyfish:
				case NPCID.GreenJellyfish:
				case NPCID.GoblinArcher:
				case NPCID.IceBat:
				case NPCID.WallCreeper:
				case NPCID.WallCreeperWall:
				case NPCID.UndeadViking:
				case NPCID.Crimera:
				case NPCID.FaceMonster:
				case NPCID.SpikedIceSlime:
				case NPCID.BloodCrawler:
				case NPCID.BloodCrawlerWall:
				case NPCID.ZombieMushroom:
				case NPCID.ZombieMushroomHat:
				case NPCID.ArmedZombie:
				case NPCID.ArmedZombieEskimo:
				case NPCID.ArmedZombiePincussion:
				case NPCID.ArmedZombieSlimed:
				case NPCID.ArmedZombieSwamp:
				case NPCID.ArmedZombieTwiggy:
				case NPCID.ArmedZombieCenx:
				case NPCID.BoneThrowingSkeleton:
				case NPCID.BoneThrowingSkeleton2:
				case NPCID.BoneThrowingSkeleton3:
				case NPCID.BoneThrowingSkeleton4:
				case NPCID.GraniteGolem:
				case NPCID.BloodZombie:
				case NPCID.Drippler:
				case NPCID.Crawdad:
				case NPCID.Crawdad2:
				case NPCID.GiantFlyingAntlion:
				case NPCID.WalkingAntlion:
				case NPCID.ArmedTorchZombie:
				case NPCID.SporeSkeleton:
				case NPCID.BigCrimera:
				case NPCID.LittleCrimera:
				case NPCID.DoctorBones:
				case NPCID.TheGroom:
					return 12;
				case NPCID.SpikedJungleSlime:
				case NPCID.JungleCreeper:
				case NPCID.JungleCreeperWall:
				case NPCID.AnomuraFungus:
				case NPCID.MushiLadybug:
				case NPCID.FungiBulb:
				case NPCID.Ghost:
				case NPCID.GreekSkeleton:
				case NPCID.GiantShelly:
				case NPCID.GiantShelly2:
				case NPCID.Salamander:
				case NPCID.Salamander2:
				case NPCID.Salamander3:
				case NPCID.Salamander4:
				case NPCID.Salamander5:
				case NPCID.Salamander6:
				case NPCID.Salamander7:
				case NPCID.Salamander8:
				case NPCID.Salamander9:
				case NPCID.GiantWalkingAntlion:
				case NPCID.TombCrawlerHead:
				case NPCID.LittleHornetStingy:
				case NPCID.LittleHornetSpikey:
				case NPCID.LittleHornetLeafy:
				case NPCID.LittleHornetHoney:
				case NPCID.LittleHornetFatty:
				case NPCID.LittleStinger:
				case NPCID.AngryBones:
				case NPCID.CursedSkull:
				case NPCID.Hornet:
				case NPCID.HornetFatty:
				case NPCID.HornetHoney:
				case NPCID.HornetLeafy:
				case NPCID.HornetSpikey:
				case NPCID.HornetStingy:
					return 13;
				case NPCID.BigHornetStingy:
				case NPCID.BigHornetSpikey:
				case NPCID.BigHornetLeafy:
				case NPCID.BigHornetHoney:
				case NPCID.BigHornetFatty:
				case NPCID.BigStinger:
				case NPCID.DarkCaster:
					return 14;
				case NPCID.DevourerHead:
				case NPCID.Tim:
				case NPCID.EyeballFlyingFish:
				case NPCID.Nymph:
					return 15;
				case NPCID.ZombieMerman:
				case NPCID.Harpy:
					return 16;
				case NPCID.BlueSlime:
				case NPCID.Creeper:
					return 8;
				case NPCID.GreenSlime:
				case NPCID.ServantofCthulhu:
				case NPCID.Bee:
				case NPCID.EaterofWorldsHead:
					return 5;
				case NPCID.BeeSmall:
					return 4;
				case NPCID.KingSlime:
				case NPCID.BrainofCthulhu:
					return 20;
				case NPCID.EyeofCthulhu:
					return 25;
				default:
					return 10;
			}
		}//end GetEXP

		protected void ApplyBuff(ArmorSet armorSet)
		{
			switch (armorSet)
			{
				case ArmorSet.Wood:
				case ArmorSet.BorealWood:
				case ArmorSet.PalmWood:
				case ArmorSet.RichMahogany:
				case ArmorSet.Ebonwood:
				case ArmorSet.Shadewood:
					Player.statDefense += 1;
					break;
				case ArmorSet.Copper:
				case ArmorSet.Tin:
				case ArmorSet.Iron:
					Player.statDefense += 2;
					break;
				case ArmorSet.Lead:
				case ArmorSet.Silver:
				case ArmorSet.Tungsten:
				case ArmorSet.Gold:
					Player.statDefense += 3;
					break;
				case ArmorSet.Platinum:
					Player.statDefense += 4;
					break;
				case ArmorSet.Pumpkin:
					Player.GetDamage<GenericDamageClass>() += 0.1f;
					break;
				case ArmorSet.Ninja:
					Player.moveSpeed += 0.2f;
					break;
			}
		}//end ApplyBuff

		public override void PostUpdateMiscEffects()
		{
			if (setXP == null)
			{
				setXP = new int[System.Enum.GetNames(typeof(ArmorSet)).Length];
			}
			//check for armor sets and apply buffs
			if (activeSets[(int)ArmorSet.Wood])
			{
				ApplyBuff(ArmorSet.Wood);
			}
			if (activeSets[(int)ArmorSet.BorealWood])
			{
				ApplyBuff(ArmorSet.BorealWood);
			}
			if (activeSets[(int)ArmorSet.PalmWood])
			{
				ApplyBuff(ArmorSet.PalmWood);
			}
			if (activeSets[(int)ArmorSet.RichMahogany])
			{
				ApplyBuff(ArmorSet.RichMahogany);
			}
			if (activeSets[(int)ArmorSet.Copper])
			{
				ApplyBuff(ArmorSet.Copper);
			}
			if (activeSets[(int)ArmorSet.Tin])
			{
				ApplyBuff(ArmorSet.Tin);
			}
			if (activeSets[(int)ArmorSet.Iron])
			{
				ApplyBuff(ArmorSet.Iron);
			}
			if (activeSets[(int)ArmorSet.Lead])
			{
				ApplyBuff(ArmorSet.Lead);
			}
			if (activeSets[(int)ArmorSet.Ebonwood])
			{
				ApplyBuff(ArmorSet.Ebonwood);
			}
			if (activeSets[(int)ArmorSet.Shadewood])
			{
				ApplyBuff(ArmorSet.Shadewood);
			}
			if (activeSets[(int)ArmorSet.Silver])
			{
				ApplyBuff(ArmorSet.Silver);
			}
			if (activeSets[(int)ArmorSet.Tungsten])
			{
				ApplyBuff(ArmorSet.Tungsten);
			}
			if (activeSets[(int)ArmorSet.Pumpkin])
			{
				ApplyBuff(ArmorSet.Pumpkin);
			}
			if (activeSets[(int)ArmorSet.Ninja])
			{
				ApplyBuff(ArmorSet.Ninja);
			}
		}//end PostUpdateMiscEffects

		public override void OnHitByNPC (NPC npc, Player.HurtInfo hurtInfo)
		{
			//Modeled loosely on vanilla cactus thorn damage code
			int npcID = npc.whoAmI;
			if (Player.whoAmI == Main.myPlayer && activeSets[(int)ArmorSet.Cactus] && !Main.npc[npcID].dontTakeDamage)
			{
				int damage = 15;
				if (Main.masterMode)
				{
					damage = 45;
				} else if (Main.expertMode)
				{
					damage = 30;
				}
				//Not sure about knockback or direction here.
				Main.player[Player.whoAmI].ApplyDamageToNPC(npc, damage, 0f, -1, false);
				//Could rewrite as Player.ApplyDamageToNPC maybe?
			}
		}//end OnHitByNPC

		public override void ModifyMaxStats(out StatModifier health, out StatModifier mana)
		{
			base.ModifyMaxStats(out health, out mana);
			if (activeSets == null)
			{
				return;
			}
			if (activeSets[(int)ArmorSet.Wizard])
			{
				mana.Base += 60;
			}
		}//end ModifyMaxStats

		public override void SaveData(TagCompound tag)
		{
			tag["PermanentSetBonuses.setXP"] = setXP;
			tag["PermanentSetBonuses.activeSets"] = activeSets;
		}//end SaveData

		public override void LoadData(TagCompound tag)
		{
			//For some reason, running SetStaticDefaults here does not initialize the objects we need!
			//SetStaticDefaults();
			setXP = new int[System.Enum.GetNames(typeof(ArmorSet)).Length];
			activeSets = new bool[setXP.Length];
			if (armorData == null)
			{
				armorData = InitialArmorData();
			}
			if (tag.ContainsKey("PermanentSetBonuses.activeSets"))
			{
				//Loop prevents out-of-bounds errors when loading outdated save data
				bool[] loadedSets = tag.Get<bool[]>("PermanentSetBonuses.activeSets");
				for (int i = 0; i < loadedSets.Length; i++)
				{
					activeSets[i] = loadedSets[i];
				}
			}
			int[] loadedXP = tag.GetIntArray("PermanentSetBonuses.setXP");

			for (int i = 0; i < loadedXP.Length; i++)
			{
				if (activeSets[i])
				{
					//If the set was previously mastered, master it again regardless of changes to exp requirements
					setXP[i] = armorData[(ArmorSet)i].maxXP;
				} else
				{
					setXP[i] = loadedXP[i];
				}
			}
		}//end LoadData
	}//end class PSBPlayer
}//end namespace PermanentSetBonuses.Content