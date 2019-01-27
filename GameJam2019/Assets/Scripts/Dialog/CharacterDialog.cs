using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialog : MonoBehaviour
{
    public Dialog dialog;
   
    public void EnableDialog()
    {
        FindObjectOfType<DialogSystemController>().StartDialog(dialog);
    }
}
