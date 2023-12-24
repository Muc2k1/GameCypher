using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OlympusClimper
{
    public class Moveable : MonoBehaviour
    {
        private void Start()
        {
            OCGameManager.ON_PLAYER_UPDATE_POSITION += VerticalMove;
        }
        private void OnDestroy()
        {
            OCGameManager.ON_PLAYER_UPDATE_POSITION -= VerticalMove;
        }
        private void VerticalMove(Node node)
        {
            
        }
    }
}