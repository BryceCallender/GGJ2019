using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    public Dialog puzzleInstructions; //Possibly
    public string puzzleName;
    public abstract string getPuzzleName();
    public abstract bool checkIfWon();
}
