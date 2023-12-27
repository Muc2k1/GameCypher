using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TriskDemo;

namespace OlympusClimper
{
    public class Moveable : MonoBehaviour //will update later
    {
        private float moveTime = 1f;
        private Tweener animTween; 
        protected virtual void Start()
        {
            OCEvent.ON_START_MOVE_DOWN += VerticalMove;
            Setup();
        }
        protected virtual void OnDestroy()
        {
            OCEvent.ON_START_MOVE_DOWN -= VerticalMove;
        }
        protected virtual void Setup()
        {
            this.moveTime = OCGameManager.Instance.GameConfig.CameraMoveTime;
        }
        private void VerticalMove(float height)
        {
            this.transform.DOMoveY(this.transform.position.y - height, moveTime);
        }
        public void PlayPunchAnim()
        {
            this.animTween = TriskAnimation.PlayPunchAnim(this.animTween, this.transform);
        }
        public void PlayScaleTo(float value)
        {
            this.animTween = TriskAnimation.PlayScaleTo(this.animTween, this.transform, value);
        }
    }
}