using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour //luokka, joka liitetään ruudulla olevaan elementtiin.
{
    [SerializeField] private GameObject startPage;
    [SerializeField] private GameObject bottomNavigationBar;

    private GameObject activePage = null;

    private static Vector3 phonePosition = new Vector3(0, 0, 0);
    private Vector3 activePageOffScreenPosition;
    private Vector3 bottomNavigationBarOffScreenPosition;

    private Stack<GameObject> popupStack = new Stack<GameObject>();
    private Stack<Vector3> popupPositionStack = new Stack<Vector3>();

    private void Start() //tämä metodi ajetaan automaattisesti sovelluksen alussa
    {
        SwapToPage(startPage);
        bottomNavigationBarOffScreenPosition = bottomNavigationBar.transform.position;
    }

    private void disableButtons(GameObject gameObject)
    {
        foreach (Button button in gameObject.GetComponentsInChildren<Button>())
        {
            button.enabled = false;
        }
    }

    private void enableButtons(GameObject gameObject)
    {
        foreach (Button button in gameObject.GetComponentsInChildren<Button>())
        {
            button.enabled = true;
        }
    }

    public void SwapToPage(GameObject page)
    {
        if (activePage != null)
        {
            activePage.transform.position = activePageOffScreenPosition;
        }
        activePage = page;
        activePageOffScreenPosition = activePage.transform.position;
        activePage.transform.position = phonePosition;
    }

    public void ShowPopup(GameObject popup)
    {
        if (popupStack.Count == 0)
        {
            disableButtons(activePage);
            disableButtons(bottomNavigationBar);
        }
        else
        {
            disableButtons(popupStack.Peek());
        }

        popupStack.Push(popup);
        popupPositionStack.Push(popup.transform.position);
        popup.transform.position = phonePosition;
    }

    public void HidePopup()
    {
        if (popupStack.Count <= 0)
        {
            return;
        }

        GameObject popup = popupStack.Pop();
        popup.transform.position = popupPositionStack.Pop();

        if (popupStack.Count == 0)
        {
            enableButtons(activePage);
            enableButtons(bottomNavigationBar);
        }
        else
        {
            enableButtons(popupStack.Peek());
        }
    }

    public void ShowBottomNavigationBar()
    {
        bottomNavigationBar.transform.position = phonePosition;
    }

    public void HideBottomNavigationBar()
    {
        bottomNavigationBar.transform.position = bottomNavigationBarOffScreenPosition;
    }
}