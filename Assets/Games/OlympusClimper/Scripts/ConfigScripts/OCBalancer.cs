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
        public float HolyOccurRate = 0.15f;
        public float DevilOccurRate = 0.15f;
        [Header("Balancer")]
        public int StepToLevelUp = 2;
        public float RotateSpeedUpEachLevel = 0.05f;
        public float DestinationDecreaseEachLevel = 0.05f;
        public float MaxRotateSpeed = 1.5f;
        public float MinDestinationLength = 0.25f;

        public float RotateSpeedBuffEachLevel = 0.1f;
        public float DestinationBuffEachLevel = 0.05f;
    }
}