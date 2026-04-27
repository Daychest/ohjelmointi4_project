using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class TrainingList : MonoBehaviour
{
    public GameObject trainingButtonPrefab;
    public List<GameObject> trainingButtons = new List<GameObject>();
    public GameObject addTrainingButton;

    public GameObject nameToCopy;
    public GameObject weekdayImageToCopy;
    public GameObject scrollHandleToAdjust;

    public Sprite noWeekdaySprite;

    private const float BUTTON_SPACING = 3;
    private const float SCROLL_AREA_HEIGHT = 14;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void alignTrainingButtons()
    {
        for (int i = 0; i < trainingButtons.Count; i++)
        {
            trainingButtons[i].transform.position = transform.position - new Vector3(0, i * BUTTON_SPACING, 0);
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

    public void addTraining()
    {
        GameObject newTrainingButton = Instantiate(trainingButtonPrefab, transform);

        var images = newTrainingButton.GetComponentsInChildren<Image>();
        images[images.Length - 1].sprite = weekdayImageToCopy.GetComponent<Image>().sprite;

        newTrainingButton.GetComponentInChildren<TMP_Text>().text = nameToCopy.GetComponent<TMP_InputField>().text;

        trainingButtons.Add(newTrainingButton);

        alignTrainingButtons();
        adjustScrollHandle();

        nameToCopy.GetComponent<TMP_InputField>().text = "";
        weekdayImageToCopy.GetComponent<Image>().sprite = noWeekdaySprite;
    }
}
