using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginScreen : MonoBehaviour
{
    public List<GameObject> inputFieldsToClear = new List<GameObject>();

    public GameObject loginEmailInputField;
    public GameObject loginPasswordInputField;

    public GameObject loginEmailErrorBox;
    public GameObject loginPasswordErrorBox;

    public GameObject registrationEmailInputField;
    public GameObject registrationPasswordInputField1;
    public GameObject registrationPasswordInputField2;

    public GameObject registrationEmailErrorBox;
    public GameObject registrationPasswordErrorBox1;
    public GameObject registrationPasswordErrorBox2;

    public GameObject pageManager;
    public GameObject homePage;

    //Debug toggle for disabling validation
    private bool validateInfo = true;

    public void clearAllInputFields()
    {
        //This ensures that previously typed emails and passwords do not linger in the input fields
        foreach (GameObject inputField in inputFieldsToClear)
        {
            inputField.GetComponentInChildren<TMP_InputField>().text = "";
        }
        loginEmailErrorBox.SetActive(false);
        loginPasswordErrorBox.SetActive(false);
        registrationEmailErrorBox.SetActive(false);
        registrationPasswordErrorBox1.SetActive(false);
        registrationPasswordErrorBox2.SetActive(false);
    }

    public void confirmLogin()
    {
        //Check that all login info is correct
        loginEmailErrorBox.SetActive(false);
        loginPasswordErrorBox.SetActive(false);

        bool success = true;
        if (!loginEmailInputField.GetComponentInChildren<TMP_InputField>().text.Contains("@"))
        {
            //Do not allow emails that do not have @-character
            success = false;
            loginEmailErrorBox.SetActive(true);
        }
        if (loginPasswordInputField.GetComponentInChildren<TMP_InputField>().text != "1234")
        {
            //Ensure password was 1234
            success = false;
            loginPasswordErrorBox.SetActive(true);
        }
        if (success || !validateInfo)
        {
            pageManager.GetComponent<PageManager>().SwapToPage(homePage);
            pageManager.GetComponent<PageManager>().ShowBottomNavigationBar();
        }
    }

    public void confirmRegistration()
    {
        //Check that all registration info is correct
        registrationEmailErrorBox.SetActive(false);
        registrationPasswordErrorBox1.SetActive(false);
        registrationPasswordErrorBox2.SetActive(false);

        bool success = true;
        if (!registrationEmailInputField.GetComponentInChildren<TMP_InputField>().text.Contains("@"))
        {
            //Do not allow emails that do not have @-character
            success = false;
            registrationEmailErrorBox.SetActive(true);
        }
        if (registrationPasswordInputField1.GetComponentInChildren<TMP_InputField>().text == "")
        {
            //Do not allow empty password
            success = false;
            registrationPasswordErrorBox1.SetActive(true);
        }
        if (registrationPasswordInputField1.GetComponentInChildren<TMP_InputField>().text != 
            registrationPasswordInputField2.GetComponentInChildren<TMP_InputField>().text)
        {
            //Do not allow passwords that don't match
            success = false;
            registrationPasswordErrorBox2.SetActive(true);
        }
        if (success || !validateInfo)
        {
            pageManager.GetComponent<PageManager>().SwapToPage(homePage);
            pageManager.GetComponent<PageManager>().ShowBottomNavigationBar();
        }
    }


}
