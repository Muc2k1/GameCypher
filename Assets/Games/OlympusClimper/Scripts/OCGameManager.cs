using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
namespace OlympusClimper
{
    public class OCGameManager : MonoBehaviour
    {
        private enum eGameState
        {
            Unknown = -1,
            Playing,
            Pausing
        }
        public static OCGameManager Instance;
        public static Action<Node /*Step*/> ON_PLAYER_UPDATE_POSITION;
        public static Action<Node /*Step*/> ON_PLAYER_LATE_UPDATE_POSITION;
        public static Action<float /*Height*/> ON_START_MOVE_DOWN;
        [SerializeField] private PlayerController player;
        public PlayerController Player => this.player;
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }
        private void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
        }
        private void OnPlayerUpdatePosition()
        {
            
        } 
    }
}