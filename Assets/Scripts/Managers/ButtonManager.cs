using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonManager : MonoBehaviour
{
    private List<Button> buttons = new();

    [SerializeField] private Transform model, buttonsTrasnform;
    [SerializeField] private ButtonElement buttonPrefab;

    [Inject] private CameraController cameraController;
    [Inject] private Description description;

    private void Start()
    {
        buttonsTrasnform.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
        {
            ResetElements();
        });

        AddButtonElements();
    }

    async void AddButtonElements()
    {
        for (int i = 0; i < model.childCount; i++)
        {
            ButtonElement currentElement = Instantiate(buttonPrefab, transform);
            currentElement.transform.SetParent(buttonsTrasnform);
            currentElement.title.text = model.GetChild(i).name;

            Button button = currentElement.button;

            buttons.Add(button);

            button.onClick.AddListener(() =>
            {
                OnClickLogic(button);
            });

            await UniTask.Delay(25);
        }
    }

    async void OnClickLogic(Button button)
    {
        var id = buttons.IndexOf(button);

        for (int j = 0; j < model.childCount; j++)
        {
            if (id != j)
            {
                model.GetChild(j).GetComponent<Element>().DeSelect();

                await UniTask.Delay(15);
            }            
        }

        model.GetChild(id).GetComponent<Element>().Select();

        cameraController.Focus(40f);

        description.SetDescriptions(id);
        description.OpenAnimationWindow();
    }

    async void ResetElements()
    {
        cameraController.Focus(60f);

        description.CloseAnimationWindow();

        for (int i = 0; i < model.childCount; i++)
        {
            model.GetChild(i).GetComponent<Element>().Reset();

            await UniTask.Delay(15);
        }
    }
}
