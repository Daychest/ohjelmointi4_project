using TMPro;
using UnityEngine;

public class QrTimer : MonoBehaviour
{
    private float timer = 0;
    private float timerMax = 31;
    public GameObject textToUpdate;

    // Update is called once per frame
    void Update()
    {
        //Reduce timer
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            //Reset timer when it falls below zero
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
