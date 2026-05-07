using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    public GameObject toggleImage;
    public Sprite offSprite;
    public Sprite onSprite;

    private bool on = false;

    public void doToggle()
    {
        if (on)
        {
            toggleImage.GetComponent<Image>().sprite = offSprite;
            on = false;
        }
        else
        {
            toggleImage.GetComponent<Image>().sprite = onSprite;
            on = true;
        }
    }
}
