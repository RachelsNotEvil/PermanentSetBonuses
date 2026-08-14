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
	}//end class ArmorSetConfig
}//end namespace PermanentSetBonuses.Config