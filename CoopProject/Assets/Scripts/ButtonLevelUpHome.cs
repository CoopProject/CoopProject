using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLevelUpHome : MonoBehaviour
{
  [SerializeField] private HomeTrigger _home;
  [SerializeField] private IncludingIslands _includingIslands;
  

  public void ActiveNextIsland()
  {
    _includingIslands.ActiveNextIsland(_home.LevelHome);
    _home.LevelUp();
  }

}
