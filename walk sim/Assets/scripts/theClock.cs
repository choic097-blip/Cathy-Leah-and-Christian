using TMPro;
using UnityEngine;
using System.Collections;

public class theClock : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay;
    public int hours;
    public int minutes;
    public int multiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        multiplier = 1;
        hours = 8;
        StartCoroutine(IncrementRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            multiplier *= 2;
            if (multiplier > 16)
            {
                multiplier = 1;
            }
        } 
        timeDisplay.text = "speed x" + multiplier + "   " + hours.ToString("00") + ":" + minutes.ToString("00");
        if (minutes >= 60)
        {
            minutes = 0;
            hours++;
        }
        if (hours >= 24)
        {
            hours = 0;
        }
    }

    IEnumerator IncrementRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            minutes+= 1 * multiplier;
        }
    }
}
