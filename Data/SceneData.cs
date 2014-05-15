﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KryptonEngine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using KryptonEngine.Manager;
using System.Xml.Serialization;
using System.IO;
using KryptonEngine;

namespace HanselAndGretel.Data
{
	public class SceneData
	{
		#region Properties

		public Rectangle GamePlane; // Damit die Camera weiß in welchem Bereich sie sich bewegen darf. 
		public List<Rectangle> MoveArea;
		public List<Waypoint> Waypoints;

		// "ParallaxPlanes" 5 Planes die mit der Camera verschoben werde. InteractiveObjects aus [1] filtern.
		// Nachträglich die InteractiveObjects für die letzte Ebene zeichnen, damit man auch hinter diesen laufen kann.
		public List<List<GameObject>> ParallaxPlanes;

		// Interactive Objects müssen aus der ParallaxPlane 1 rausgefiltert werden.
		public List<InteractiveObject> InteractiveObjects;
		//public List<InteractiveSpineObject> InteractiveSpineObjects;

		public List<Collectable> Collectables;
		public List<Item> Items;

		public List<Enemy> Enemies;

		//public List<Light> Lights;
		//public List<Emitter> Emitter;
		//public List<SoundAreas> SoundAreas;

		#endregion

		#region Getter & Setter

		// XmlIgnoreAttribute, da in DrawPackage Objekte sind die nicht serializiert werden können. Ich vermute das es das Skeleton ist.
		// Müssen aber nicht Serializiert werden, da man das kopieren auch in einer Funktion machen kann.
		//[XmlIgnoreAttribute]
		//public List<DrawPackage> DrawPackagesPlanes
		//{
		//	get
		//	{
		//		List<DrawPackage> TmpList = new List<DrawPackage>();
		//		foreach (List<ParallaxPlane> plane in ParallaxPlanes)
		//		{
		//			foreach (Sprite tile in plane.mTiles)
		//			{
		//				TmpList.Add(tile.DrawPackage);
		//			}
		//		}
		//		return TmpList;
		//	}
		//}
		[XmlIgnoreAttribute]
		public List<DrawPackage> DrawPackagesGame
		{
			get
			{
				List<DrawPackage> TmpList = new List<DrawPackage>();
				foreach (Rectangle rect in MoveArea)
				{
					TmpList.Add(new DrawPackage(new Vector2(rect.X, rect.Y), 0, rect, Color.Blue));
				}
				foreach (Waypoint wp in Waypoints)
				{
					TmpList.Add(wp.DrawPackage);
				}
				//Add EVERYTHING for Debug
				//foreach (InteractiveObject obj in InteractiveObjects)
				//{
				//	TmpList.Add(obj.DrawPackage);
				//}
				return TmpList;
			}
		}

		#endregion

		#region Constructor

		// Wird für die Serializierung benötigt
		public SceneData()
		{
			Initialize();
		}
		#endregion

		#region OverrideMethods

		#endregion

		#region Methods

		public void Initialize()
		{
			GamePlane = Rectangle.Empty;
			MoveArea = new List<Rectangle>();
			Waypoints = new List<Waypoint>();

			ParallaxPlanes = new List<List<GameObject>>();

			for (int i = 0; i < 5; i++)
				ParallaxPlanes.Add(new List<GameObject>());

			InteractiveObjects = new List<InteractiveObject>();
		}

		/// <summary>
		/// Leert alle Listen.
		/// </summary>
		public void ResetLevel()
		{
			MoveArea.Clear();
			Waypoints.Clear();

			ParallaxPlanes.Clear();

			InteractiveObjects.Clear();
		}

		/// <summary>
		/// Zum der InteractiveObjects damit diese später geupdatet werden können.
		/// Gezeichnet werden muss nicht da sie noch in der ParallaxPlane erhalten bleiben.
		/// </summary>
		public void SortInteravtiveObjectsFromPlane()
		{
			foreach (GameObject go in ParallaxPlanes[1])
			{
				if(go.GetType() == typeof(InteractiveObject))
				InteractiveObjects.Add((InteractiveObject)go);
			}
		}
		#endregion
	}
}
