using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class FloatEvent : UnityEvent<float> { }

public class PlayerPrefsFloatLoader : MonoBehaviour
{
    [SerializeField] private string key;
    [SerializeField] private float defaultValue = 0;
    [SerializeField] private FloatEvent onValueLoaded;

    private void Awake()
    {
        onValueLoaded.Invoke(PlayerPrefs.GetFloat(key, defaultValue));
    }
}