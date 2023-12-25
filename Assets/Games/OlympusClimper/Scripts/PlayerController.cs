using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;
using DG.Tweening;

namespace OlympusClimper
{
    public class PlayerController : MonoBehaviour
    {
        private enum eCharacterState
        {
            Unknown = -1,
            Idling,
            Flying,
            Landing
        }
        [SerializeField] private float flySpeed;
        [SerializeField] private float rotateSpeed;
        [SerializeField] private Transform display;
        [SerializeField] private GameObject destination;
        [SerializeField] private Transform forward;
        [SerializeField] private float flyCoolDown;

        private float flyTimeCounter;
        private eCharacterState state = eCharacterState.Idling;
        public Node CurrentNode {get; private set;}
        private Vector3 rotationDir => (this.forward.position - this.transform.position).normalized;
        private void Start()
        {
            OCGameManager.ON_PLAYER_LATE_UPDATE_POSITION += OnUpdatePosition;
        }
        private void Update()
        {
            StateCheck();
            BehaviourCheck();
        }
        private void OnDestroy()
        {
            OCGameManager.ON_PLAYER_LATE_UPDATE_POSITION -= OnUpdatePosition;
        }
        private void StateCheck()
        {
            switch (this.state)
            {
                case eCharacterState.Unknown:
                break;
                case eCharacterState.Idling:
                    RotateFlyDir();
                break;
                case eCharacterState.Flying:
                    Fly();
                break;
                case eCharacterState.Landing:
                break;
            }
        }
        private void SetState(eCharacterState newState)
        {
            this.state = newState;
        }
        private void StartFly()
        {
            if (this.flyTimeCounter > 0)
                return;
            
            PlayPunchAnim();
            CurrentNode?.PlayPunchAnim();
            SetState(eCharacterState.Flying);
            this.destination.SetActive(false);
            this.flyTimeCounter = this.flyCoolDown;
        }
        private void Fly()
        {
            this.transform.Translate(this.flySpeed * Time.deltaTime * this.rotationDir);
        }
        private void BehaviourCheck()
        {
            DebugInput();
        }
        private void DebugInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartFly();
            }
        }
        private void UpdateCurrentNode()
        {
        }
        private void RotateFlyDir()
        {
            this.display.Rotate(new Vector3(0f, 0f, 1f * this.rotateSpeed));

            if (this.flyTimeCounter > 0)
                this.flyTimeCounter -= Time.deltaTime;
        }
        private void OnUpdatePosition(Node newNode)
        {
            PlayPunchAnim();
            newNode.PlayPunchAnim();
            SetState(eCharacterState.Idling);
            this.destination.SetActive(true);
            this.CurrentNode = newNode;
            this.transform.position = newNode.transform.position;
        }






        //Animation
        private Tweener punchTween; 
        private void PlayPunchAnim()
        {
            if (this.punchTween != null)
                this.punchTween.Kill();

            this.punchTween = this.transform.DOPunchScale(Vector3.one * 0.1f, 0.2f, 2, 0.5f);
        }
    }
}
