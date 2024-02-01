using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

namespace OlympusClimper
{
    public class Node : Moveable
    {
        public enum eNodeType
        {
            Tiny = - 6,
            Confusion,
            Faster,
            HorizontalMove,
            VerticleMove,
            Revert = -1,
            Normal = 0,
            Score = 1,
            Scope,
            Slower,
            Giant,
            Heal = 5, //decrease difficult level
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
        [SerializeField] private GameObject juiceVFX;
        [SerializeField] private eNodeState state = eNodeState.New;
        private eNodeType type; public eNodeType TYPE { get {return type;} }
        private NodesPool pool;
        protected override void Start()
        {
            this.pool = GetComponentInParent<NodesPool>();
            base.Start();
            SetRandomNodeType();
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
            {
                this.juiceVFX.SetActive(true);
                this.spriteRenderer.color = this.oldColor;
            }
            if (this.state == eNodeState.New)
                this.spriteRenderer.color = this.newColor;
        }
        public void SetRandomPosition() //setting new positon for node after it goes out screenbound 
        {
            Debug.Log("Moving");
            Node highestNode = this.pool.GetTheHighestNode();
            Vector2 newPos = new Vector2(UnityEngine.Random.Range(-HORIZONTAL_BOUND, HORIZONTAL_BOUND), highestNode.transform.position.y + 3.5f);
            this.transform.position = newPos;
            this.transform.localScale = Vector3.one;
            SetState(eNodeState.New);
        }
        public void BackToPool()
        {
            SetVisible(false);
        }
        private void SetVisible(bool isVisible)
        {
            PlayScaleTo(isVisible ? 1f : 0);
        }
        private void SetRandomNodeType()
        {
            int tempValue = UnityEngine.Random.Range(-6, 6); //depend on the value of eNodeType enum
            type = (eNodeType)tempValue;
        }
    }
}