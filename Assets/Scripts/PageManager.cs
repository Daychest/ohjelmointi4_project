using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour //class attached to a UI element
{
    [SerializeField] private GameObject startPage;
    [SerializeField] private GameObject bottomNavigationBar;

    private GameObject activePage = null;

    private static Vector3 phonePosition = new Vector3(0, 0, 0);
    private Vector3 activePageOffScreenPosition;
    private Vector3 bottomNavigationBarOffScreenPosition;

    private Stack<GameObject> popupStack = new Stack<GameObject>();
    private Stack<Vector3> popupPositionStack = new Stack<Vector3>();

    private void Start() //this method runs automatically when the application starts
    {
        SwapToPage(startPage);
        bottomNavigationBarOffScreenPosition = bottomNavigationBar.transform.position;
    }

    //disable buttons
    private void disableButtons(GameObject gameObject)
    {
        foreach (Button button in gameObject.GetComponentsInChildren<Button>())
        {
            button.enabled = false;
        }
    }

    //enable buttons again
    private void enableButtons(GameObject gameObject)
    {
        foreach (Button button in gameObject.GetComponentsInChildren<Button>())
        {
            button.enabled = true;
        }
    }

    //changes the active page
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

    //shows popup window
    public void ShowPopup(GameObject popup)
    {   
        //checks if popup stack is empty
        if (popupStack.Count == 0)
        {
            //if no popup is currently open:
            disableButtons(activePage);  //disable buttons on the active page
            disableButtons(bottomNavigationBar);  //disable buttons on the bottom navigation bar
        }
        else
        {   
            //if there is already a popup in the stack:
            disableButtons(popupStack.Peek());  //disable buttons on the currently visible popup
        }

        popupStack.Push(popup);
        popupPositionStack.Push(popup.transform.position);
        popup.transform.position = phonePosition;
    }

    //hides the top/only popup window
    public void HidePopup()
    {
        //checks if there are any popups open, exits if not
        if (popupStack.Count <= 0)
        {
            return;
        }

        //otherwise:
        //store the top popup from the stack and remove it from the stack
        GameObject popup = popupStack.Pop();

        //return popup back to its original position
        popup.transform.position = popupPositionStack.Pop();

        //check if there are still popup windows open:
        //if not:
        if (popupStack.Count == 0)
        {
            //enable the active page and navigation bar again
            enableButtons(activePage);
            enableButtons(bottomNavigationBar);
        }
        //if there is still a popup left in the stack:
        else
        {   
            //enable buttons on the new top popup
            enableButtons(popupStack.Peek());
        }
    }

    public void HideTwoPopups()
    {
        HidePopup();
        HidePopup();
    }

    public void ShowBottomNavigationBar()
    {
        bottomNavigationBar.transform.position = phonePosition;
    }

    public void HideBottomNavigationBar()
    {
        bottomNavigationBar.transform.position = bottomNavigationBarOffScreenPosition;
    }

    public void ResetInputField(GameObject inputField)
    {
        inputField.GetComponent<TMP_InputField>().text = "";
    }
}