using KryptonEngine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HanselAndGretel.Data
{
	[Serializable]
	public abstract class Collectable : Sprite
	{
		#region Properties

		protected int mCollectableId;

		#endregion

		#region Getter & Setter

		// Zur auslese welche Daten das Collectable hat z.b. welche DiarySeite oder welches Spielzeug
		public int CollectableId { get { return mCollectableId; } set { mCollectableId = value; } }
		#endregion

		#region Constructor

		public Collectable()
			:base()
		{

		}

		public Collectable(Vector2 pPosition, string pTextureName)
			:base(pPosition, pTextureName)
		{

		}

		#endregion

		#region OverrideMethods

		public override string GetInfo()
		{
			String temp;

			temp = base.GetInfo();
			temp += "\nCollectable ID: " + mCollectableId;

			return temp;
		}
		#endregion

		#region Methods

		#endregion
	}
}
