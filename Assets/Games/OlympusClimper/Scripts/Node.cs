using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

namespace OlympusClimper
{
    public class Node : MonoBehaviour
    {
        public enum eNodeType
        {
            Unknown = -1,
            Normal,
            Scope,
        }
        public enum eNodeState
        {
            Unknown = -1,
            New,
            Old
        }
        private const float HORIZONTAL_BOUND = 2f;
        [SerializeField] private Color oldColor;
        [SerializeField] private Color newColor;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private eNodeState state = eNodeState.New;
        private eNodeType type;
        private NodesPool pool;
        private void Start()
        {
            this.pool = GetComponentInParent<NodesPool>();
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (this.state != eNodeState.New)
                return;

            if (col.gameObject.CompareTag("Player"))
            {
                OCEvent.ON_PLAYER_UPDATE_POSITION?.Invoke(this);
                SetState(eNodeState.Old);
            }
        }
        private void SetState(eNodeState newState)
        {
            this.state = newState;

            if (this.state == eNodeState.Old)
                this.spriteRenderer.color = this.oldColor;
            if (this.state == eNodeState.New)
                this.spriteRenderer.color = this.newColor;
        }
        private bool isChoosen = false;
        public void SetRandomPosition()
        {
            Debug.Log("Moving");
            Node highestNode = this.pool.GetTheHighestNode();
            Vector2 newPos = new Vector2(UnityEngine.Random.Range(-HORIZONTAL_BOUND, HORIZONTAL_BOUND), highestNode.transform.position.y + 3.5f);
            this.transform.position = newPos;
            this.transform.localScale = Vector3.one;
            isChoosen = false;
            SetState(eNodeState.New);
        }
        public void BackToPool()
        {
            this.pool.BackToPool(this);
            SetVisible(false);
            isChoosen = true;
        }
        private void SetVisible(bool isVisible)
        {
            PlayScaleTo(isVisible ? 1f : 0);
        }




        //Animation
        private Tweener animTween; 
        public void PlayPunchAnim()
        {
            if (this.animTween != null)
                this.animTween.Kill();

            this.animTween = this.transform.DOPunchScale(Vector3.one * 0.1f, 0.2f, 2, 0.5f);
        }
        public void PlayScaleTo(float value)
        {
            if (this.animTween != null)
                this.animTween.Kill();

            this.animTween = this.transform.DOScale(value, 0.5f);
        }
    }
}