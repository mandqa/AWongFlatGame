using UnityEngine;

public class PizzaInteraction : MonoBehaviour
{
    private Animator pizzaAnimator;
    private bool playerNearby = false;
    private bool pizzaeat = false;
    //public GameObject pizza;
    public PlayerControl player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pizzaAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNearby && !pizzaeat && Input.GetKeyDown(KeyCode.E))
        {
            pizzaeat = true;
            player.canMove = false;
            pizzaAnimator.Play("pizzaeat");
            Invoke("FinishPizza", 3f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }

    void FinishPizza()
    {
        player.canMove = true;
        //removes pizza after player eats
        Destroy(gameObject);
    }
}
