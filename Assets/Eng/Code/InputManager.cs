using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            EventManager.TriggerEvent("OnMouseDown");
        else if (Input.GetKeyUp(KeyCode.Mouse0))
            EventManager.TriggerEvent("OnMouseUp");
    }
}
