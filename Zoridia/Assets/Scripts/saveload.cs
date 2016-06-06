using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class saveload : MonoBehaviour {

    public static data dataFile;
    static string path = "";

    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        path = Application.persistentDataPath + "/GameData.dat";
    }

	public static void Save()
    {
        //set save data
        //dataFile.SetLevel(Application.loadedLevel);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Create);

        bf.Serialize(fileStream, dataFile);
        fileStream.Close();

        Debug.Log("Game data saved.");
    }

    public static void Load()
    {
        if(File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            dataFile = bf.Deserialize(fileStream) as data;

            //retrieve game data
            //Application.LoadLevel(dataFile.GetLevel());

            Debug.Log("Game data loaded.");
        }
        else
        {
            Debug.LogWarning("File does not exist. Create a new safe file.");
            data newDataFile = new data();

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Create);

            bf.Serialize(fileStream, newDataFile);
            fileStream.Close();

            Debug.Log("New save file created. Please Proceed.");
        }
    }

    
}
