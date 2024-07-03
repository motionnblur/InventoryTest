using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RaycastManager : MonoBehaviour
{
    [SerializeField] GraphicRaycaster m_Raycaster;
    [SerializeField] EventSystem m_EventSystem;
    PointerEventData m_PointerEventData;

    void Awake()
    {
        m_EventSystem = GetComponent<EventSystem>();
    }
    private void OnEnable()
    {
        EventManager.AddListener("OnMouseDown", OnMouseDown);
        EventManager.AddListener("OnMouseUp", OnMouseUp);
    }
    private void OnDisable()
    {
        EventManager.RemoveListener("OnMouseDown", OnMouseDown);
        EventManager.RemoveListener("OnMouseUp", OnMouseUp);
    }

    private void OnMouseDown()
    {
        foreach (RaycastResult result in DoRaycastAndGetResults())
        {
            var cellObject = result.gameObject;

            if (cellObject.TryGetComponent(out Cell cellRef))
            {
                DragManager.Instance.OnCellDown(ref cellRef);
            }
        }
    }
    private void OnMouseUp()
    {
        foreach (RaycastResult result in DoRaycastAndGetResults())
        {
            var cellObject = result.gameObject;

            if (cellObject.TryGetComponent(out Cell cellRef))
            {
                DragManager.Instance.OnCellUp(ref cellRef);
            }
        }
    }

#region helpers
    private List<RaycastResult> DoRaycastAndGetResults()
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        m_Raycaster.Raycast(m_PointerEventData, results);

        return results;
    }
#endregion
}
