using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TriskDemo;

namespace OlympusClimper
{
    public class Moveable : MonoBehaviour //will update later
    {
        protected float moveTime = 1f;
        protected Tweener animTween; 
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
        protected virtual void VerticalMove(float height)
        {
            this.transform.DOMoveY(this.transform.position.y - height, moveTime);
        }
        public void PlayPunchAnim()
        {
            this.animTween = TriskAnimation.PlayPunchAnim(this.animTween, this.transform, 0.3f);
        }
        public void PlayScaleTo(float value)
        {
            this.animTween = TriskAnimation.PlayScaleTo(this.animTween, this.transform, value);
        }
    }
}