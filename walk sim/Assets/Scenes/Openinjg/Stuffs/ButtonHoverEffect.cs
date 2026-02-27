using UnityEngine;
using UnityEngine.EventSystems; 
public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [Header("사운드 설정")]
    public AudioSource audioSource;
    public AudioClip hoverSound; 
    public AudioClip clickSound; 

    [Header("크기 설정")]
    public float hoverScaleMultiplier = 1.1f; 
    public float scaleSpeed = 10f; 

    private Vector3 originalScale;
    private Vector3 targetScale;

    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetScale = originalScale * hoverScaleMultiplier; 
        
        if (audioSource != null && hoverSound != null)
        {
            audioSource.PlayOneShot(hoverSound); 
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = originalScale; 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound); 
        }
    }
}