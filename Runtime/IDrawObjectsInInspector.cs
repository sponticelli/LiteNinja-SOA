using System.Collections.Generic;
using UnityEngine;

namespace LiteNinja.SOA
{
  public interface IDrawObjectsInInspector
  {
    List<Object> GetAllObjects();
  }
}