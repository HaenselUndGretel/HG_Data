using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KryptonEngine.Entities;
using Microsoft.Xna.Framework;
using KryptonEngine;
using KryptonEngine.Manager;
using KryptonEngine.Physics;

namespace HanselAndGretel.Data
{
	public class Character : GameObject
	{
		#region Properties

		public SpineObject Model;

		#endregion

		#region Getter & Setter

		#endregion

		#region Constructor

		public Character(Vector2 pPosition)
			:base(pPosition)
		{
			Initialize();
		}

		#endregion

		#region Override Methods

		public override void Initialize()
		{
			mDebugColor = Color.Pink;
		}

		public override void LoadContent()
		{
			throw new System.NotImplementedException();
		}

		public override void Update()
		{
			
		}

		public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(TextureManager.Instance.GetElementByString("pixel"), CollisionBox, mDebugColor);
		}

		#endregion

		#region Methods

		public void Move(Vector2 pDelta, List<Rectangle> pMoveArea)
		{
			Position += Collision.CollisionCheckedVector(CollisionBox, (int)pDelta.X, (int)pDelta.Y, pMoveArea);
		}

		#endregion
	}
}
