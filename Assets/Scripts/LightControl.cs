using UnityEngine;

public class LightControl : MonoBehaviour
{
    private Animator lightAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightAnimator = GetComponentInChildren<Animator>();
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
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lightAnimator.SetBool("ratNear", false);
        }
    }
}
