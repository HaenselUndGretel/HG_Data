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

		public Gretel()
		{
			Initialize();
		}

		#endregion

		#region OverrideMethods

		public override void Initialize()
		{
			base.Initialize();
			mInput = InputHelper.Player2;
			mCollisionBox.Width = 40;
			mCollisionBox.Height = 90;
			mSpeed = 4;
		}

		#endregion

		#region Methods

		#endregion
	}
}
