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

		private bool mTwoPlayerEnter;
		#endregion

		#region Getter & Setter

		public bool TwoPlayerEnter { get { return mTwoPlayerEnter; } set { mTwoPlayerEnter = value; } }

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
