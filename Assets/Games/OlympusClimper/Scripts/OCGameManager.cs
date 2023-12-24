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
        public static Action<Node /*Step*/> ON_PLAYER_UPDATE_POSITION;
        private void OnPlayerUpdatePosition()
        {
            
        } 
    }
}