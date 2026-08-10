using Terraria;
using Terraria.ModLoader;

namespace PermanentSetBonuses.Content
{
	public class ModAllNPC : GlobalNPC
	{
		public override void OnKill(NPC npc)
		{
			bool[] killContributors = npc.playerInteraction;
			if (killContributors == null)
			{
				return;
			}
			for (int i = 0; i < 255; i++)
			{
				//Check if the player at i interacted
				if (killContributors[i])
				{
					//get that player
					Player contributor = Main.player[i];
					//Next, tell that player to get exp
					if (contributor != null && contributor.active)
					{
						contributor.GetModPlayer<PSBPlayer>().ClaimKill(contributor, npc);
					}
				}//end if (killContributors[i])
			}//end for (i = 0; i < 255; i++)
		}//end OnKill
	}//End class ModAllNPC
}//End namespace PermanentSetBonuses.Content