using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialog : MonoBehaviour
{
    public Dialog dialog;
    public bool isTalking;

    private DialogSystemController controller;

    private void Start()
    {
        controller = FindObjectOfType<DialogSystemController>();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isTalking)
        {
            EnableDialog();
            isTalking = true;
        }
    }

    public void EnableDialog()
    {
        controller.StartDialog(dialog);
    }
}
