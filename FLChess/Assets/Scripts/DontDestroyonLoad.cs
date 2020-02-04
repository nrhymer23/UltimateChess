using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyonLoad : MonoBehaviour
{

    static DontDestroyonLoad instance = null;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
    }
}

