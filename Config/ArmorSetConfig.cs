using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace PermanentSetBonuses.Config
{
	public class ArmorSetConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Header("WoodArmor")]
		[Label("Enable Wood Armor")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool EnableWood;

		[Label("Wood EXP Required")]
		[Tooltip("Amount of experience required to master the Wood Armor set.\nDefault 500.")]
		[DefaultValue(500)]
		[ReloadRequired]
		public int WoodEXP;
	}//end class ArmorSetConfig
}//end namespace PermanentSetBonuses.Config