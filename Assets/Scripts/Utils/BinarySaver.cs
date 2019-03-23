using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class BinarySaver
{
    const string statisticFolderName = "BinaryDungeLikeStatisticData";
    const string currentGameFolderName = "BinaryDungeLikeCurrentGameData";
    const string fileExtension = ".dat";

    //TODO Refactor 

    public static void SaveData(DungeLikeStatisticData data)
    {
        string folderPath = Path.Combine(Application.persistentDataPath, statisticFolderName);
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);
        string filePath = Path.Combine(folderPath, statisticFolderName + fileExtension);

        var binaryFormatter = new BinaryFormatter();
        using (FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize(fileStream, data);
        }
    }

    public static void SaveData(DungeLikeCurrentGameData data)
    {
        string folderPath = Path.Combine(Application.persistentDataPath, currentGameFolderName);
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);
        string filePath = Path.Combine(folderPath, currentGameFolderName + fileExtension);

        var binaryFormatter = new BinaryFormatter();
        using (FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize(fileStream, data);
        }
    }

    public static void SaveData(DungeLikeStatisticData data, string path)
    {
        if (!Directory.Exists(path) || string.IsNullOrEmpty(path))
            return;

        var binaryFormatter = new BinaryFormatter();
        using (FileStream fileStream = File.Open(path, FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize(fileStream, data);
        }
    }

    public static DungeLikeStatisticData LoadStatisticData()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, statisticFolderName);
        string filePath = Path.Combine(folderPath, statisticFolderName + fileExtension);

        if (!File.Exists(filePath))
            return new DungeLikeStatisticData();

        var binaryFormatter = new BinaryFormatter();
        using (FileStream fileStream = File.Open(filePath, FileMode.Open))
        {
            return (DungeLikeStatisticData)binaryFormatter.Deserialize(fileStream);
        }
    }

    public static DungeLikeCurrentGameData LoadCurrentGameData()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, currentGameFolderName);
        string filePath = Path.Combine(folderPath, currentGameFolderName + fileExtension);

        if (!File.Exists(filePath))
            return new DungeLikeCurrentGameData();

        var binaryFormatter = new BinaryFormatter();
        using (FileStream fileStream = File.Open(filePath, FileMode.Open))
        {
            return (DungeLikeCurrentGameData)binaryFormatter.Deserialize(fileStream);
        }
    }

    public static DungeLikeStatisticData LoadData(string path)
    {
        var binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(path, FileMode.Open))
        {
            return (DungeLikeStatisticData)binaryFormatter.Deserialize(fileStream);
        }
    }
}
