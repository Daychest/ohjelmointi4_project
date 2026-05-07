using TMPro;
using UnityEngine;

public class ExerciseButton : MonoBehaviour
{
    public GameObject nameText;
    public GameObject repeatText;

    public void setName(string name)
    {
        nameText.GetComponent<TMP_Text>().text = name;
    }
    public void setRepeats(string repeats)
    {
        repeatText.GetComponent<TMP_Text>().text = repeats;
    }
}
