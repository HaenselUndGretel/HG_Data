using KryptonEngine.Controls;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HanselAndGretel.Data
{
	public class Gretel : Player
	{
		#region Properties

		public int Chalk;

		#endregion

		#region Getter & Setter

		#endregion

		#region Constructor

		public Gretel(Vector2 pPosition)
			:base(pPosition)
		{
			Initialize();
		}

		#endregion

		#region OverrideMethods

		public override void Initialize()
		{
			mInput = InputHelper.Player2;
			mCollisionBox.Width = 40;
			mCollisionBox.Height = 90;
			mSpeed = 10;
		}

		public override void LoadContent()
		{
			base.LoadContent();
		}

		public override void Update(List<Rectangle> pMoveArea)
		{
			base.Update(pMoveArea);
		}

		public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

		#endregion

		#region Methods

		#endregion
	}
}
