using UnityEngine;

public class OneTimeButtonPopup : MonoBehaviour
{
    [SerializeField] private PageManager pageManager;
    [SerializeField] private GameObject firstPopup;
    [SerializeField] private GameObject alreadyUsedPopup;

    private bool hasBeenPressed = false;

    public void OnButtonPressed()
    {
        if (!hasBeenPressed)
        {
            hasBeenPressed = true;
            pageManager.ShowPopup(firstPopup);
        }
        else
        {
            pageManager.ShowPopup(alreadyUsedPopup);
        }
    }
}