using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonElement : MonoBehaviour
{
    public TMP_Text title;
    public Button button;

    private void Awake()
    {
        transform.localScale = Vector3.zero;
    }
    private void Start()
    {
        transform.DOScale(Vector3.one, .25f).SetEase(Ease.OutBack);
    }
}
