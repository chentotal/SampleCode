using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Sample
{
	public class DatabaseManager
	{
		public bool _inited;

		public Dictionary<int, MonsterData> MonsterDataDB;
		public Dictionary<int, MonsterTypeData> MonsterTypeDataDB;
		public Dictionary<int, SpawnData> SpawnDataDB;
		public Dictionary<int, BonusGame> BonusGameDataDB;
	
		
		static DatabaseManager _instance = null;
		public static DatabaseManager Instance
		{
			get { return _instance ??= new DatabaseManager(); }
		}

		public void InitDatabase()
		{
			if (_inited)
			{
				return;
			}

			MonsterDataDB = LoadDatabaseToDictionary<MonsterData>("MonsterData");
			MonsterTypeDataDB = LoadDatabaseToDictionary<MonsterTypeData>("MonsterTypeData");
			SpawnDataDB = LoadDatabaseToDictionary<SpawnData>("SpawnEditorData");
			BonusGameDataDB = LoadDatabaseToDictionary<BonusGame>("BonusGameData");
			_inited = true;
		}

		public Dictionary<int, T> LoadDatabaseToDictionary<T>(string databaseName)
		{
			Dictionary<int, T> rtnValue = new Dictionary<int, T>();
			var jsonFile = Resources.Load<TextAsset>($"DBF/{databaseName}");
			if (jsonFile != null)
			{
				rtnValue = JsonConvert.DeserializeObject<Dictionary<int, T>>(jsonFile.ToString());
			}

			if (rtnValue == null)
			{
				Debug.LogError($"讀不到資料檔:{databaseName}");
			}

			return rtnValue;
		}

		public T LoadDatabaseToStruct<T>(string databaseName) where T : new()
		{
			T rtnValue = new T();
			var jsonFile = Resources.Load<TextAsset>($"DBF/{databaseName}");
			if (jsonFile != null)
			{
				rtnValue = JsonConvert.DeserializeObject<T>(jsonFile.ToString());
			}

			if (rtnValue == null)
			{
				Debug.LogError($"讀不到資料檔:{databaseName}");
			}

			return rtnValue;
		}
	}
}
