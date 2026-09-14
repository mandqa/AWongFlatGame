using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TMP_Text dialogueText;

    public Transform rat;
	public GameObject taxi;
	private PlayerControl  player;
    private float startingX;
	private bool taxiStarted = false;
	private bool taxiFinished = false;
	private Animator taxiAnimation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingX = rat.position.x;
		player = rat.GetComponent<PlayerControl>();
		taxiAnimation = taxi.GetComponent<Animator>();
        dialogueText.text = "Ahh..New York City at night.";
    }

    // Update is called once per frame
    void Update()
    {
        float distanceWalked = rat.position.x - startingX;

       if (!taxiStarted)
        {
			if(distanceWalked >= 26f)
			{	
			taxiStarted = true;
            dialogueText.text = "AH!";
			taxi.SetActive(true);
			player.canMove = false;
			taxiAnimation.Play("taxidrive");
			Invoke("FinishTaxiEvent",3f);
			}

        else if (distanceWalked >= 22f)
        {
            dialogueText.text = "";
        }
        
        else if (distanceWalked >= 15f)
        {
            dialogueText.text = "I think a nice walk around the city would be nice.";
        }
        
        else if (distanceWalked >= 5f)
        {
            dialogueText.text = "It's definitely much quieter now than during the day.";
        }
       
  
	}

		if (taxiFinished){
	
			if (distanceWalked >= 35f)
				{
					dialogueText.text = "I really need to stop being scared of things so easily.";
				}
			else if(distanceWalked >= 30f) 
				{
					dialogueText.text = "Well.then..";
				}
	}
}
		void FinishTaxiEvent()
		{
			taxi.SetActive(false);
			dialogueText.text = "..Taxi";
			Invoke("PlayerMove", 3f);
		}

		void PlayerMove()
		{
			player.canMove = true;
			taxiFinished = true;
		}
}
