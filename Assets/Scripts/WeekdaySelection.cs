using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeekdaySelection : MonoBehaviour
{
    //The weekday button that the selection is targeting
    public GameObject weekdayButtonToAffect;

    public void SetWeekday(GameObject weekdayButton)
    {
        weekdayButtonToAffect.GetComponentInChildren<TMP_Text>().text = weekdayButton.GetComponentInChildren<TMP_Text>().text;
    }
}
