using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwappingPuzzle : Puzzle
{
    public GameObject swappingPuzzle;
    public GameObject emptyQuad;

    public Material[,] quadMaterials;
    private Material[,] correctQuadMaterials;
    public Material emptyQuadMaterial;

    private readonly int n = 3;
    private int numberOfQuads;
    private Transform swappingPuzzleTransform;

    // Start is called before the first frame update
    void Start()
    {
        quadMaterials = new Material[n, n];
        correctQuadMaterials = new Material[n, n];

        //amount of children
        numberOfQuads = swappingPuzzle.transform.childCount; 

        //used to take empty game object and find out how many children are a 
        //part of it, so the amount of quads in the game
        swappingPuzzleTransform = swappingPuzzle.transform;

        int randomQuadX = Random.Range(0, numberOfQuads) / n;
        int randomQuadY = Random.Range(0, numberOfQuads) / n;

        Debug.Log("The empty quad will be at " + randomQuadX + " " + randomQuadY);

        for (int i = 0; i < numberOfQuads / n; i++)
        {
            for (int j = 0; j < numberOfQuads / n; j++)
            {
                Debug.Log("Set material for " + i + " " + j);
                correctQuadMaterials[i, j] = swappingPuzzleTransform.GetChild(j).GetComponent<Renderer>().material;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        processInputs();
        checkIfWon();
    }

    private void processInputs()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            //Check if quad can go down
            //Make quad go down
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            //Check if quad can go up 
            //Make quad go up 
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            //Check if quad can go right 
            //Make quad go right 
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            //Check if quad can go left 
            //Make quad go left 
        }
    }

    private void swapMaterials(int i, int j)
    {
        Material temp;
    }

    public override bool checkIfWon()
    {
        return false;
    }

    public override string getPuzzleName()
    {
        return "Swapping Puzzle!";
    }
}
