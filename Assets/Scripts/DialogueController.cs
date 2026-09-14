using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TMP_Text dialogueText;

    public Transform rat;

    private float startingX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingX = rat.position.x;
        dialogueText.text = "Ahh..New York City at night.";
    }

    // Update is called once per frame
    void Update()
    {
        float distanceWalked = rat.position.x - startingX;

        if (distanceWalked >= 5f)
        {
            dialogueText.text = "It's definitely much quieter now than during the day.";
        }

        if (distanceWalked >= 15f)
        {
            dialogueText.text = "I think a nice walk around the city would be nice.";
        }
        
        if (distanceWalked >= 22f)
        {
            dialogueText.text = " ";
        }
    }
}
