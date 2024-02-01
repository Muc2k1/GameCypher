using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using DG.Tweening;
using UnityEditor.Rendering;
using UnityEditor.SceneManagement;

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
        public static OCGameManager Instance;
        [SerializeField] private PlayerController player;
        [SerializeField] private OCBalancer config;
        
        private float safeCameraMoveTime;
        private int scoreTimes = 0;
        private int currentLevel = 0;
        private int stepToLevelUp = 2;

        private int rotateSpeedBuffLevel = 0; //buff level can be positive or negative
        private int destinationLengthBuffLevel = 0; //positive level will have positive trend effect such as increasing sthing

        public OCBalancer GameConfig => this.config;
        public PlayerController Player => this.player;
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }
        private void Start()
        {
            OCEvent.ON_START_MOVE_DOWN += OnStartMoveDown;
            OCEvent.ON_ADD_SCORE += OnAddScore;
            OCEvent.ON_BUFF_APPLY += OnBuffApply;
            Setup();
        }
        private void OnDestroy()
        {
            if (Instance == this)
                Instance = null;

            OCEvent.ON_START_MOVE_DOWN -= OnStartMoveDown;
            OCEvent.ON_ADD_SCORE -= OnAddScore;
            OCEvent.ON_BUFF_APPLY -= OnBuffApply;
        }
        private void Setup()
        {
            this.safeCameraMoveTime = this.GameConfig.CameraMoveTime + 0.1f;
            this.stepToLevelUp = this.GameConfig.StepToLevelUp;
        }
        private void OnStartMoveDown(float _)
        {
            DOVirtual.DelayedCall(this.safeCameraMoveTime, () => OCEvent.ON_MOVE_DOWN_FINISH?.Invoke());
        }
        private void OnAddScore(int _)
        {
            this.scoreTimes++;
            if (scoreTimes >= stepToLevelUp)
            {
                this.scoreTimes -= stepToLevelUp;
                this.currentLevel++;
                UpdateDifficultLevel();
            }
        }
        private void UpdateDifficultLevel()
        {
            float newRotationSpeed = this.GameConfig.RotateSpeed + this.GameConfig.RotateSpeedUpEachLevel * currentLevel + this.GameConfig.RotateSpeedBuffEachLevel * rotateSpeedBuffLevel;
            float newDestinationLength = this.GameConfig.DestinationLineLength - this.GameConfig.DestinationDecreaseEachLevel * currentLevel + this.GameConfig.DestinationDecreaseEachLevel * destinationLengthBuffLevel;
            this.Player.UpdateLevel(newRotationSpeed, newDestinationLength);
        }
        public Node.eNodeType GetRandomNodeType() //Random in range each difficult level
        {
            //relate to this.currentLevel
            return Node.eNodeType.Normal;
        }
        private void OnBuffApply(string buffName)
        {
            switch (buffName)
            {
                case "Faster":
                    rotateSpeedBuffLevel++;
                    UpdateDifficultLevel();
                    break;
                case "Slower":
                    rotateSpeedBuffLevel--;
                    break;
                default:
                    Debug.Log("Buff name is not available");
                    break;
            }
        }   
    }
}