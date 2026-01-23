using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public AudioSource myaudiosource;
    public AudioClip myaudioclip;
    void OnCollisionEnter(Collision collision)
    {
        myaudiosource.PlayOneShot(myaudioclip);
        //this is what it does to help you play the assigned audio to the object.
    }
}
