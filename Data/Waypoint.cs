using KryptonEngine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HanselAndGretel.Data
{
	public class Waypoint : GameObject
	{
		#region Properties

		protected int mDestinationSceneId;
		protected int mDesinationWaypointId;
		private bool mTwoPlayerEnter;
		protected bool mOneWay;

		#endregion

		#region Getter & Setter

		public int DestinationScene { get { return mDestinationSceneId; } set { mDestinationSceneId = value; } }
		public int DestinationWaypoint { get { return mDesinationWaypointId; } set { mDesinationWaypointId = value; } }

		public bool TwoPlayerEnter { get { return mTwoPlayerEnter; } set { mTwoPlayerEnter = value; } }
		/// <summary>
		/// Wenn True: Dieser Waypoint kann nur Betreten aber nicht Verlassen werden.
		/// </summary>
		public bool OneWay { get { return mOneWay; } set { mOneWay = value; } }

		public DrawPackage DrawPackage { get { return new DrawPackage(Position, 0, CollisionBox, mDebugColor); } }

		// Zum zeichnen im Editor
		public Texture2D Texture;

		#endregion

		#region Constructor

		public Waypoint()
		{
			Initialize();
		}

		#endregion

		#region Override Methods

		public override void Initialize()
		{
			mDebugColor = Color.DarkGreen;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Texture, CollisionBox, Color.White);
		}

		#endregion

		#region Methods

		#endregion
	}
}
