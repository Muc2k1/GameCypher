using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OlympusClimper
{
    [CreateAssetMenu(menuName = "OCGame/OCBalancer")]
    public class OCBalancer : ScriptableObject
    {
        [Header("Game-Feel")]
        public float CameraMoveTime = 0.5f;
        public float FlyCoolDown = 0.6f;
        [Header("Gameplay")]
        public float FlySpeed = 8f;
        public float RotateSpeed = 1f;
        public float DestinationLineLength = 1f;
    }
}