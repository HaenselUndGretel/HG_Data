﻿using System;
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

		public SpineObject mModel;

		//References
		protected Camera rCamera;
		protected SceneData rScene;

		#endregion

		#region Getter & Setter

		#region Redirect Position to Skeleton

		new public Vector2 Position
		{
			set
			{
				mPosition = value;
				mCollisionBox.X = (int)value.X;
				mCollisionBox.Y = (int)value.Y;
				mModel.Position = value;
			}
			get { return mPosition; }
		}
		new public int PositionX
		{
			set
			{
				mPosition.X = value;
				mCollisionBox.X = value;
				mModel.PositionX = value;
			}
			get { return (int)mPosition.X; }
		}
		new public int PositionY
		{
			set
			{
				mPosition.Y = value;
				mCollisionBox.Y = value;
				mModel.PositionY = value;
			}
			get { return (int)mPosition.Y; }
		}

		#endregion

		public DrawPackage DrawPackage { get { return new DrawPackage(Position, 0, CollisionBox, mDebugColor, mModel.Skeleton); } }

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
			mModel.Load();
		}

		public override void Update()
		{
			mModel.Update();
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

#region Animation

		public void AnimCutToIdle()
		{
			mModel.AnimationState.ClearTracks();
			mModel.AnimationState.SetAnimation(0, "idle", true);
		}

		public void AnimMoveAnimation(Vector2 pMovement)
		{
			if (pMovement.X >= 0)
				mModel.Flip = false;
			else
				mModel.Flip = true;

		}
#endregion
		#endregion
	}
}
