using System;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    public static DragManager Instance { get; private set; }
    private GameObject dragger;
    private GameObject canvas;
    private Cell currentCell;

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

        canvas = GameObject.Find("Canvas");
        dragger = Resources.Load<GameObject>("Prefabs/Dragger");

        dragger = Instantiate(dragger, canvas.transform);
    }
    private void OnEnable()
    {
        EventManager.AddListener("OnMouseUp", OnMouseUp);
    }
    private void OnDisable()
    {
        EventManager.RemoveListener("OnMouseUp", OnMouseUp);
    }

    public void OnCellDown(ref Cell cellData)
    {
        if(cellData.itemSO.amount == 0) return;

        currentCell = cellData;
        EventManager.TriggerEvent("OnDragStart", (object)cellData); //Dragger.cs
    }
    public void OnCellUp(ref Cell cellData)
    {
        if(currentCell == null) return;
        
        ItemSO tempSO = cellData.itemSO;
        cellData.itemSO = currentCell.itemSO;
        currentCell.itemSO = tempSO;

        cellData.Redraw();
        currentCell.Redraw();
    }

    private void OnMouseUp()
    {
        EventManager.TriggerEvent("OnDragEnd"); //Dragger.cs
    }
}
