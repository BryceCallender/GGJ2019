using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwappingPuzzle : Puzzle
{
    public GameObject swappingPuzzle;
    public GameObject emptyQuad;

    public GameObject[,] quads;
    public Material[,] quadMaterials;
    private Material[,] correctQuadMaterials;
    public Material emptyQuadMaterial;

    private readonly int n = 3;
    private int numberOfQuads;
    private Transform swappingPuzzleTransform;

    [SerializeField] Vector2 quadLocation;

    // Start is called before the first frame update
    void Start()
    {
        quadMaterials = new Material[n, n];
        correctQuadMaterials = new Material[n, n];
        quads = new GameObject[n, n];

        //amount of children
        numberOfQuads = swappingPuzzle.transform.childCount; 

        //used to take empty game object and find out how many children are a 
        //part of it, so the amount of quads in the game
        swappingPuzzleTransform = swappingPuzzle.transform;

        for (int i = 0; i < numberOfQuads / n; i++)
        {
            for (int j = 0; j < numberOfQuads / n; j++)
            {
                Debug.Log("Set material for " + i + " " + j);
                correctQuadMaterials[i, j] = swappingPuzzleTransform.GetChild(j).GetComponent<Renderer>().material;
                quads[i,j] = swappingPuzzleTransform.GetChild(j).gameObject;
            }
        }

       //shuffleQuads();
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
            if(quadLocation.y > 0)
            {
                quadLocation.y -= 1;
            }
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

    //Swaps the empty quad with a new texture in the coordinates passed in
    private void swapMaterials(int i, int j)
    {
        Material temp = quadMaterials[i,j];

        quadMaterials[i, j] = emptyQuadMaterial;

        quadMaterials[(int)quadLocation.x, (int)quadLocation.y] = temp;

        quadLocation.x = i;
        quadLocation.y = j;
    }

    private void shuffleQuads()
    {
        for (int i = 0; i < numberOfQuads / n; i++)
        {
            for (int j = 0; j < numberOfQuads / n; j++)
            {
                int x = Random.Range(0, numberOfQuads) / n;
                int y = Random.Range(0, numberOfQuads) / n;

                //Debug.Log(x + " " + y);

                quadMaterials[i, j] = correctQuadMaterials[x,y];

                if (quadMaterials[i, j] == emptyQuadMaterial)
                {
                    Debug.Log("Empty Quad:" + i + " " + j);
                    quadLocation = new Vector2(i, j);
                }
            }
        }

        int randomQuadx = Random.Range(0, numberOfQuads) / n;
        int randomQuady = Random.Range(0, numberOfQuads) / n;

        quadMaterials[randomQuadx, randomQuady] = emptyQuadMaterial;
        quads[randomQuadx, randomQuady].GetComponent<Renderer>().material = emptyQuadMaterial;
    }

    public override bool checkIfWon()
    {
        for (int i = 0; i < numberOfQuads / n; i++)
        {
            for (int j = 0; j < numberOfQuads / n; j++)
            {
                if(quadMaterials[i,j] != correctQuadMaterials[i,j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public override string getPuzzleName()
    {
        return "Swapping Puzzle!";
    }
}
