using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextTurnButton : MonoBehaviour {

    public Button nextTurn;


	// Use this for initialization
	void Start () {
        Button btn = nextTurn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        print("Hi");
        if(GlobalVariables.turn == 1)
        {
            GlobalVariables.turn = 2;
        }
        else if(GlobalVariables.turn == 2)
        {
            GlobalVariables.turn = 1;
            player1Script.p1Fuel = 100;
        }
    }
}
