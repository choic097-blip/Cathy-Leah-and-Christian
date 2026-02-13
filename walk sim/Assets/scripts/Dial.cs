using UnityEngine;
using TMPro;
using System.Collections;
using Hertzole.GoldPlayer;

public class Dial : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public string[] morning;
    public string[] afternoon;
    public string[] evening;
    public string[] superLate;
    public float textSpeed;
    public theClock theetime;
    public GameObject playerController;
    public GameObject myDialBox;
    public GameObject blurFilter;
    private int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        blurFilter.SetActive(true);
        myDialBox.SetActive(true);
        int theTimer = theetime.hours;
        if (theTimer is >= 0 and <= 6){
            lines = superLate;
        }
        if (theTimer is >= 6 and <= 12){
            lines = morning;
        }
        if (theTimer is >= 12 and <= 18){
            lines = afternoon;
        }
        if (theTimer is >= 18 and <= 24){
            lines = evening;
        }
        textComponent.text = string.Empty;
        StartDialougue();
    }

    // Update is called once per frame
    void Update()
    {
        int theTimer = theetime.hours;
        if (theTimer is >= 0 and <= 6){
            lines = superLate;
            print("on late");
        }
        if (theTimer is >= 6 and <= 12){
            lines = morning;
            print("on morning");
        }
        if (theTimer is >= 12 and <= 18){
            lines = afternoon;
            print("on afternoon");
        }
        if (theTimer is >= 18 and <= 24){
            lines = evening;
            print("on evening");
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    void StartDialougue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            myDialBox.SetActive(false);
            blurFilter.SetActive(false);
            playerController.GetComponent<GoldPlayerController>().enabled = true;
            GetComponent<Dial>().enabled = false;
        }
    }
}
