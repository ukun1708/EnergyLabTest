using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class Description : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;

    private string fileTitlePath, fileDescriptionPath;
    string[] titlelines, descriptionLines;

    [Inject] ProjectManager projectManager;

    private void Start()
    {
        if (projectManager.onBuild == true)
        {
            fileTitlePath = "TitleElements.txt";
            fileDescriptionPath = "DescriptionElements.txt";
        }
        else
        {
            fileTitlePath = Application.dataPath + "/TitleElements.txt";
            fileDescriptionPath = Application.dataPath + "/DescriptionElements.txt";
        }

        titlelines = File.ReadAllLines(fileTitlePath);
        descriptionLines = File.ReadAllLines(fileDescriptionPath);

        titleText.transform.localScale = Vector3.zero;
        descriptionText.transform.localScale = Vector3.zero;
    }

    public void SetDescriptions(int index)
    {
        titleText.text = titlelines[index];
        descriptionText.text = descriptionLines[index];
    }

    public async void OpenAnimationWindow()
    {
        titleText.transform.DOScale(Vector3.one, .25f).SetEase(Ease.OutBack);
        await UniTask.Delay(250);
        descriptionText.transform.DOScale(Vector3.one, .25f).SetEase(Ease.OutBack);
    }
    public async void CloseAnimationWindow()
    {
        titleText.transform.DOScale(Vector3.zero, .25f).SetEase(Ease.InBack);
        await UniTask.Delay(100);
        descriptionText.transform.DOScale(Vector3.zero, .25f).SetEase(Ease.InBack);
    }
}
