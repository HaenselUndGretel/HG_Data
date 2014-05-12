using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HanselAndGretel.Data
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
		protected static string ScenePath = Environment.CurrentDirectory + @"\Content\scenes";
		[XmlIgnoreAttribute]
		protected string SavegamePath = Environment.CurrentDirectory + @"\save.hugs"; //Hänsle Und Gretel Savegame
		[XmlIgnoreAttribute]
		protected static XmlSerializer SceneSerializer = new XmlSerializer(typeof(SceneData));
		[XmlIgnoreAttribute]
		protected static XmlSerializer SavegameSerializer = new XmlSerializer(typeof(Savegame));
		[XmlIgnoreAttribute]
		protected static StreamReader xmlReader;
		[XmlIgnoreAttribute]
		protected static StreamWriter xmlWriter;

		#endregion

		#region Constructor

		public Savegame()
		{
			Initialize();
		}

		public Savegame(Savegame pSavegame)
		{
			Artefacts = pSavegame.Artefacts;
			Toys = pSavegame.Toys;
			Diary = pSavegame.Diary;
			InventoryHansel = pSavegame.InventoryHansel;
			InventoryGretel = pSavegame.InventoryGretel;
			Chalk = pSavegame.Chalk;
			WaypointHansel = pSavegame.WaypointHansel;
			WaypointGretel = pSavegame.WaypointGretel;
			Scenes = pSavegame.Scenes;
		}

		#endregion

		#region Methods

		public void Initialize()
		{
			Artefacts = new List<Artefact>();
			Toys = new List<Toy>();
			Diary = new List<DiaryEntry>();
			InventoryHansel = new Inventory();
			InventoryGretel = new Inventory();
			Chalk = 0;
			WaypointHansel = new Waypoint(); //ToDo: Init Waypoint setzen !---!---!---!---!
			WaypointGretel = new Waypoint(); //ToDo: Init Waypoint setzen !---!---!---!---!
			Scenes = new SceneData[1]; //ToDo: Anzahl Scenes setzen !---!---!---!---!
		}

		public static void Load(Savegame pSavegame) //Muss static sein damit das Savegame als solches gesetzt werden kann.
		{
			FileInfo file = new FileInfo(pSavegame.SavegamePath);
			if (!file.Exists)
				pSavegame.Reset();
			xmlReader = new StreamReader(pSavegame.SavegamePath);
			pSavegame = new Savegame((Savegame)SavegameSerializer.Deserialize(xmlReader)); //Savegame aus File laden
			xmlReader.Close();
		}

		/// <summary>
		/// Für den Editor und für Reset(): Lädt die Scenes in ScenePath in Scenes[].
		/// </summary>
		/// <param name="pLevelId">000 - 999</param>
		public void LoadLevel(int pLevelId)
		{
			Scenes[pLevelId].ResetLevel();
			FileInfo file = new FileInfo(ScenePath + "\\" + LevelNameFromId(pLevelId) + ".hug");
			if (file == null)
				throw new FileNotFoundException("Die Scene {0} existiert nicht! WIESO?!?", LevelNameFromId(pLevelId));
			xmlReader = new StreamReader(file.FullName);
			Scenes[pLevelId] = (SceneData)SceneSerializer.Deserialize(xmlReader); //sData File in SpineData Object umwandeln
			xmlReader.Close();
		}

		/// <summary>
		/// Speichert pSavegame an pSavegame.SavegamePath.
		/// </summary>
		/// <param name="pSavegame">Savegame, das gesaved werden soll.</param>
		public static void Save(Savegame pSavegame) //Muss static sein damit das Savegame als solches serialisiert werden kann.
		{
			xmlWriter = new StreamWriter(pSavegame.SavegamePath);
			SavegameSerializer.Serialize(xmlWriter, pSavegame); //Savegame in File schreiben
			xmlWriter.Close();
		}

		/// <summary>
		/// Für den Editor: Speichert eine Scene als pLevelId.hug
		/// </summary>
		/// <param name="pLevelId">000 - 999</param>
		public void SaveLevel(int pLevelId)
		{
			xmlWriter = new StreamWriter(ScenePath + "\\" + LevelNameFromId(pLevelId) + ".hug");
			SceneSerializer.Serialize(xmlWriter, Scenes[pLevelId]);
			xmlWriter.Close();
		}

		public void Reset()
		{
			Initialize(); //Flush Savegame mit default Werten
			for (int i = 0; i < Scenes.Length; i++)
				LoadLevel(i); //Scenes neu laden
		}

		protected string LevelNameFromId(int pLevelId)
		{
			string LevelName = "";
			for (int i = 0; i < 3 - pLevelId.ToString().Length; i++)
				LevelName += "0";
			LevelName += pLevelId.ToString();
			return LevelName;
		}

		#endregion
	}
}
