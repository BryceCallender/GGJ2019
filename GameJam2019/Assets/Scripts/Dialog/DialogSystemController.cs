using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystemController : MonoBehaviour
{
    private Queue<string> messages;

    public Text characterDialogText;
    public GameObject bubble;

    public GameObject swapPuzzle;
    public GameObject lightPuzzle;

    // Start is called before the first frame update
    void Start()
    {
        messages = new Queue<string>();
        bubble.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DisplayMessage();
        }
    }

    public void StartDialog(Dialog dialog)
    {
        messages.Clear();

        foreach(string message in dialog.messages)
        {
            messages.Enqueue(message);
        }

        DisplayMessage();
    }

    private void DisplayMessage()
    {
        if(isEmpty())
        {
            bubble.SetActive(false);
            return; 
        }

        string sentence = messages.Dequeue();
        Debug.Log(sentence);

        //Slowly displays the message that it should be showing
        bubble.SetActive(true);
        StartCoroutine(SlowlyDisplayMessage(sentence));
    }

    private IEnumerator SlowlyDisplayMessage(string message)
    {
        characterDialogText.text = "";
        foreach(char letter in message)
        {
            characterDialogText.text += letter;
            //Does 1 character on screen every frame
            yield return null;
        }
    }

    public bool isEmpty()
    {
        return messages.Count == 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(tag == "Bakery")
        {
            other.gameObject.GetComponent<CharacterDialog>().EnableDialog();
            lightPuzzle.SetActive(true);
        }
        else if(tag == "Ramen")
        {
            swapPuzzle.SetActive(true);
        }
    }
}
