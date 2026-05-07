using System.Collections.Generic;
using TMPro;
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

    //poistaa napit käytöstä
    private void disableButtons(GameObject gameObject)
    {
        foreach (Button button in gameObject.GetComponentsInChildren<Button>())
        {
            button.enabled = false;
        }
    }

    //ottaa napit takaisin käyttöön
    private void enableButtons(GameObject gameObject)
    {
        foreach (Button button in gameObject.GetComponentsInChildren<Button>())
        {
            button.enabled = true;
        }
    }

    //vaihtaa aktiivisen sivun
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

    //näyttää popup-ikkunan
    public void ShowPopup(GameObject popup)
    {   
        //onko popup stack tyhjä
        if (popupStack.Count == 0)
        {
            //jos ei ole vielä auki: 
            disableButtons(activePage);  //estetään aktiivisen sivun painikkeiden käyttö
            disableButtons(bottomNavigationBar);  //estetään alapalkin painikkeiden käyttö
        }
        else
        {   
            //jos stackissa on jo popup:
            disableButtons(popupStack.Peek());  //estetään tällä hetkellä näkyvän popupin painikkeet
        }

        popupStack.Push(popup);
        popupPositionStack.Push(popup.transform.position);
        popup.transform.position = phonePosition;
    }

    //piilottaa ylimmän/ainoan popup ikkunan
    public void HidePopup()
    {
        //onko pop uppeja auki, lopetetaan jos ei
        if (popupStack.Count <= 0)
        {
            return;
        }

        //muuten:
        //otetaan stacking ylin pop up talteen, ja poistetaan se sieltä
        GameObject popup = popupStack.Pop();

        //palautetaan popup takaisin sen alkuperäiseen sijaintiin
        popup.transform.position = popupPositionStack.Pop();

        //tarkistetaan jäikö vielä pop up ikkunoita:
        //jos ei:
        if (popupStack.Count == 0)
        {
            //aktivoidaan allaoleva sivu ja navigaatiopalkki takaisin käyttöön
            enableButtons(activePage);
            enableButtons(bottomNavigationBar);
        }
        //jos pinossa on vielä pop up jäljellä:
        else
        {   
            //aktivoidaan uuden ylimmän popupin painikkeet käyttön
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