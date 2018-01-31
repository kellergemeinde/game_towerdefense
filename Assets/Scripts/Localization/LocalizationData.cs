[System.Serializable]
public class LocalizationData
{
    public LocalizationItem[] data;
}

[System.Serializable]
public class LocalizationItem
{
    public string key;
    public string value;
}