using TMPro;
using UnityEngine;
using System.Collections;

public class theClock : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay;
    public int hours;
    public int minutes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(IncrementRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        timeDisplay.text = hours  + ":" + minutes;
        if (minutes == 60)
        {
            minutes = 0;
            hours++;
        }
        if (hours == 24)
        {
            hours = 0;
        }
    }

    IEnumerator IncrementRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            minutes++;
        }
    }
}
