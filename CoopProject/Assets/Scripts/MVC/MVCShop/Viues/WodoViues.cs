using UnityEngine;

public class WodoViues : ShopElementViue
{ 

  private void Awake()
  {
    _resourceNumber.text = $"{_resourceCount}";
  }
}
