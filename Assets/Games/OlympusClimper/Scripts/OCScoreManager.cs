using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TriskDemo;
using DG.Tweening;

namespace OlympusClimper
{
    public class OCScoreManager : MonoBehaviour
    {
        [SerializeField] private Text scoreTxt;
        private Tweener animTween;
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
            if (additionalScore > 1)  streak++;
            else            streak = 0;
            
            score += additionalScore + (streak);
            this.scoreTxt.text = score.ToString();
            this.animTween = TriskAnimation.PlayPunchAnim(this.animTween, this.transform);
        }
    }
}