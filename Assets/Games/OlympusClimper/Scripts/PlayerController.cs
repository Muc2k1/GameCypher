using UnityEngine;

namespace OlympusClimper
{
    public class PlayerController : Moveable
    {
        private enum eCharacterState
        {
            Unknown = -1,
            Idling,
            Flying,
            Landing
        }
        [SerializeField] private Transform display;
        [SerializeField] private GameObject destination;
        [SerializeField] private Transform forward;
        [SerializeField] private float flyCoolDown;

        public Node CurrentNode;
        private float flySpeed;
        private float rotateSpeed;
        private float flyTimeCounter;
        private Vector3 rotateVector;
        private eCharacterState state = eCharacterState.Idling;
        private Vector3 rotationDir => (this.forward.position - this.transform.position).normalized;
        protected override void Start()
        {
            OCEvent.ON_PLAYER_LATE_UPDATE_POSITION += OnUpdatePosition;
            base.Start();
        }
        private void Update()
        {
            StateCheck();
            BehaviourCheck();
        }
        protected override void OnDestroy()
        {
            OCEvent.ON_PLAYER_LATE_UPDATE_POSITION -= OnUpdatePosition;
            base.OnDestroy();
        }
        protected override void Setup()
        {
            base.Setup();
            OCBalancer config = OCGameManager.Instance.GameConfig;
            this.flySpeed = config.FlySpeed;
            this.rotateSpeed = config.RotateSpeed;
            this.rotateVector = new Vector3(0f, 0f, 1f * this.rotateSpeed);
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
            CurrentNode?.BackToPool();
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
        private void RotateFlyDir()
        {
            this.display.Rotate(rotateVector);

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
    }
}
