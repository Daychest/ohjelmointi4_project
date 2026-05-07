using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TrainingButton : MonoBehaviour
{
    public List<Exercise> exercises = new List<Exercise>();

    public GameObject nameObject;
    public GameObject weekDayObject;

    public string getName()
    {
        return nameObject.GetComponentInChildren<TMP_Text>().text;
    }
    public void setName(string name)
    {
        nameObject.GetComponentInChildren<TMP_Text>().text = name;
    }
    public string getWeekday()
    {
        return weekDayObject.GetComponentInChildren<TMP_Text>().text;
    }
}
