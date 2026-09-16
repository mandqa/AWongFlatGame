using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TMP_Text dialogueText;

	public AudioClip squeak1;
	public AudioClip squeak2;
	public AudioClip taxihonk;
	public AudioClip pigeonfly;
	public AudioClip roachfly;
    
	public AudioSource audioSource;
	public AudioSource pigeonAudio;

    public Transform rat;
	public GameObject taxi;
	public GameObject pigeon;
	public GameObject cockroach;
	public GameObject pizza;

	private PlayerControl player;
    private float startingX;
	
	private Animator taxiAnimation;
	private Animator pigeonAnimation;
	private Animator cockroachAnimation;

	private PizzaInteraction pizzaInteraction;

	private bool pizzaStarted = false;
	private bool pizzaFinished = false;

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

		pizzaInteraction = pizza.GetComponent<PizzaInteraction>();

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
			PlaySqueak1();
			taxi.SetActive(true);
			player.canMove = false;
			taxiAnimation.Play("taxidrive");
			Invoke("PlayHonk",1.5f);
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
	
					pigeonAudio.Play();
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
		//cockroach
			if(pigeonFinished && !cockroachStarted)
			{
				if (distanceWalked >= 80f)
					{
						cockroachStarted = true;
						player.canMove = false;
						dialogueText.text = "AHHH! WHAT WAS THAT?!";
						PlaySqueak2();
						cockroach.SetActive(true);
						cockroachAnimation.Play("roachfly");
						Invoke("PlayRFly", 2f);
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
		//pizza
			if(cockroachFinished && !pizzaStarted)
			{
			if (distanceWalked >= 155f)
				{	
					pizzaStarted = true;
					player.canMove = false;
					dialogueText.text = "It's still warm";
					Invoke("PizzaReady", 2f);
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
			else if (distanceWalked >= 85f)
				{
					dialogueText.text = "";
				}
			}

			if(pizzaFinished)
			{
			if (distanceWalked >= 245f)
				{
					dialogueText.text = "..I think I love being home.";
					player.canMove = false;
				}
			else if (distanceWalked >= 235f)
				{
					dialogueText.text = "In the vast city of New York.."; 
				}
			else if (distanceWalked >= 225f)
				{
					dialogueText.text = "I must say theres nowhere quite like home.";
				}
			else if (distanceWalked >= 220f)
				{
					dialogueText.text = "But.. after a long night";
				}	
			else if (distanceWalked >= 212f)
				{
					dialogueText.text = "";
				}
			else if (distanceWalked >= 205f)
				{
					dialogueText.text = "yeah..especially those.";
				}
			else if (distanceWalked >= 200f)
				{
					dialogueText.text = "";
				}
			else if (distanceWalked >=190f)
				{
					dialogueText.text = "and sometimes there is a big flying cockroach, thinking its normal.";
				}
			else if (distanceWalked >=185f)
				{
					dialogueText.text = "..scary..";
				}
			else if (distanceWalked >=180f)
				{
					dialogueText.text = "its loud..";
				}
			else if (distanceWalked >=170f)
				{
					dialogueText.text = "I must say, New York gets so strange at night";
				}
			else if (distanceWalked >= 160f)
				{
					dialogueText.text = "nevermind, that made it the best night ever";
				}
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
			pigeonAudio.Stop();
			pigeonAnimation.Play("pigeonfly");
			Invoke("PlayPFly", 1f);
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
		
		//pizza funcions
		void PizzaReady()
		{
			dialogueText.text = "Press E to eat.";
			pizzaInteraction.StartPizza();
		}
		
		public void PizzaFinished()
		{
			pizzaFinished = true;
			dialogueText.text = "mmm...pizza";
			player.canMove = true;	
		}

		void PlaySqueak1()
        {
            audioSource.PlayOneShot(squeak1);
        }
		
		void PlaySqueak2()
        {
            audioSource.PlayOneShot(squeak2);
        }

		void PlayHonk()
		{
			audioSource.PlayOneShot(taxihonk);
		}
		
		void PlayPFly()
		{
			audioSource.PlayOneShot(pigeonfly);
		}
		
		void PlayRFly()
		{
			audioSource.PlayOneShot(roachfly);	
		}
}