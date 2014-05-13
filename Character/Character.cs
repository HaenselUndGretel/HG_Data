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

		//References
		protected Camera rCamera;
		protected SceneData rScene;

		#endregion

		#region Getter & Setter

		public DrawPackage DrawPackage { get { return new DrawPackage(Position, 0, CollisionBox, mDebugColor); } }

		#endregion

		#region Constructor

		public Character()
		{

		}

		public Character(Vector2 pPosition)
			:base(pPosition)
		{
		}

		#endregion

		#region Override Methods

		public override void Initialize()
		{
			base.Initialize();
			mDebugColor = Color.LightYellow;
		}

		public override void LoadContent()
		{
			throw new System.NotImplementedException();
		}

		public override void Update()
		{
			
		}

		#endregion

		#region Methods

		public void LoadReferences(Camera pCamera, SceneData pScene)
		{
			rCamera = pCamera;
			rScene = pScene;
		}

		public void Move(Vector2 pDelta, List<Rectangle> pMoveArea)
		{
			Position += Collision.CollisionCheckedVector(CollisionBox, (int)pDelta.X, (int)pDelta.Y, pMoveArea);
		}

		#endregion
	}
}
