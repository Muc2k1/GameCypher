using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        [SerializeField] private Color oldColor;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private eNodeState state = eNodeState.New;
        private eNodeType type;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (this.state != eNodeState.New)
                return;

            if (col.gameObject.CompareTag("Player"))
            {
                OCGameManager.ON_PLAYER_UPDATE_POSITION?.Invoke(this);
                SetState(eNodeState.Old);
            }
        }
        private void SetState(eNodeState newState)
        {
            this.state = newState;

            if (this.state == eNodeState.Old)
                this.spriteRenderer.color = this.oldColor;
        }
        private void SetRandomPosition()
        {

        }




        //Animation
        private Tweener punchTween; 
        public void PlayPunchAnim()
        {
            if (this.punchTween != null)
                this.punchTween.Kill();

            this.punchTween = this.transform.DOPunchScale(Vector3.one * 0.1f, 0.2f, 2, 0.5f);
        }
    }
}