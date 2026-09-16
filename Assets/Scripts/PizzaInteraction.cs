using UnityEngine;

public class PizzaInteraction : MonoBehaviour
{
    public DialogueController dialogueController;
    private Animator pizzaAnimator;
    private bool playerNearby = false;
    private bool readyEat = false;
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
        if (playerNearby && readyEat && !pizzaeat && Input.GetKeyDown(KeyCode.E))
        {
            pizzaeat = true;
            pizzaAnimator.Play("pizzaeat");
            //dialogueController.PizzaStarted();
            Invoke("FinishPizza", 3f);
        }
    }

    public void StartPizza()
    {
        readyEat = true;
    }
    
    void FinishPizza()
    {
        dialogueController.PizzaFinished();
        //removes pizza after player eats
        Destroy(gameObject);
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
}
