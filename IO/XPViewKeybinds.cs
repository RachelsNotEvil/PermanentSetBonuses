using Terraria.ModLoader;

namespace PermanentSetBonuses.IO
{
	public class XPViewKeybinds : ModSystem
	{
		public static ModKeybind CheckCurrentSet { get; private set; }

		public override void Load()
		{
			CheckCurrentSet = KeybindLoader.RegisterKeybind(Mod, "CheckSetXP", "C");
		}

		public override void Unload()
		{
			CheckCurrentSet = null;
		}
	}
}