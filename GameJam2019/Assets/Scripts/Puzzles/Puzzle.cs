using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    //public Dialog puzzleInstructions; //Possibly
    public GameObject player;
    public string puzzleName;
    public bool isOver;
    public abstract string getPuzzleName();
    public abstract bool checkIfWon();
    public abstract void ResumePlayer();
    public abstract void PausePlayer();

}
