using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject chat1;
    public GameObject chat2;
    public GameObject startScene;

    public void begin()
    {
        chat1.SetActive(true);
        chat2.SetActive(true);
        startScene.SetActive(false);
    }
}
