using HanselAndGretel.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HanselAndGretel
{
	public class Savegame
	{
		#region Properties

		public List<Artefact> Artefacts;
		public List<Toy> Toys;
		public List<DiaryEntry> Diary;

		public Inventory InventoryHansel;
		public Inventory InventoryGretel;
		public int Chalk;

		public Waypoint WaypointHansel;
		public Waypoint WaypointGretel;

		public SceneData[] Scenes;

		[XmlIgnoreAttribute]
		protected static const string DefaultScenePath = Environment.CurrentDirectory + @"\Content\scenes";
		[XmlIgnoreAttribute]
		protected static XmlSerializer xmlSerializer = new XmlSerializer(typeof(SceneData));
		[XmlIgnoreAttribute]
		protected static StreamReader xmlReader;
		[XmlIgnoreAttribute]
		protected static StreamWriter xmlWriter;

		#endregion

		#region Constructor

		#endregion

		#region Override Methods

		#endregion

		#region Methods

		

		public void Load()
		{
			//Savegame aus File laden
		}

		public void LoadLevel(int pLevelId)
		{
			Scenes[pLevelId].ResetLevel();
			DirectoryInfo sceneDirectory = new DirectoryInfo(DefaultScenePath); //Goto Scene Directory
			if (!sceneDirectory.Exists) //Checken ob das Directory existiert
				return;
			foreach (FileInfo f in sceneDirectory.GetFiles()) //Enthaltene Files durchgehen
			{
				if (f.Name == pLevelId.ToString() + ".hug") //Passendes Scene File heraus filtern
				{
					xmlReader = new StreamReader(f.FullName);
					Scenes[pLevelId] = (SceneData)xmlSerializer.Deserialize(xmlReader); //sData File in SpineData Object umwandeln
					xmlReader.Close();
					break;
				}
			}
			
		}

		public void Save()
		{
			//Savegame in File schreiben
		}

		public void SaveLevel(int pLevelId)
		{
			xmlWriter = new StreamWriter(DefaultScenePath + "\\" + pLevelId.ToString() + ".hug");
			xmlSerializer.Serialize(xmlWriter, Scenes[pLevelId]);
			xmlWriter.Close();
		}

		public void Reset()
		{
			//SaveGame von SceneData Files neu mit default Werten erstellen.
		}

		#endregion
	}
}
