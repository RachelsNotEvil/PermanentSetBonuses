using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace PermanentSetBonuses.Config
{
	public class ArmorSetConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Header("WoodArmor")]
		[Label("Enable Wood Armor")]
		[Tooltip("Allow players to gain experience for and master basic wood armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableWood;

		[Label("Wood EXP Required")]
		[Tooltip("Amount of experience required to master the Wood Armor set.\nDefault 500.")]
		[Range(0, 65535)]
		[DefaultValue(500)]
		[ReloadRequired]
		public int WoodEXP;

		[Label("Enable Boreal Wood Armor")]
		[Tooltip("Allow players to gain experience for and master boreal wood armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableBorealWood;

		[Label("Boreal Wood EXP Required")]
		[Tooltip("Amount of experince required to master the Boreal Wood Armor set.\nDefault 550.")]
		[Range(0, 65535)]
		[DefaultValue(550)]
		[ReloadRequired]
		public int BorealEXP;

		[Label("Enable Palm Wood Armor")]
		[Tooltip("Allow players to gain experience for and master palm wood armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnablePalmWood;

		[Label("Palm Wood EXP Required")]
		[Tooltip("Amount of experience required to master the Palm Wood Armor set.\nDefault 550.")]
		[Range(0, 65535)]
		[DefaultValue(550)]
		[ReloadRequired]
		public int PalmEXP;

		[Label("Enable Rich Mahogany")]
		[Tooltip("Allow players to gain experience for and master rich mahogany armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableMahogany;

		[Label("Rich Mahogany EXP Required")]
		[Tooltip("Amount of experience required to master the Rich Mahogany Armor set.\nDefault 575.")]
		[Range(0, 65535)]
		[DefaultValue(575)]
		[ReloadRequired]
		public int MahoganyEXP;

		[Label("Enable Ebonwood")]
		[Tooltip("Allow players to gain experience for and master ebonwood armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableEbonwood;

		[Label("Ebonwood EXP Required")]
		[Tooltip("Amount of experience required to master the Ebonwood Armor set.\nDefault 700.")]
		[Range(0, 65535)]
		[DefaultValue(700)]
		[ReloadRequired]
		public int EbonEXP;

		[Label("Enable Shadewood")]
		[Tooltip("Allow players to gain experience for and master shadewood armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableShadewood;

		[Label("Shadewood EXP Required")]
		[Tooltip("Amount of experience required to master the Shadewood Armor set.\nDefault 700.")]
		[Range(0, 65535)]
		[DefaultValue(700)]
		[ReloadRequired]
		public int ShadeEXP;

		[Header("BasicOres")]
		[Label("Enable Copper")]
		[Tooltip("Allow players to gain experience for and master copper armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableCopper;

		[Label("Copper EXP Required")]
		[Tooltip("Amount of experience required to master the Copper Armor set.\nDefault 750")]
		[Range(0, 65535)]
		[DefaultValue(750)]
		[ReloadRequired]
		public int CopperEXP;

		[Label("Enable Tin")]
		[Tooltip("Allow players to gain experience for and master tin armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableTin;

		[Label("Tin EXP Required")]
		[Tooltip("Amount of experience required to master the Tin Armor set.\nDefault 800.")]
		[Range(0, 65535)]
		[DefaultValue(800)]
		[ReloadRequired]
		public int TinEXP;

		[Label("Enable Iron")]
		[Tooltip("Allow players to gain experience for and master iron armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableIron;

		[Label("Iron EXP Required")]
		[Tooltip("Amount of experience required to master the Iron Armor set.\nDefault 1000.")]
		[Range(0, 65535)]
		[DefaultValue(1000)]
		[ReloadRequired]
		public int IronEXP;

		[Label("Enable Lead")]
		[Tooltip("Allow players to gain experience for and master lead armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableLead;

		[Label("Lead EXP Required")]
		[Tooltip("Amount of experience required to master the Lead Armor set.\nDefault 1250.")]
		[Range(0, 65535)]
		[DefaultValue(1250)]
		[ReloadRequired]
		public int LeadEXP;

		[Label("Enable Silver")]
		[Tooltip("Allow players to gain experience for and master silver armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableSilver;

		[Label("Silver EXP Required")]
		[Tooltip("Amount of experience required to master the Silver Armor set.\nDefault 1400.")]
		[Range(0, 65535)]
		[DefaultValue(1400)]
		[ReloadRequired]
		public int SilverEXP;

		[Label("Enable Tungsten")]
		[Tooltip("Allow players to gain experience for and master tungsten armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableTungsten;

		[Label("Tungsten EXP Required")]
		[Tooltip("Amount of experience required to master the Tungsten Armor set.\nDefault 1500.")]
		[Range(0, 65535)]
		[DefaultValue(1500)]
		[ReloadRequired]
		public int TungstenEXP;

		[Label("Enable Gold")]
		[Tooltip("Allow players to gain experience for and master gold armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableGold;

		[Label("Gold EXP Required")]
		[Tooltip("Amount of experience required to master the Gold Armor set.\nDefault 1800.")]
		[Range(0, 65535)]
		[DefaultValue(1800)]
		[ReloadRequired]
		public int GoldEXP;

		[Label("Enable Platinum")]
		[Tooltip("Allow players to gain experience for and master platinum armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnablePlatinum;

		[Label("Platinum EXP Required")]
		[Tooltip("Amount of experience required to master the Platinum Armor set.\nDefault 2400.")]
		[Range(0, 65535)]
		[DefaultValue(2400)]
		[ReloadRequired]
		public int PlatinumEXP;

		[Label("Enable Meteor")]
		[Tooltip("Allow players to gain experience for and master meteor armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableMeteor;

		[Label("Meteor EXP Required")]
		[Tooltip("Amount of experience required to master the Meteor armor set.\nDefault 3000.")]
		[Range(0, 65535)]
		[DefaultValue(3000)]
		[ReloadRequired]
		public int MeteorEXP;

		[Label("Enable Shadow")]
		[Tooltip("Allow players to gain experience for and master shadow armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableShadow;

		[Label("Shadow EXP Required")]
		[Tooltip("Amount of experience required to master the Shadow armor set.\nDefault 4000.")]
		[Range(0,65535)]
		[DefaultValue(4000)]
		[ReloadRequired]
		public int ShadowEXP;

		[Label("Enable Crimson")]
		[Tooltip("Allow players to gain experience for and master Crimson armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableCrimson;

		[Label("Crimson EXP Required")]
		[Tooltip("Amount of experience required to master the Crimson armor set.\nDefault 4000.")]
		[Range(0, 65535)]
		[DefaultValue(4000)]
		[ReloadRequired]
		public int CrimsonEXP;

		[Header("OtherPreHardmode")]
		[Label("Enable Cactus")]
		[Tooltip("Allow players to gain experience for and master cactus armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableCactus;

		[Label("Cactus EXP Required")]
		[Tooltip("Amount of experience required to master the Cactus armor set.\nDefault 900.")]
		[Range(0, 65535)]
		[DefaultValue(900)]
		[ReloadRequired]
		public int CactusEXP;

		[Label("Enable Pumpkin")]
		[Tooltip("Allow players to gain experience for and master pumpkin armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnablePumpkin;

		[Label("Pumpkin EXP Required")]
		[Tooltip("Amount of experience required to master the Pumpkin armor set.\nDefault 2000.")]
		[Range(0, 65535)]
		[DefaultValue(2000)]
		[ReloadRequired]
		public int PumpkinEXP;

		[Label("Enable Ninja")]
		[Tooltip("Allow players to gain experience for and master ninja armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableNinja;

		[Label("Ninja EXP Required")]
		[Tooltip("Amount of experience required to master the Ninja armor set.\nDefault 1600.")]
		[Range(0, 65535)]
		[DefaultValue(1600)]
		[ReloadRequired]
		public int NinjaEXP;

		[Label("Enable Wizard")]
		[Tooltip("Allow players to gain experience for and master wizard armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableWizard;

		[Label("Wizard EXP Required")]
		[Tooltip("Amount of experience required to master the Wizard armor set.\nDefault 850.")]
		[Range(0, 65535)]
		[DefaultValue(850)]
		[ReloadRequired]
		public int WizardEXP;

		[Label("Enable Fossil")]
		[Tooltip("Allow players to gain experience for and master fossil armor.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableFossil;

		[Label("Fossil EXP Required")]
		[Tooltip("Amount of experience required to master the Fossil armor set.\nDefault 950.")]
		[Range(0, 65535)]
		[DefaultValue(950)]
		[ReloadRequired]
		public int FossilEXP;
	}//end class ArmorSetConfig
}//end namespace PermanentSetBonuses.Config