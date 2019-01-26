using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystemController : MonoBehaviour
{
    private Queue<string> messages;

    public Text characterDialogText;

    // Start is called before the first frame update
    void Start()
    {
        messages = new Queue<string>();
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
            return;
        }

        string sentence = messages.Dequeue();

        //Slowly displays the message that it should be showing
        StartCoroutine(SlowlyDisplayMessage(sentence));
    }

    private IEnumerator SlowlyDisplayMessage(string message)
    {
        characterDialogText.text = "";
        foreach(char letter in message)
        {
            characterDialogText.text += letter;
            //Does 1 character on screen every 0.1 seconds
            yield return null;
        }
    }

    public bool isEmpty()
    {
        return messages.Count == 0;
    }
}
