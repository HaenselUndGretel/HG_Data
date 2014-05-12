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

		}

		#endregion

		#region Override Methods

		#endregion

		#region Methods

		

		public void Load()
		{
			FileInfo file = new FileInfo(SavegamePath);
			if (!file.Exists)
				Reset();
			Savegame TmpSavegame;
			xmlReader = new StreamReader(SavegamePath);
			TmpSavegame = (Savegame)SavegameSerializer.Deserialize(xmlReader); //Savegame aus File laden
			xmlReader.Close();
			Artefacts = TmpSavegame.Artefacts;
			Toys = TmpSavegame.Toys;
			Diary = TmpSavegame.Diary;
			InventoryHansel = TmpSavegame.InventoryHansel;
			InventoryGretel = TmpSavegame.InventoryGretel;
			Chalk = TmpSavegame.Chalk;
			WaypointHansel = TmpSavegame.WaypointHansel;
			WaypointGretel = TmpSavegame.WaypointGretel;
			Scenes = TmpSavegame.Scenes;
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
			//SaveGame von SceneData Files neu mit default Werten erstellen.
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
