using UnityEngine;

public class RayCast : MonoBehaviour
{
    //THIS SCRIPT CONTAINS TWO EXAMPLES ON USING RAYCAST. THE FIRST IS RAYCAST FROM AN OBJECT. SECOND IS RAYCAST FROM MOUSE INPUT.
    
    public Camera playerCam;//For Raycast to work with mouse inputs, you need to reference the player camera. 
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
        //The 'MouseSelect' method creates a raycast that beams into the screen based on the position of your mouse.
        //While it's up to you, I personally keep mouse-based raycasts in their own standalone scripts. 

        //Unlike the previous raycast, 'ScreenPointToRay' is a built in function that automatically creates a ray based on 
        //mouse position within the game screen.
        Ray mouseRay = playerCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseDetect;

        //The rest plays out exactly the same. The only difference is that we use a layermask to tell 
        //the raycast to only detect gameobjects with your selected layermask. 

        if(Physics.Raycast(mouseRay, out mouseDetect)) 
        {
            if (mouseDetect.collider.CompareTag("Character"))
            print("I have hit something.");
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
