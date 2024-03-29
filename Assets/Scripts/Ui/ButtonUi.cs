using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonUi : MonoBehaviour
{
    private Button button;

    [Inject] private ProjectManager projectManager;

    public ButtonType buttonType;

    private Tween tween;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            switch (buttonType)
            {
                case ButtonType.left:
                    RotateObject(Vector3.down * 90f);
                    break;
                case ButtonType.right:
                    RotateObject(Vector3.up * 90f);
                    break;
                case ButtonType.top:
                    RotateObject(Vector3.left * 90f);
                    break;
                case ButtonType.bottom:
                    RotateObject(Vector3.right * 90f);
                    break;
                case ButtonType.forward:
                    RotateObject(Vector3.zero);
                    break;
                case ButtonType.back:
                    RotateObject(Vector3.up * 180f);
                    break;
                case ButtonType.reset:
                    RotateObject(Vector3.zero);
                    break;
                case ButtonType.exit:
                    Application.Quit();
                    break;
            }

        });
    }

    private void RotateObject(Vector3 dir)
    {
        tween.Kill();
        tween = projectManager.mainObj.transform.DORotate(dir, .25f);
    }

    public enum ButtonType
    {
        left,
        right,
        top,
        bottom,
        forward,
        back,
        reset,
        exit
    }
}
