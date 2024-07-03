using System;
using UnityEngine;
using UnityEngine.UI;

public class Dragger : MonoBehaviour
{
    private bool dragLock = true;
    private Image img;
    private void Awake()
    {
        img = GetComponent<Image>();
        img.enabled = false;
    }
    private void OnEnable()
    {
        EventManager.AddListener("OnDragStart", (Action<object>)OnDragStart);
        EventManager.AddListener("OnDragEnd", OnDragEnd);
    }

    private void OnDisable()
    {
        EventManager.RemoveListener("OnDragStart", (Action<object>)OnDragStart);
        EventManager.RemoveListener("OnDragEnd", OnDragEnd);
    }

    private void LateUpdate()
    {
        if(dragLock) return;
        transform.position = Input.mousePosition;
    }
    private void OnDragStart(object cellData)
    {
        Cell data = (Cell)cellData;

        img.sprite = data.itemSO.icon;
        img.enabled = true;
        dragLock = false;
    }

    private void OnDragEnd()
    {
        img.enabled = false;
        dragLock = true;
    }
}
