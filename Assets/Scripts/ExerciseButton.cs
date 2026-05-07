using TMPro;
using UnityEngine;

public class ExerciseButton : MonoBehaviour
{
    public GameObject nameText;
    public GameObject repeatText;

    public int sets;
    public int repeats;

    public void setName(string name)
    {
        nameText.GetComponent<TMP_Text>().text = name;
    }
    public string getName()
    {
        return nameText.GetComponent<TMP_Text>().text;
    }
    public void setRepeats(int sets, int repeats)
    {
        string repeatString = sets + "x" + repeats;
        repeatText.GetComponent<TMP_Text>().text = repeatString;
        this.sets = sets;
        this.repeats = repeats;
    }
}
