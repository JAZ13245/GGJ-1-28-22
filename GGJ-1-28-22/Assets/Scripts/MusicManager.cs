using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MusicPlayer");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        
    }

}
