using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Tween _tween;
    public void Focus(float fieldOfView)
    {
        _tween = DOTween.To(() => Camera.main.fieldOfView, x => Camera.main.fieldOfView = x, fieldOfView, .5f);
    }
}
