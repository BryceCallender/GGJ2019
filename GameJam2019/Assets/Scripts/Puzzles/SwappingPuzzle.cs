using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

enum Direction
{
    NORTH,
    SOUTH,
    EAST,
    WEST
}

public class SwappingPuzzle : Puzzle
{
    public GameObject swappingPuzzle;
    public GameObject emptyQuad;

    public GameObject[,] quads; // just for changing the material
    public Material[,] quadMaterials;
    private Material[,] correctQuadMaterials;
    public Material emptyQuadMaterial;

    public string[] names;

    private readonly int n = 3;
    private int numberOfQuads;
    private Transform swappingPuzzleTransform;

    [SerializeField] Vector2 quadLocation;
    Direction direction;


    // Start is called before the first frame update
    void Start()
    {
        AudioSourceController.Instance.PlayPuzzle2Audio();

        quadMaterials = new Material[n, n];
        correctQuadMaterials = new Material[n, n];
        quads = new GameObject[n, n];
        names = new string[n * n];

        //amount of children
        numberOfQuads = swappingPuzzle.transform.childCount;

        int counter = 0;

        //used to take empty game object and find out how many children are a 
        //part of it, so the amount of quads in the game
        swappingPuzzleTransform = swappingPuzzle.transform;

        for (int i = 0; i < numberOfQuads / n; i++)
        {
            for (int j = 0; j < numberOfQuads / n; j++)
            {
                correctQuadMaterials[i,j] = swappingPuzzleTransform.GetChild(counter).GetComponent<Renderer>().material;
                quads[i,j] = swappingPuzzleTransform.GetChild(counter).gameObject;
                quadMaterials[i,j] = correctQuadMaterials[i, j];
                names[counter] = correctQuadMaterials[i, j].name;
                counter++;
            }
        }

        System.Array.Sort(names);
        PausePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        if(checkIfWon() && !isOver)
        {
            isOver = true;
            AudioSourceController.Instance.PlaySuccess();
            CameraSwapScript.Instance.SwitchCamera();
            ResumePlayer();
        }
    }

    private void ProcessInputs()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            //Check if quad can go down and do it if it can
            if(quadLocation.x < n - 1)
            {
                SwapMaterials((int)quadLocation.x, (int)quadLocation.y, Direction.NORTH);
            }

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            //Check if quad can go up
            if(quadLocation.x > 0)
            {
                SwapMaterials((int)quadLocation.x, (int)quadLocation.y, Direction.SOUTH);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            //Check if quad can go right 
            if (quadLocation.y < n - 1)
            {
                SwapMaterials((int)quadLocation.x, (int)quadLocation.y, Direction.EAST);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            //Check if quad can go left 
            if (quadLocation.y > 0)
            {
                SwapMaterials((int)quadLocation.x, (int)quadLocation.y, Direction.WEST);
            }
        }
    }

    //Swaps the empty quad with a new texture in the coordinates passed in
    private void SwapMaterials(int x, int y, Direction direction)
    {
        //Old location of the quad now has the old material of the last quad
        //in that location
        switch(direction)
        {
            case Direction.NORTH: x += 1;
                break;
            case Direction.SOUTH: x -= 1;
                break;
            case Direction.EAST: y += 1;
                break;
            case Direction.WEST: y -= 1;
                break;
        }

        Material temp = quadMaterials[x, y];

        //New location has the empty quad 
        quadMaterials[x, y] = emptyQuadMaterial;
        quads[x, y].GetComponent<Renderer>().material = emptyQuadMaterial;
  
        //Setting the empty quad 
        quadMaterials[(int)quadLocation.x,(int)quadLocation.y] = temp;
        quads[(int)quadLocation.x, (int)quadLocation.y].GetComponent<Renderer>().material = temp;

        quadLocation.x = x;
        quadLocation.y = y;
    }

    private void ShuffleQuads()
    {
        for (int i = 0; i < numberOfQuads / n; i++)
        {
            for (int j = 0; j < numberOfQuads / n; j++)
            {
                int x = Random.Range(0, numberOfQuads) / n;
                int y = Random.Range(0, numberOfQuads) / n;

                quadMaterials[i, j] = correctQuadMaterials[x,y];

                if (quadMaterials[i, j] == emptyQuadMaterial)
                {
                    //Debug.Log("Empty Quad:" + i + " " + j);
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
                if (!names[(i * n) + j].Contains(quadMaterials[i,j].name))
                {
                    return false;
                }
            }
        }
        gameObject.SetActive(false);
        ResumePlayer();
        return true;
    }

    public override string getPuzzleName()
    {
        return puzzleName;
    }

    public override void ResumePlayer()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<CameraController>().enabled = true;
    }

    public override void PausePlayer()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<CameraController>().enabled = false;
    }
}
