using UnityEngine;

public class listgameobjectorig : MonoBehaviour
{
    public GameObject[] neonFlash;
    private int oldNumber = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject obj in neonFlash)
        {
                obj.SetActive(false);
        }
    }
    public void tvSwitch()
    {
        neonFlash[oldNumber].SetActive(false);
        int currentNumber = Random.Range(0, neonFlash.Length);
        neonFlash[currentNumber].SetActive(true);
        oldNumber = currentNumber;
    }
}
