using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]
public class Eating : MonoBehaviour
{
    public AudioClip clickSound;
    public float reappearDelay = 20f;

    private AudioSource audioSource;
    private Collider objectCollider;
    private Renderer[] objectRenderers;
    private bool isProcessing = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        objectCollider = GetComponent<Collider>();
        objectRenderers = GetComponentsInChildren<Renderer>();
    }

    void OnMouseDown()
    {
        if (!isProcessing)
            StartCoroutine(HandleClickSequence());
    }

    private IEnumerator HandleClickSequence()
    {
        isProcessing = true;

        if (clickSound != null)
            audioSource.PlayOneShot(clickSound);

        objectCollider.enabled = false;

        foreach (Renderer r in objectRenderers)
            r.enabled = false;

        yield return new WaitForSeconds(reappearDelay);

        objectCollider.enabled = true;

        foreach (Renderer r in objectRenderers)
            r.enabled = true;

        isProcessing = false;
    }
}