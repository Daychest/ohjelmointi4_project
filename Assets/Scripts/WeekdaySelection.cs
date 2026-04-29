using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeekdaySelection : MonoBehaviour
{
    public GameObject weekdayButtonToAffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWeekday(GameObject weekdayButton)
    {
        weekdayButtonToAffect.GetComponentInChildren<TMP_Text>().text = weekdayButton.GetComponentInChildren<TMP_Text>().text;
    }
}
