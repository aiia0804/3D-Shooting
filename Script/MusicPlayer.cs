using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //Keep only one song playing.
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
