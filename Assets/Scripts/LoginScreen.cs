using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginScreen : MonoBehaviour
{
    public List<GameObject> inputFieldsToClear = new List<GameObject>();

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
    }
}
