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

    public void OnCellDown(ref Cell cellRef)
    {
        if(cellRef.itemSO.amount == 0) return;

        currentCell = cellRef;
        Dragger.Instance.OnDragStart(cellRef);
    }
    public void OnCellUp(ref Cell cellRef)
    {
        if(currentCell == null) return;
        
        ItemSO tempSO = cellRef.itemSO;
        cellRef.itemSO = currentCell.itemSO;
        currentCell.itemSO = tempSO;

        cellRef.Redraw();
        currentCell.Redraw();
    }

    private void OnMouseUp()
    {
        Dragger.Instance.OnDragEnd();
    }
}
