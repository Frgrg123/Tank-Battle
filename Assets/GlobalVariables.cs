using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour {

    public static int turn;
    public int turnCount = turn;

    public AudioSource button;

	// Use this for initialization
	void Start () {
        turn = 1;
	}
	
	// Update is called once per frame
	void Update () {
        turnCount = turn;
        if(Input.GetMouseButtonUp(0))
        {
            //print("clicked");
            //print(Input.mousePosition.x);
            if(Input.mousePosition.x >= 787 && Input.mousePosition.x <= 894 && Input.mousePosition.y >= 23 && Input.mousePosition.y <= 96)
            {
                //print("true");
                ChangeTurn();
                button.Play();
            }
            if(Input.mousePosition.x >= 650 && Input.mousePosition.x <= 730 && Input.mousePosition.y >= 29 && Input.mousePosition.y <= 68)
            {
                if(turn == 1)
                {
                    player1Script.spread = true;
                    player1Script.rollerShot = false;
                }
                else
                {
                    player2Script.spread = true;
                    player2Script.spread = false;
                }
            }
            if(Input.mousePosition.x >= 562 && Input.mousePosition.x <= 649 && Input.mousePosition.y >= 29 && Input.mousePosition.y <= 68)
            {
                if (turn == 1)
                {
                    player1Script.rollerShot = true;
                    player1Script.spread = false;
                }
                else
                {
                    player2Script.rollerShot = true;
                    player2Script.spread = false;
                }
            }
            if(Input.mousePosition.x >= 482 && Input.mousePosition.x <= 561 && Input.mousePosition.y >= 29 && Input.mousePosition.y <= 68)
            {
                if (turn == 1)
                {
                    player1Script.rollerShot = false;
                    player1Script.spread = false;
                }
                else
                {
                    player2Script.rollerShot = false;
                    player2Script.spread = false;
                }
            }
        }


    }

    public void ChangeTurn()
    {
        if (GlobalVariables.turn == 1)
        {
            GlobalVariables.turn = 2;
            player1Script.shootingSetup = 1;
            player1Script.p1Fuel = 100;
        }
        else if (GlobalVariables.turn == 2)
        {
            GlobalVariables.turn = 1;
            player2Script.shootingSetup = 1;
            player2Script.p2Fuel = 100;
        }
    }
}
