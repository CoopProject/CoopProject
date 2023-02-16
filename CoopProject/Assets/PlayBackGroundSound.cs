using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackGroundSound : MonoBehaviour
{
    private void Start()
    {
       FMODUnity.RuntimeManager.PlayOneShot("event:/BackgroundSound");
    }
}
