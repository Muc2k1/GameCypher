using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace OlympusClimper
{
    public class OCScoreManager : MonoBehaviour
    {
        [SerializeField] private Text scoreTxt;
        float step = 3.5f;
        int score = 0;
        private void Start()
        {
            OCEvent.ON_PLAYER_UPDATE_POSITION += OnScore; //Cheat
        }
        private void OnDestroy()
        {
            OCEvent.ON_PLAYER_UPDATE_POSITION -= OnScore;
        }
        private void OnScore(Node _)
        {
            int additionalScore = 1;
            score += additionalScore;
            this.scoreTxt.text = score.ToString();
        }
    }
}