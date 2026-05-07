using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public struct Training
{
    public string name;
    public string weekDay;
    public List<Exercise> exercises;
}

[System.Serializable]
public struct Exercise
{
    public string name;
    public int sets;
    public int repeats;
}

public class TrainingManager : MonoBehaviour
{
    public GameObject pageManager;
    public GameObject editTrainingPage;

    public List<Training> trainings = new List<Training>();

    public GameObject trainingButtonPrefab;
    public List<GameObject> trainingButtons = new List<GameObject>();
    public GameObject addTrainingButton;
    public Transform trainingList;

    public Transform exerciseList;
    public List<GameObject> exerciseButtons = new List<GameObject>();
    public GameObject exerciseButtonPrefab;
    public GameObject addExerciseButton;

    public GameObject nameToCopy;
    public GameObject weekdayButtonToCopy;
    public GameObject scrollHandleToAdjust;

    private GameObject activeTrainingButton;

    public GameObject exerciseAddNameInput;
    public GameObject exerciseAddSetsInput;
    public GameObject exerciseAddRepeatsInput;

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

        newTrainingButton.GetComponent<Button>().onClick.AddListener(() => pageManager.GetComponent<PageManager>().HideBottomNavigationBar());
        newTrainingButton.GetComponent<Button>().onClick.AddListener(() => pageManager.GetComponent<PageManager>().SwapToPage(editTrainingPage));
        newTrainingButton.GetComponent<Button>().onClick.AddListener(() => startEditTraining(newTrainingButton));
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
        activeTrainingButton = trainingButton;

        foreach (GameObject obj in exerciseButtons)
        {
            Destroy(obj);
        }
        exerciseButtons.Clear();

        foreach (Exercise exercise in trainingButton.GetComponent<TrainingButton>().exercises)
        {
            GameObject newExercise = Instantiate(exerciseButtonPrefab, exerciseList);
            exerciseButtons.Add(newExercise);
            newExercise.GetComponent<ExerciseButton>().setName(exercise.name);
            string repeatString = exercise.sets + "x" + exercise.repeats;
            newExercise.GetComponent<ExerciseButton>().setRepeats(repeatString);

        }

        alignExerciseButtons();

    }

    private void alignExerciseButtons()
    {
        for (int i = 0; i < exerciseButtons.Count; i++)
        {
            exerciseButtons[i].transform.position = exerciseList.position - new Vector3(0, i * BUTTON_SPACING, 0);
        }

        if (exerciseButtons.Count > 0)
        {
            GameObject lastExerciseButton = exerciseButtons[exerciseButtons.Count - 1];
            addExerciseButton.transform.position = lastExerciseButton.transform.position - new Vector3(0, BUTTON_SPACING, 0);
        }
    }

    public void addExercise()
    {
        Exercise newExercise;
        newExercise.name = exerciseAddNameInput.GetComponentInChildren<TMP_InputField>().text;
        newExercise.sets = stringToInt(exerciseAddSetsInput.GetComponentInChildren<TMP_InputField>().text);
        newExercise.repeats = stringToInt(exerciseAddRepeatsInput.GetComponentInChildren<TMP_InputField>().text);

        activeTrainingButton.GetComponent<TrainingButton>().exercises.Add(newExercise);

        startEditTraining(activeTrainingButton);
        clearExerciseAddPopup();
    }

    private int stringToInt(string str)
    {
        if (int.TryParse(str, out int value))
        {
            return value;
        }
        return 0;
    }

    private void clearExerciseAddPopup()
    {
        exerciseAddNameInput.GetComponentInChildren<TMP_InputField>().text = "";
        exerciseAddSetsInput.GetComponentInChildren<TMP_InputField>().text = "";
        exerciseAddRepeatsInput.GetComponentInChildren<TMP_InputField>().text = "";
    }


}
