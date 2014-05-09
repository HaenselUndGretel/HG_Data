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

		#endregion

		#region Getter & Setter

		#endregion

		#region Constructor

		#endregion

		#region Override Methods

		public override void Initialize()
		{
			base.Initialize();
			throw new System.NotImplementedException();
		}

		public override void Update()
		{
			base.Update();
		}

		#endregion

		#region Methods

		public void CheckForAbility(Activity pAcitvity)
		{
			throw new System.NotImplementedException();
		}

		#endregion
	}
}
