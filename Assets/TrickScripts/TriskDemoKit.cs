using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace TriskDemo
{
    public class TriskAnimation
    {
        public static Tweener PlayPunchAnim(Tweener animTween, Transform subject, float punch = 0.1f, float duration = 0.2f, int vibrato = 2, float elasticity = 0.5f, Action callback = null)
        {
            if (animTween != null)
                animTween.Kill();

            if (callback != null)
                return subject.DOPunchScale(Vector3.one * punch, duration, vibrato, elasticity).OnComplete(() => callback());
            return subject.DOPunchScale(Vector3.one * punch, duration, vibrato, elasticity);
        }
        public static Tweener PlayScaleTo(Tweener animTween, Transform subject, float value, float duration = 0.5f, Action callback = null)
        {
            if (animTween != null)
                animTween.Kill();

            if (callback != null)
                return subject.transform.DOScale(value, duration).OnComplete(() => callback());
            return subject.transform.DOScale(value, duration);
        }
    }
}
