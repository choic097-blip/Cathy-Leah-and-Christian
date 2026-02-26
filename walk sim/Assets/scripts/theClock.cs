using TMPro;
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class theClock : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay;
    public int hours;
    public int minutes;
    public int multiplier;
    [SerializeField] private Texture2D skyboxNight;
    [SerializeField] private Texture2D skyboxSunrise;
    [SerializeField] private Texture2D skyboxDay;
    [SerializeField] private Texture2D skyboxSunset;
    [SerializeField] private Gradient graddientNightToSunrise;
    [SerializeField] private Gradient graddientSunriseToDay;
    [SerializeField] private Gradient graddientDayToSunset;
    [SerializeField] private Gradient graddientSunsetToNight;
    [SerializeField] private Light globalLight;

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
        if (Input.GetKeyDown(KeyCode.F))
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
            //OnHoursChange();
            if (hours >= 24)
            {
                hours = 0;
            }
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

    // private void OnMinutesChange(int hours)
    // {
    //     globalLight.transform.Rotate(Vector3.up, (1f / (1440f / 4f)) * 360f, Space.World);
    // }
 
    // private void OnHoursChange()
    // {
    //     if (hours == 6)
    //     {
    //         StartCoroutine(LerpSkybox(skyboxNight, skyboxSunrise, 10f));
    //         StartCoroutine(LerpLight(graddientNightToSunrise, 10f));
    //         print("lerping");
    //     }
    //     else if (hours == 8)
    //     {
    //         StartCoroutine(LerpSkybox(skyboxSunrise, skyboxDay, 10f));
    //         StartCoroutine(LerpLight(graddientSunriseToDay, 10f));
    //         print("lerping");
    //     }
    //     else if (hours == 18)
    //     {
    //         StartCoroutine(LerpSkybox(skyboxDay, skyboxSunset, 10f));
    //         StartCoroutine(LerpLight(graddientDayToSunset, 10f));
    //         print("lerping");
    //     }
    //     else if (hours == 22)
    //     {
    //         StartCoroutine(LerpSkybox(skyboxSunset, skyboxNight, 10f));
    //         StartCoroutine(LerpLight(graddientSunsetToNight, 10f));
    //         print("lerping");
    //     }
    // }
 
    // private IEnumerator LerpSkybox(Texture2D a, Texture2D b, float minutes)
    // {
    //     RenderSettings.skybox.SetTexture("_Texture1", a);
    //     RenderSettings.skybox.SetTexture("_Texture2", b);
    //     RenderSettings.skybox.SetFloat("_Blend", 0);
    //     for (float i = 0; i < minutes; i += Time.deltaTime)
    //     {
    //         RenderSettings.skybox.SetFloat("_Blend", i / minutes);
    //         yield return null;
    //     }
    //     RenderSettings.skybox.SetTexture("_Texture1", b);
    // }
 
    // private IEnumerator LerpLight(Gradient lightGradient, float minutes)
    // {
    //     for (float i = 0; i < minutes; i += Time.deltaTime)
    //     {
    //         globalLight.color = lightGradient.Evaluate(i / minutes);
    //         RenderSettings.fogColor = globalLight.color;
    //         yield return null;
    //     }
    // }
}
