using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KryptonEngine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using KryptonEngine.Manager;
using System.Xml.Serialization;

namespace HanselAndGretel.Data
{
	public class SceneData
	{
		#region Properties

		// Damit die Camera weiß in welchem Bereich sie sich bewegen darf. 
		public Rectangle GamePlane;
		public List<Rectangle> MoveArea;
		public List<Waypoint> Waypoints;

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

		// XmlIgnoreAttribute, da in DrawPackage Objekte sind die nicht serializiert werden können. Ich vermute das es das Skeleton ist.
		// Müssen aber nicht Serializiert werden, da man das kopieren auch in einer Funktion machen kann.
		[XmlIgnoreAttribute]
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

		// Wird für die Serializierung benötigt
		public SceneData()
		{

		}
		#endregion

		#region OverrideMethods

		#endregion

		#region Methods

		public void Initialize()
		{
			MoveArea = new List<Rectangle>();
			Waypoints = new List<Waypoint>();
		}

		/// <summary>
		/// Leert alle Listen.
		/// </summary>
		public void ResetLevel()
		{
			MoveArea.Clear();
			Waypoints.Clear();
		}

		public void LoadLevel(int pLevelId)
		{
			throw new System.NotImplementedException();
		}

		#endregion
	}
}
