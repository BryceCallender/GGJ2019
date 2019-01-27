using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightPuzzle : Puzzle
{
    public GameObject[] lights;

    int numLights = 5;
    public Color onColor;
    public Color offColor;

    // Start is called before the first frame update
    void Start()
    {
        ResetLights();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetLights()
    {
        Debug.Log("Resetting the lights");
        for (int i = 0; i < numLights; i++)
        {
            if (i == 1 || i == 3)
            {
                lights[i].GetComponent<Image>().color = onColor;
                lights[i].GetComponentInChildren<Text>().text = "400 F";
            }
            else
            {
                lights[i].GetComponent<Image>().color = offColor;
                lights[i].GetComponentInChildren<Text>().text = "350 F";
            }
        }
    }

    public void DetermineLightChange(int index)
    {
        Debug.Log("Hit button: " + index);

        switch(index)
        {
            case 0: 
                InvertPosition(0);
                InvertPosition(1);
            break;

            case 1: 
                InvertPosition(1);
            break;

            case 2:
                InvertPosition(1);
                InvertPosition(2);
                InvertPosition(3);
            break;

            case 3: 
                InvertPosition(2);
                InvertPosition(3);
                InvertPosition(4);
            break;

            case 4:
                InvertPosition(3);
                InvertPosition(4);
            break;
        }
    }

    private void InvertPosition(int index)
    {
        if(lights[index].GetComponent<Image>().color == onColor)
        {
            lights[index].GetComponent<Image>().color = offColor;
            lights[index].GetComponentInChildren<Text>().text = "350 F";
        }
        else 
        {
            lights[index].GetComponent<Image>().color = onColor;
            lights[index].GetComponentInChildren<Text>().text = "400 F";
        }
    }

    public override bool checkIfWon()
    {
        for(int i = 0; i < numLights; i++)
        {
            if(lights[i].GetComponent<Renderer>().material.color != onColor)
            {
                return false;
            }
        }
        return true;
    }

    public override string getPuzzleName()
    {
        return puzzleName;
    }
}
