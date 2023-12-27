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
            Setup();
        }
        private void OnDestroy()
        {
            if (Instance == this)
                Instance = null;

            OCEvent.ON_START_MOVE_DOWN -= OnStartMoveDown;
        }
        private void Setup()
        {
            this.safeCameraMoveTime = GameConfig.CameraMoveTime + 0.1f;
        }
        private void OnStartMoveDown(float _)
        {
            DOVirtual.DelayedCall(this.safeCameraMoveTime, () => OCEvent.ON_MOVE_DOWN_FINISH?.Invoke());
        }
    }
}