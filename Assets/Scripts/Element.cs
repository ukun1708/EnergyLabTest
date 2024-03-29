using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField] private Outline outline;

    Vector3 startScale;

    Tween scaleTween;

    private void Awake()
    {
        outline = GetComponent<Outline>();
        startScale = transform.localScale;
    }

    public void Select()
    {
        scaleTween.Kill();
        outline.enabled = true;
        scaleTween = transform.DOScale(startScale, .25f).SetEase(Ease.OutBack);
    }
    public void DeSelect()
    {
        scaleTween.Kill();
        outline.enabled = false;
        scaleTween = transform.DOScale(Vector3.zero, .25f).SetEase(Ease.InBack);
    }
    public void Reset()
    {
        scaleTween.Kill();        
        outline.enabled = false;
        scaleTween = transform.DOScale(startScale, .25f).SetEase(Ease.OutBack);
    }
}
