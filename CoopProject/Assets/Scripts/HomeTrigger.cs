using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeTrigger : MonoBehaviour
{
    private int _levelHome = 0;
    public int LevelHome => _levelHome;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            
        }
    }


    public void LevelUp()
    {
        _levelHome++;
        Debug.Log(_levelHome);
    }
}
