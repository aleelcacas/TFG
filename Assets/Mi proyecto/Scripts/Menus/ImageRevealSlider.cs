using UnityEngine;
using UnityEngine.UI;

public class ImageRevealSlider : MonoBehaviour
{
    public RectTransform maskPanel;
    public Slider slider;
    public float maxRevealWidth = 200f; // ancho completo de la imagen

    private void Start()
    {
        slider.onValueChanged.AddListener(UpdateMaskPosition);
        UpdateMaskPosition(slider.value);
    }

    void UpdateMaskPosition(float value)
    {
        // Cambia el ancho del mask panel (no escala la imagen)
        Vector2 size = maskPanel.sizeDelta;
        size.x = value * maxRevealWidth;
        maskPanel.sizeDelta = size;
    }
}
