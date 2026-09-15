using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TMP_Text dialogueText;

    public Transform rat;
	public GameObject taxi;
	public GameObject pigeon;
	public GameObject cockroach;

	private PlayerControl player;
    private float startingX;
	
	private Animator taxiAnimation;
	private Animator pigeonAnimation;
	private Animator cockroachAnimation;

	private bool taxiStarted = false;
	private bool taxiFinished = false;

	private bool pigeonStarted = false;
	private bool pigeonFinished = false;
	
	private bool cockroachStarted = false;
	private bool cockroachFinished = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingX = rat.position.x;
		player = rat.GetComponent<PlayerControl>();

		taxiAnimation = taxi.GetComponent<Animator>();
		pigeonAnimation = pigeon.GetComponent<Animator>();
		cockroachAnimation = cockroach.GetComponent<Animator>();
		//taxi starts hidden
		taxi.SetActive(false);
		//piegon already visible
		pigeon.SetActive(true);
		//cockroach will be hidden
		cockroach.SetActive(false);
        dialogueText.text = "Ahh..New York City at night.";
    }

    // Update is called once per frame
    void Update()
    {
        float distanceWalked = rat.position.x - startingX;

       if (!taxiStarted)
        {
			if(distanceWalked >= 30f)
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
	
	//pigeon
		if (taxiFinished && !pigeonStarted)
		{
			if (distanceWalked >= 54f)
				{
					pigeonStarted = true;
					player.canMove = false;
					dialogueText.text = "Oh, Hello!";
					Invoke("PigeonDialogue2",2f);
				}
			else if (distanceWalked >= 40f)
				{
					dialogueText.text = "I really need to stop being scared of things so easily.";
				}
			else if(distanceWalked >= 35f) 
				{
					dialogueText.text = "Well...then..";
				}
		}
			if(pigeonFinished && !cockroachStarted)
			{
				if (distanceWalked >= 80f)
					{
						cockroachStarted = true;
						player.canMove = false;
						dialogueText.text = "AHHH! WHAT WAS THAT?!";
						cockroach.SetActive(true);
						cockroachAnimation.Play("roachfly");
						Invoke("CockroachDialogue2",3f);
					}
				else if(distanceWalked >= 65f)
					{
						dialogueText.text = " ";
					}
				else if (distanceWalked >= 60f)
					{
						dialogueText.text = "...Rude";	
					}
			}
			if(cockroachFinished)
			{
			if (distanceWalked >= 155f)
				{	
					dialogueText.text = "It's still warm";
					
				}
			else if (distanceWalked >= 150f)
				{
					dialogueText.text = "";
				}
			else if (distanceWalked >= 145f)
				{
					dialogueText.text = "Oh my god.";
				}
			else if (distanceWalked >= 130f)
				{
					dialogueText.text = "Is that what I think it is..";
				}
			else if (distanceWalked >= 122f)
				{
				dialogueText.text = "*sniffs*";
				}
			else if (distanceWalked >= 115f)
				{
					dialogueText.text = "Wait a minute...";
				}
			else if(distanceWalked >= 105f)
				{
					dialogueText.text = "";
				}
			else if (distanceWalked >= 100f)
				{
					dialogueText.text = "I'm just gonna go";
				}
			else if (distanceWalked >=90f)
				{
					dialogueText.text = "You know what?";
				}
			}
			else if (distanceWalked >= 85f)
				{
					dialogueText.text = "";
				}
		}
		

		//taxi functions
		void FinishTaxiEvent()
		{
			taxi.SetActive(false);
			dialogueText.text = "..Taxi";
			Invoke("PlayerMove", 6f);
		}

		void PlayerMove()
		{
			player.canMove = true;
			taxiFinished = true;
		}

		//pigeon functions
		void PigeonDialogue2(){
			dialogueText.text = "*pigeon stares*";
			Invoke("PigeonDialogue3", 5f);
		}

		void PigeonDialogue3(){
			dialogueText.text = "...";
			Invoke("PigeonDialogue4", 4f);
		}

		void PigeonDialogue4(){
			dialogueText.text = "Are you gonna move?";
			Invoke("PigeonFlyAway", 6f);
		}
		
		void PigeonFlyAway(){
			dialogueText.text = "";
			pigeonAnimation.Play("pigeonfly");
			Invoke("PigeonFinish",6f);
		}
		
		void PigeonFinish(){
			pigeon.SetActive(false);
			pigeonFinished = true;
			dialogueText.text = "...Rude";
			Invoke("PlayerMovePigeon", 3f);
		}

		void PlayerMovePigeon(){
		player.canMove = true;
		}
		
		//cockroach functions
		void CockroachDialogue2(){
		dialogueText.text = "*looks around*";
		Invoke("CockroachDialogue3", 6f);
		}
		
		void CockroachDialogue3(){
		dialogueText.text = "Did I just witness a cockroach.";
		Invoke("CockroachDialogue4", 7f);
		}
	
		void CockroachDialogue4(){
		dialogueText.text = " ";
		Invoke("CockroachDialogue5", 3f);
		}

		void CockroachDialogue5(){
		dialogueText.text = "AND WHY WAS IT FLYING?!";
		Invoke("CockroachFinish", 6f);
		}
		
		void CockroachFinish(){
		cockroach.SetActive(false);
		cockroachFinished = true;
		dialogueText.text = "I cant do this no more.";
		Invoke("PlayerMoveRoach", 5f);
		}
		
		void PlayerMoveRoach () {
		player.canMove = true;	
		}
}
