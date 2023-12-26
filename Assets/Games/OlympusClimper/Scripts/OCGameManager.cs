using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using DG.Tweening;

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
        public PlayerController Player => this.player;
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }
        private void Start()
        {
            OCEvent.ON_START_MOVE_DOWN += OnStartMoveDown;
        }
        private void OnDestroy()
        {
            if (Instance == this)
                Instance = null;

            OCEvent.ON_START_MOVE_DOWN -= OnStartMoveDown;
        }
        private void OnStartMoveDown(float _)
        {
            Debug.Log("Down");
            DOVirtual.DelayedCall(1.2f, () =>
            {
                OCEvent.ON_MOVE_DOWN_FINISH?.Invoke();
                Debug.Log("Down finished");
            }
            );
        }
        private void OnPlayerUpdatePosition()
        {

        }
    }
}