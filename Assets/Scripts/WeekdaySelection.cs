using UnityEngine;
using UnityEngine.UI;

public class WeekdaySelection : MonoBehaviour
{
    public GameObject imageToChange;
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
        imageToChange.GetComponent<Image>().sprite = weekdayButton.GetComponentInChildren<Image>().sprite;
    }
}
