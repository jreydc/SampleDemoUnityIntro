using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    [SerializeField]
    private InputField nameText;

    [SerializeField]
    private InputField scoreText;

    [SerializeField]
    private Text playerList;

    private List<Characters> tmpData = new List<Characters>();

    // Start is called before the first frame update
    void Start(){
          playerList.text = "";
          scoreText.text = "";
          nameText.text = "";
    }
    static string GetSaveLocation(){
		string directory = Application.dataPath;
		string folder = "/Data/saved_binary.jreydc";
		string path = directory+folder;
		return path;
	}
    public void SaveList(){
        if (File.Exists (GetSaveLocation())) {
			using (FileStream streamOpen = File.Open (GetSaveLocation(), FileMode.OpenOrCreate)) {
				BinaryFormatter binFormatterOpen = new BinaryFormatter ();
				PlayerData playerDataOpen = (PlayerData)binFormatterOpen.Deserialize (streamOpen);

                foreach(Characters listMember in playerDataOpen.data)
                {
                    tmpData.Add(new Characters(listMember.name,listMember.score));
                }

                Debug.Log("Loaded to List: " + GetSaveLocation());
                streamOpen.Close ();
			}
		}
        BinaryFormatter binFormatter = new BinaryFormatter ();
		FileStream stream = File.Open (GetSaveLocation(), FileMode.OpenOrCreate);
        PlayerData playerData = new PlayerData ();

        foreach(Characters listMember in tmpData)
        {
            playerData.data.Add(new Characters(listMember.name,listMember.score));
        }
        tmpData.Clear();
        playerData.data.Add(new Characters(nameText.text,int.Parse(scoreText.text)));

		binFormatter.Serialize (stream, playerData);
		stream.Close ();
   
        nameText.text = "";
        scoreText.text = "";
    }

    public void LoadList(){
        if (File.Exists (GetSaveLocation())) {
			using (FileStream stream = File.Open (GetSaveLocation(), FileMode.Open)) {
				BinaryFormatter binFormatter = new BinaryFormatter ();
				PlayerData playerData = (PlayerData)binFormatter.Deserialize (stream);
				
                string result = "";
                playerData.data.Sort();
        
                foreach(Characters listMember in playerData.data)
                {
                    result += listMember.name + " - " + listMember.score + "\n";
                }

                playerList.text = result; 

                Debug.Log("Loaded from: " + GetSaveLocation());
			}
		} else {
			Debug.Log("Could not find: " + GetSaveLocation());
		}
        
    }

    public void DeleteList(){
        if (File.Exists (GetSaveLocation())) {
			using (FileStream streamOpen = File.Open (GetSaveLocation(), FileMode.OpenOrCreate)) {
				BinaryFormatter binFormatterOpen = new BinaryFormatter ();
				PlayerData playerDataOpen = (PlayerData)binFormatterOpen.Deserialize (streamOpen);

                foreach(Characters listMember in playerDataOpen.data)
                {
                    if (nameText.text != listMember.name){
                        tmpData.Add(new Characters(listMember.name,listMember.score));
                    }
                }

                Debug.Log("Deleted from List: " + GetSaveLocation());

                streamOpen.Close ();
			}
		}
        BinaryFormatter binFormatter = new BinaryFormatter ();
		FileStream stream = File.Open (GetSaveLocation(), FileMode.OpenOrCreate);
        PlayerData playerData = new PlayerData ();

        foreach(Characters listMember in tmpData)
        {
            playerData.data.Add(new Characters(listMember.name,listMember.score));
        }
        tmpData.Clear();

		binFormatter.Serialize (stream, playerData);
		stream.Close ();
    }
}

[Serializable]
public class PlayerData{
    public List<Characters> data = new List<Characters>();
}
