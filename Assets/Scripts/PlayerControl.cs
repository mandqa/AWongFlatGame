using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //string playerName = "Amanda";
    //int playerScore = 10;
    //float playerHealth = 2.4f;
    //bool playerDead = false;
    //char playerID = 'f';

    public float playerSpeed;

	public bool canMove = true;
    private SpriteRenderer spriteRenderer;
	private Animator Ratanimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
		Ratanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (!canMove)
		{
			Ratanimator.SetBool("ratWalking",false);
			return;
		}

        Vector3 newPos = transform.position;
		bool ratWalking = false;
        /*
        if (Input.GetKey(KeyCode.W))
        {
            newPos.y = newPos.y + playerSpeed * Time.deltaTime;
            
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            newPos.y = newPos.y - playerSpeed * Time.deltaTime;
            
        }
        */
        if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = false;
            newPos.x = newPos.x + playerSpeed * Time.deltaTime;
			ratWalking = true;
            
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.flipX = true;
            newPos.x = newPos.x - playerSpeed * Time.deltaTime;
			ratWalking = true;
        }
        
        transform.position = newPos;
		Ratanimator.SetBool("ratWalking", ratWalking);
    }
}
