using System;
using UnityEngine;

namespace LiteNinja.SOA.Variables
{
    [CreateAssetMenu(menuName = "LiteNinja/Variables/Texture Var", fileName = "TextureVar")]
    [Serializable]
    
    public class TextureVar : ASOVar<Texture>
    {
    }
}