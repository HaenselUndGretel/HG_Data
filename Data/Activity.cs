using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HanselAndGretel.Data
{
	public enum Activity
	{
		CaughtInCobweb,
		FreeFromCobweb,
		CaughtInSwamp,
		FreeFromSwamp,
		KnockOverTree,
		BalanceOverTree,
		PushRock,
		SlipThroughRock,
		Crawl,
		JumpOverGap,
		LegUp,
		LegUpGrab,
		UseKey,
		PullDoor,
		UseChalk,
		UseWell,
		UseItem,
		SwitchItem,
	}

	public class Acitivty
	{
		#region Methods

		public static List<Activity> GetAllActivities()
		{
			return new List<Activity>()
			{
				Activity.CaughtInCobweb,
				Activity.FreeFromCobweb,
				Activity.CaughtInSwamp,
				Activity.FreeFromSwamp,
				Activity.KnockOverTree,
				Activity.BalanceOverTree,
				Activity.PushRock,
				Activity.SlipThroughRock,
				Activity.Crawl,
				Activity.JumpOverGap,
				Activity.LegUp,
				Activity.LegUpGrab,
				Activity.UseKey,
				Activity.PullDoor,
				Activity.UseChalk,
				Activity.UseWell,
				Activity.UseItem,
				Activity.SwitchItem
			};
		}

		#endregion
	}
}
