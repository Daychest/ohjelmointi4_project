using System.Collections.Generic;
using TMPro;
using UnityEngine;

public struct Training
{
    string name;
    string weekDay;
    List<Exercise> exercises;
}

public struct Exercise
{
    string name;
    string weekDay;
    int sets;
    int repeats;
}

public class TrainingManager : MonoBehaviour
{
    public List<Training> trainings = new List<Training>();

    public GameObject trainingButtonPrefab;
    public List<GameObject> trainingButtons = new List<GameObject>();
    public GameObject addTrainingButton;
    public Transform trainingList;

    public GameObject nameToCopy;
    public GameObject weekdayButtonToCopy;
    public GameObject scrollHandleToAdjust;

    private const float BUTTON_SPACING = 3;
    private const float SCROLL_AREA_HEIGHT = 14;

    public void addTraining()
    {
        GameObject newTrainingButton = Instantiate(trainingButtonPrefab, trainingList.transform);

        var texts = newTrainingButton.GetComponentsInChildren<TMP_Text>();
        texts[0].text = weekdayButtonToCopy.GetComponentInChildren<TMP_Text>().text;
        texts[1].text = nameToCopy.GetComponentInChildren<TMP_InputField>().text;

        trainingButtons.Add(newTrainingButton);

        alignTrainingButtons();
        adjustScrollHandle();

        nameToCopy.GetComponentInChildren<TMP_InputField>().text = "";
        weekdayButtonToCopy.GetComponentInChildren<TMP_Text>().text = "—";

    }

    private void alignTrainingButtons()
    {
        for (int i = 0; i < trainingButtons.Count; i++)
        {
            trainingButtons[i].transform.position = trainingList.position - new Vector3(0, i * BUTTON_SPACING, 0);
        }

        GameObject lastTrainingButton = trainingButtons[trainingButtons.Count - 1];
        addTrainingButton.transform.position = lastTrainingButton.transform.position - new Vector3(0, BUTTON_SPACING, 0);
    }

    private void adjustScrollHandle()
    {
        float contentHeight = (trainingButtons.Count + 1) * BUTTON_SPACING - 1;
        float maxPos = Mathf.Max(contentHeight - SCROLL_AREA_HEIGHT, 0);
        scrollHandleToAdjust.GetComponent<Scrolling>().maxPos = maxPos;
    }

    public void startEditTraining(GameObject trainingButton)
    {


    }


}
