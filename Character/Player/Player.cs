using KryptonEngine;
using KryptonEngine.Controls;
using KryptonEngine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HanselAndGretel.Data
{
	public class Player : Character
	{
		#region Properties

		public Inventory Inventory;
		public List<Activity> Abilities;
		protected InputHelper mInput;
		protected float mSpeed;

		#endregion

		#region Getter & Setter

		#endregion

		#region Constructor

		public Player(Vector2 pPosition)
			:base(pPosition)
		{
			
		}

		#endregion

		#region Override Methods

		public override void Initialize()
		{
			base.Initialize();
			mDebugColor = Color.LimeGreen;
		}

		#endregion

		#region Methods

		public virtual void Update(List<Rectangle> pMoveArea)
		{
			base.Update();
			Move(mInput.Movement * mSpeed, pMoveArea);
		}

		public void CheckForAbility(Activity pAcitvity)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Forced den Player in den Viewport der Camera.
		/// </summary>
		public void ForceInCameraViewport(Camera pCamera, List<Rectangle> pMoveArea)
		{
			Move(ForceInCameraViewportDelta(pCamera), pMoveArea);
		}

		/// <summary>
		/// Gibt den Vector2 zurück den der Player bewegt werden muss um in die Camera geforced zu sein.
		/// </summary>
		public Vector2 ForceInCameraViewportDelta(Camera pCamera)
		{
			Vector2 TmpNewPosition = Vector2.Zero;
			Rectangle TmpCameraViewport = new Rectangle((int)(pCamera.Position.X - EngineSettings.VirtualResWidth / 2 / pCamera.Scale), (int)(pCamera.Position.Y - EngineSettings.VirtualResHeight / 2 / pCamera.Scale), (int)(EngineSettings.VirtualResWidth / pCamera.Scale), (int)(EngineSettings.VirtualResHeight / pCamera.Scale));
			if (CollisionBox.Left < TmpCameraViewport.Left) TmpNewPosition.X = TmpCameraViewport.Left;
			if (CollisionBox.Top < TmpCameraViewport.Top) TmpNewPosition.Y = TmpCameraViewport.Top;
			if (CollisionBox.Right > TmpCameraViewport.Right) TmpNewPosition.X = TmpCameraViewport.Right - CollisionBox.Width;
			if (CollisionBox.Bottom > TmpCameraViewport.Bottom) TmpNewPosition.Y = TmpCameraViewport.Bottom - CollisionBox.Height;
			return TmpNewPosition - Position;
		}

		#endregion
	}
}
