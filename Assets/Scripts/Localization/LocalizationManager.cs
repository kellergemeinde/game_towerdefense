using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour {

    public static LocalizationManager instance;

    private Dictionary<string, string> localizedText;
    private string missingText = "Localized Text not found";

    public bool IsReady { get; private set; }

	void Awake ()
    {
        //Make sure there is only one instance even in different szenes
	    if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        IsReady = false;
    }

    public void LoadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, "Localization/" + fileName);

        if(File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            for (int i = 0; i < loadedData.data.Length; i++)
            {
                localizedText.Add(loadedData.data[i].key, loadedData.data[i].value);
            }

            Debug.Log("Localization Manager - Data loaded from File: " + filePath);
            Debug.Log("Localization Manager - Dictionary contains: " + localizedText.Count + "entries");
        }
        else
        {
            Debug.LogError("Localization Manager - Cannot find file: " + filePath);
        }

        IsReady = true;
    }

    public string GetLocalizedValue(string key)
    {
        return localizedText.ContainsKey(key) ? localizedText[key] : missingText;
    }
}
