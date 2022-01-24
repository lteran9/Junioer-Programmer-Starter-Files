using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.CreateWithCode
{
   public class GameManager : MonoBehaviour
   {
      public static GameManager instance { get; private set; }

      public Color teamColor;

      void Awake()
      {
         if (instance == null)
         {
            instance = this;
            DontDestroyOnLoad(gameObject);
         }

         LoadColor();
      }

      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {

      }

      public void SaveColor()
      {
         SaveData saveData = new SaveData();
         saveData.teamColor = teamColor;

         string json = JsonUtility.ToJson(saveData);

         File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
      }

      public void LoadColor()
      {
         string path = Application.persistentDataPath + "/savefile.json";
         if (File.Exists(path))
         {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            teamColor = saveData.teamColor;
         }
      }

      [System.Serializable]
      class SaveData
      {
         public Color teamColor;
      }
   }
}