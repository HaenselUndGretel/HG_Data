﻿using KryptonEngine.Controls;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HanselAndGretel.Data
{
	public class Hansel : Player
	{
		#region Properties

		#endregion

		#region Getter & Setter

		#endregion

		#region Constructor

		public Hansel(Vector2 pPosition)
			:base(pPosition)
		{
			Initialize();
		}

		#endregion

		#region OverrideMethods

		public override void Initialize()
		{
			base.Initialize();
			mInput = InputHelper.Player1;
			mCollisionBox.Width = 50;
			mCollisionBox.Height = 100;
			mSpeed = 8;
		}

		#endregion

		#region Methods

		

		#endregion
	}
}
