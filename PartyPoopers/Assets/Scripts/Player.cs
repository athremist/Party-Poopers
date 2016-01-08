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
    }

    void Update()
    {
        //Start overlay when the player starts their turn
        StartTurn();

        StartActions();

        Movement();
    }

    private void StartTurn()
    {

    }

    private void StartActions()
    {
        while(HasRolled == false)
        {
            if (Input.GetKey(KeyCode.Space))//Temp
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
        }
    }

    private void UpdatePath()
    {
        
    }

    // Determines how many spaces the player will move.
    private void RollDice()
    {
        m_SpacesToMove = 3;
    }
}
