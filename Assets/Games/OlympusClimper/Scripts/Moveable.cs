using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace OlympusClimper
{
    public class Moveable : MonoBehaviour
    {
        [SerializeField] private float moveTime = 1f;
        private void Start()
        {
            OCGameManager.ON_START_MOVE_DOWN += VerticalMove;
        }
        private void Update()
        {

        }
        private void OnDestroy()
        {
            OCGameManager.ON_START_MOVE_DOWN -= VerticalMove;
        }
        private void VerticalMove(float height)
        {
            Debug.Log("Lag quas"); //t , s => cong thuc || Dotween => DoMove Ease
            this.transform.DOMoveY(this.transform.position.y - height, moveTime);
        }
    }
}