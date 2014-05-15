using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HG_Data.Data
{
	public class EventTrigger
	{
		public enum Event
		{
			SpawnWitch,
			TreeFalling,
			PlaySound,
			ActivateTrigger,
		}

		#region Properties

		protected List<Rectangle> mTrigger;
		protected int mIdToTrigger;
		protected Event mEvent;
		protected bool mActivated;

		#endregion

		#region Getter & Setter

		public List<Rectangle> Trigger { get { return mTrigger; } set { mTrigger = value; } }
		public Event Event { get { return mEvent; } set { mEvent = value; } }
		public int Target { get { return mIdToTrigger; } set { mIdToTrigger = value; } }
		public bool IsAcitvated { get { return mActivated; } set { mActivated = value; } }

		#endregion
	}
}
