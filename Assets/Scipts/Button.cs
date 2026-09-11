using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Interaction interaction;
    public Image buttonImage;

    public float normalAlpha = 0.3f;
    public float activeAlpha = 1.0f;

    void Start()
    {
        SetAlpha(normalAlpha);
    }

    void Update()
    {
        if (interaction.playerNearby)
        {
            SetAlpha(activeAlpha);
        }
        else
        {
            SetAlpha(normalAlpha);
        }
    }

    void SetAlpha(float alpha)
    {
        Color color = buttonImage.color;
        color.a = alpha;
        buttonImage.color = color;
    }
}