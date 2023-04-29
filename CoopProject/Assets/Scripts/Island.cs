using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island :MonoBehaviour
{
    public void ActiveIsland() => gameObject.SetActive(true);
    
    public void DisableIsland() => gameObject.SetActive(false);
}