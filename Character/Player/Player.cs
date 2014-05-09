using KryptonEngine.Controls;
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

		#endregion
	}
}
