using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KryptonEngine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using KryptonEngine.Manager;

namespace HanselAndGretel.Data
{
	public class SceneData
	{
		#region Properties

		public List<Rectangle> MoveArea;
		//public List<Waypoint> Waypoints;

		//public List<InteractiveObject> InteractiveObjects;
		//public List<InteractiveSpineObject> InteractiveSpineObjects;

		//public List<Collectable> Collectables;
		//public List<Item> Items;

		//public List<Enemy> Enemies;

		//public List<Light> Lights;
		//public List<Emitter> Emitter;
		//public List<SoundAreas> SoundAreas;

		#endregion

		#region Getter & Setter

		public List<DrawPackage> DrawPackages
		{
			get
			{
				List<DrawPackage> TmpList = new List<DrawPackage>();
				foreach (Rectangle rect in MoveArea)
				{
					TmpList.Add(new DrawPackage(new Vector2(rect.X, rect.Y), 0, rect, Color.Blue));
				}
				return TmpList;
			}
		}

		#endregion

		#region Constructor

		#endregion

		#region OverrideMethods

		#endregion

		#region Methods

		public void LoadLevel(int pLevelId)
		{
			throw new System.NotImplementedException();
		}

		#endregion
	}
}
