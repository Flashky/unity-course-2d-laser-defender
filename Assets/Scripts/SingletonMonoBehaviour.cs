using UnityEngine;
using System.Collections;

public class SingletonMonoBehaviour : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Singleton monobehaviour!!");
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}
