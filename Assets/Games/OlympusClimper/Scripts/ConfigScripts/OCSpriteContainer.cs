using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace OlympusClimper
{
    [Serializable]
    public class SpriteInfo
    {
        public string name; // name of sprite
        public Sprite sprite;
    }

    [CreateAssetMenu(menuName = "OCGame/OCSpriteContainer")]
    public class OCSpriteContainer : ScriptableObject
    {
        public SpriteInfo[] sprites;

        public Sprite GetSprite(string name)
        {
            SpriteInfo spriteTarget = Array.Find(sprites, sprite => sprite.name == name);
            Debug.Log(spriteTarget.name);
            return spriteTarget.sprite;
        }
    }
}