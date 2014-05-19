using KryptonEngine.Entities;
using KryptonEngine.Interface;
using KryptonEngine.Manager;
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
		protected bool mTwoPlayerEnter;
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
			mOneWay = false;
			mTwoPlayerEnter = true;
			mDropDown = new DropDownMenu(Vector2.Zero, new List<String>() { "Do Stuff", "More Stuff" }, null);
		}

		// Wird nur im Editor gezeichnet
		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(TextureManager.Instance.GetElementByString("IconMoveArea"), CollisionBox, Color.White);
		}

		/// <summary>
		/// Wird für die Infobox im Editor benötigt.
		/// </summary>
		/// <returns></returns>
		public override string GetInfo()
		{
			String tmpInfo;

			tmpInfo = "Objekt ID: " + mId;
			tmpInfo += "\nPosition: " + Position;
			tmpInfo += "\nRectangle Dim.: " + mCollisionBox.Width + "; " + mCollisionBox.Height;
			tmpInfo += "\nZiel Scene: " + mDestinationSceneId;
			tmpInfo += "\nZiel Waypoint: " + mDesinationWaypointId;
			tmpInfo += "\n2 Spieler: " + mTwoPlayerEnter;
			tmpInfo += "\nOneway:" + mOneWay;

			return tmpInfo;
		}

		#endregion

		#region Methods

		#endregion
	}
}
