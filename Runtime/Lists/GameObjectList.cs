using System;
using UnityEngine;

namespace LiteNinja.SOA.Lists
{
  [Serializable]
  [CreateAssetMenu(menuName = "LiteNinja/Lists/GameObject")]
  public class GameObjectList : ASOList<GameObject>
  {
  }
}