using System.Collections;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    /// <summary>
    /// Access singleton instance through this propriety.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                // Search for existing instance.
                instance = (T)FindObjectOfType(typeof(T));
            }
            return instance;
        }
    }

}

