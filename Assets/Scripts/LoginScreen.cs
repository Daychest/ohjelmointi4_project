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

    private bool validateInfo = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clearAllInputFields()
    {
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
        loginEmailErrorBox.SetActive(false);
        loginPasswordErrorBox.SetActive(false);

        bool success = true;
        if (!loginEmailInputField.GetComponentInChildren<TMP_InputField>().text.Contains("@"))
        {
            success = false;
            loginEmailErrorBox.SetActive(true);
        }
        if (loginPasswordInputField.GetComponentInChildren<TMP_InputField>().text != "1234")
        {
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
        registrationEmailErrorBox.SetActive(false);
        registrationPasswordErrorBox1.SetActive(false);
        registrationPasswordErrorBox2.SetActive(false);

        bool success = true;
        if (!registrationEmailInputField.GetComponentInChildren<TMP_InputField>().text.Contains("@"))
        {
            success = false;
            registrationEmailErrorBox.SetActive(true);
        }
        if (registrationPasswordInputField1.GetComponentInChildren<TMP_InputField>().text == "")
        {
            success = false;
            registrationPasswordErrorBox1.SetActive(true);
        }
        if (registrationPasswordInputField1.GetComponentInChildren<TMP_InputField>().text != 
            registrationPasswordInputField2.GetComponentInChildren<TMP_InputField>().text)
        {
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
