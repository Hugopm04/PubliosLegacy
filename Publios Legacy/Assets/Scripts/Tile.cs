using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private bool selected = false;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void ToggleSelection()
    {
        selected = !selected;
        image.color = selected ? Color.yellow : Color.red;
    }
}
