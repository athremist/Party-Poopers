using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    private uint m_SpacesToMove;

    //Properties
    private GameObject CurrentPath
    {
        get;
        set;
    }
    private Transform CurrentTile
    {
        get;
        set;
    }
    private bool HasRolled
    {
        get;
        set;
    }

    void Start()
    {
        HasRolled = false;
        CurrentPath = GameObject.FindGameObjectWithTag("Path/Main");
    }

    void Update()
    {
        //Start overlay when the player starts their turn
        StartTurn();
        if (HasRolled == false)
        {
            StartActions();
        }
        Movement();
    }

    private void StartTurn()
    {
        HasRolled = false;
    }

    private void StartActions()
    {
        if(HasRolled == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))//Temp
            {
                RollDice();
            }
            //else if //use an item?
        }
        //Will exit function, once player has rolled.
    }

    private void Movement()
    {
        while(m_SpacesToMove > 0)
        {
            UpdatePath();

            //Getting the tile script in order to get the next tile to move to
            Tile tile = CurrentPath.GetComponent<Tile>();
            int tileCount = CurrentPath.transform.childCount;

            if (CurrentTile != null)
            {
                //Sets CurrentTile to the next tile in the path
                CurrentTile = tile.GetTileForIndex((CurrentTile.GetSiblingIndex() + 1) % tileCount);    
            }
            else
            {
                CurrentTile = tile.GetTileForIndex(0);
            }

            while(transform.position != CurrentTile.position)
            {
                transform.position = Vector3.Lerp(transform.position, CurrentTile.position, 10 * Time.deltaTime);
            }

            m_SpacesToMove--;
        }
    }

    // Determines how many spaces the player will move.
    private void RollDice()
    {
        m_SpacesToMove = 3;
        HasRolled = true;
    }

    private void UpdatePath()
    {
        
    }
}
