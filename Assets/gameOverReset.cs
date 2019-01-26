using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverReset : MonoBehaviour {

    public GameObject tank1;
    public GameObject tank2;

    public GameObject GOMenu;



	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            print("clicked");
            print(Input.mousePosition.y);
            if (Input.mousePosition.x >= 430 && Input.mousePosition.x <= 555 && Input.mousePosition.y >= 254 && Input.mousePosition.y <= 288)
            {
                //print("true");
                tank1.SetActive(true);
                tank2.SetActive(true);
                player1Script.Health = 100;
                tank1.transform.position = new Vector3(-6.55f, -2.69f, 0);
                player1Script.p1Fuel = 100;
                player2Script.Health = 100;
                tank2.transform.position = new Vector3(5.7f, -2.69f, 0);
                player2Script.p2Fuel = 100;
                GOMenu.SetActive(false);

            }
        }
    }
}
