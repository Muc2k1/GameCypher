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
        int streak = 0;
        private void Start()
        {
            OCEvent.ON_ADD_SCORE += OnScore; //Cheat
        }
        private void OnDestroy()
        {
            OCEvent.ON_ADD_SCORE -= OnScore;
        }
        private void OnScore(int additionalScore)
        {
            score += additionalScore;
            if (score > 1)
            {
                //
            }
            this.scoreTxt.text = score.ToString();
        }
    }
}