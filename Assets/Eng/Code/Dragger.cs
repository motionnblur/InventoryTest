using System;
using UnityEngine;
using UnityEngine.UI;

public class Dragger : MonoBehaviour
{
    public static Dragger Instance { get; private set; }
    private bool dragLock = true;
    private Image img;
    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 

        img = GetComponent<Image>();
        img.enabled = false;
    }

    private void LateUpdate()
    {
        if(dragLock) return;
        transform.position = Input.mousePosition;
    }
    public void OnDragStart(Cell cell)
    {
        img.sprite = cell.itemSO.icon;
        img.enabled = true;
        dragLock = false;
    }

    public void OnDragEnd()
    {
        img.enabled = false;
        dragLock = true;
    }
}
