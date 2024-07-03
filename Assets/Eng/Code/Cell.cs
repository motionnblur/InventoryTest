using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public ItemSO itemSO;
    private Image img;
    private Text text;
    void Awake()
    {
        img = transform.GetChild(0).GetComponent<Image>();
        text = transform.GetChild(1).GetComponent<Text>();
        
        img.enabled = true;

        if(itemSO != null)
        {
            img.sprite = itemSO.icon;
            text.text = itemSO.amount.ToString();
        }
    }

    public void Redraw()
    {
        img.sprite = itemSO.icon;
        text.text = itemSO.amount.ToString();
    }
}