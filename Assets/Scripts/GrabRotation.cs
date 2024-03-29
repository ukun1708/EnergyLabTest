using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRotation : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;

    bool isRotating = false;

    float startMousePosX;
    float startMousePosY;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
            startMousePosX = Input.mousePosition.x;
            startMousePosY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            float currentMousePosX = Input.mousePosition.x;
            float currentMousePosY = Input.mousePosition.y;
            float mouseMovementX = currentMousePosX - startMousePosX;
            float mouseMovementY = currentMousePosY - startMousePosY;

            transform.Rotate(Vector3.up, -mouseMovementX * speed * Time.deltaTime);
            transform.Rotate(Vector3.left, -mouseMovementY * speed * Time.deltaTime);

            startMousePosX = currentMousePosX;
            startMousePosY = currentMousePosY;
        }
    }

    void ResetRotation()
    {
        transform.DORotate(Vector3.zero, .25f);
    }
}
