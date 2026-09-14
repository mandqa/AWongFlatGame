using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);

    //time it takes for cam to reach the target
    private float smoothTime = 0.25f;

    private Vector3 velocity = new Vector3(0f, 0f, 0f);

    //visible in inspector but safe from other scripts from colliding
    //the target the camera follows
    [SerializeField] private Transform target;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //makes cam go towards rat position then stay in center
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        // to change a vector towards its desired goal - smoothdamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
