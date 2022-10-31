using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/Color Event")]
    [Serializable]
    public class ColorEvent : ASOEvent<Color>
    {
    }
    
    
}