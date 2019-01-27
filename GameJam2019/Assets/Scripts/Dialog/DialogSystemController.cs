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

    private bool isTyping;
    private bool hasDoneTutorial;
    private bool hasSwappedCamera = false;

    private void Awake()
    {
        messages = new Queue<string>();
    }

    // Start is called before the first frame update
    void Start()
    {
        bubble.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            Debug.Log("Hit space");
            DisplayMessage();
        }
    }

    public void StartDialog(Dialog dialog)
    {
        messages.Clear();

        foreach(string message in dialog.messages)
        {
            if (!dialog.hasRead)
            {
                messages.Enqueue(message);
            }
        }
        dialog.hasRead = true;

        DisplayMessage();
    }

    private void DisplayMessage()
    {
        if(isEmpty())
        {
            bubble.SetActive(false);
            InteractionUnPauseMovementAndCamera();
            return; 
        }

        Debug.Log(messages.Count);
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
            isTyping = true;
            characterDialogText.text += letter;
            //Does 1 character on screen every frame
            yield return null;
        }
        isTyping = false;
    }

    public bool isEmpty()
    {
        return messages.Count == 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        DealWithDialog(other);
    }

    private void OnTriggerExit(Collider other)
    {
        this.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(!bubble.activeSelf)
        {
            if(other.CompareTag("Bakery"))
            {
                lightPuzzle.SetActive(true);
            }
            else if(other.CompareTag("Ramen") && !hasSwappedCamera)
            {
                CameraSwapScript.Instance.SwitchCamera();
                hasSwappedCamera = true;
                InteractionPauseMovementAndCamera();
            }
        }
    }

    private void DealWithDialog(Collider other)
    {
        this.enabled = true;

        if(hasDoneTutorial && other.CompareTag("Intro"))
        {
            return;
        }

        CharacterDialog dialog = other.GetComponent<CharacterDialog>();

        if (dialog)
        {
            if(other.tag == "Intro")
            {
                hasDoneTutorial = true;
            }
            InteractionPauseMovementAndCamera();
            dialog.EnableDialog();
        }
    }

    private void InteractionPauseMovementAndCamera()
    {
        this.GetComponent<PlayerMovement>().enabled = false;
        this.GetComponent<CameraController>().enabled = false;
    }

    private void InteractionUnPauseMovementAndCamera()
    {
        this.GetComponent<PlayerMovement>().enabled = true;
        this.GetComponent<CameraController>().enabled = true;
    }
}
