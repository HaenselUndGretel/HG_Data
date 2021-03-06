﻿using KryptonEngine.Controls;
using KryptonEngine.Entities;
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

		public Hansel()
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
			mModel = new SpineObject("ashbrett");
			mAbilities.Remove(Activity.Crawl);
			mAbilities.Remove(Activity.SlipThroughRock);
			mAbilities.Remove(Activity.UseChalk);
		}

		#endregion

		#region Methods

		

		#endregion
	}
}
