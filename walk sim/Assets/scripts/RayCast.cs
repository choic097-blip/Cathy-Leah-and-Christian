using Hertzole.GoldPlayer;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    //THIS SCRIPT CONTAINS TWO EXAMPLES ON USING RAYCAST. THE FIRST IS RAYCAST FROM AN OBJECT. SECOND IS RAYCAST FROM MOUSE INPUT.
    
    public Camera playerCam;
    public GameObject playerController;
    public GameObject contrlmenu;
    public AudioSource audioSource;
    public GameObject highlights;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            MouseSelect();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            playerController.GetComponent<GoldPlayerController>().enabled = false;
            contrlmenu.SetActive(true);
        } 
        if (Input.GetKeyDown(KeyCode.P))
        {
            playerController.GetComponent<GoldPlayerController>().enabled = true;
            contrlmenu.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            highlights.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            highlights.SetActive(false);
        }
    }

    public void MouseSelect() 
    {
        Ray mouseRay = playerCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseDetect;
        if(Physics.Raycast(mouseRay, out mouseDetect)) 
        {
            if (mouseDetect.collider.CompareTag("Character"))
            {
                print("I have hit something.");
                playerController.GetComponent<GoldPlayerController>().enabled = false;
                mouseDetect.collider.GetComponent<Dial>().enabled = true;
            }

            if (mouseDetect.collider.CompareTag("Door"))
            {
                print("I'm dooring it.");
                Animator doorAnimator = mouseDetect.collider.GetComponent<Animator>();
                doorAnimator.SetTrigger("clicked");
            }

            if (mouseDetect.collider.CompareTag("Beachball"))
            {
                print("I'm balling it.");
                Animator ballAnimator = mouseDetect.collider.GetComponent<Animator>();
                ballAnimator.SetTrigger("clicked");
                AudioClip[] playingit = mouseDetect.collider.GetComponent<audioholdernm>().audioclip;
                audioSource.PlayOneShot(playingit[Random.Range(0, playingit.Length)]);
            }
            if (mouseDetect.collider.CompareTag("neontrigger"))
            {
                print("signing");
                GameObject[] allNeonTVs = GameObject.FindGameObjectsWithTag("neonsign");
                foreach (GameObject tv in allNeonTVs)
                {
                listgameobjectorig tvSwitch = tv.GetComponent<listgameobjectorig>();
                tvSwitch.tvSwitch();
                }
            }
        }

    }
 }
