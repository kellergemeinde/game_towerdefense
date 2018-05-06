
using UnityEngine;

public class GS_Base : MonoBehaviour {
    
    private static GameObject instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != gameObject)
        {
            Destroy(gameObject);
        }
    }
}
