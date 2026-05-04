using TMPro;
using UnityEngine;

public class QrTimer : MonoBehaviour
{
    private float timer = 0;
    private float timerMax = 31;
    public GameObject textToUpdate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = timerMax;
        }
        int timerInt = (int)timer;
        textToUpdate.GetComponent<TMP_Text>().text = "Voimassa: " + timerInt.ToString() + "s";

    }

    public void resetTimer()
    {
        timer = timerMax;
    }
}
