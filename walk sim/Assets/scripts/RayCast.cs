using Hertzole.GoldPlayer;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    //THIS SCRIPT CONTAINS TWO EXAMPLES ON USING RAYCAST. THE FIRST IS RAYCAST FROM AN OBJECT. SECOND IS RAYCAST FROM MOUSE INPUT.
    
    public Camera playerCam;
    public GameObject playerController;
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
                //playerController.GetComponent<GoldPlayerController>().enabled = false;
                //mouseDetect.collider.GetComponent<Dial>().enabled = true;
                mouseDetect.collider.GetComponent<Animator>();
                SetBool("clicked", true);
            }
            
        }

            
        // if(Physics.Raycast(mouseRay, out mouseDetect)) 
        //     {
        //         //display name
        //         if(mouseDetect.collider.CompareTag("Character"))
        //         print("character");
        //     }
                
        //     }
        //     else
        //     {
        //         print("none");
        //     }
        // if(Physics.Raycast(mouseRay, out mouseDetect, 2f)) 
        //     {
        //         //InformationText it = mouseDetect.collider.GetComponent<InformationText>();
        //     //if(it != null){
        //         //information.text = it.information;
        //     }
        //     else
        //     {
        //     }
        }
            
    }
