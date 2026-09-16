using UnityEngine;

public class LightControl : MonoBehaviour
{
    private Animator lightAnimator;

    private AudioSource audioSource;

    public AudioClip lightOn;

    public AudioClip lightOff;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightAnimator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lightAnimator.SetBool("ratNear", true);
            audioSource.PlayOneShot(lightOn);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lightAnimator.SetBool("ratNear", false);
            audioSource.PlayOneShot(lightOff);
        }
    }
}
