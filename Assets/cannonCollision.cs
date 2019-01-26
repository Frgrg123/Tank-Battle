using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonCollision : MonoBehaviour {

    public GameObject cannon;
    public GameObject parentTank;
    public GameObject otherTank;
    public Rigidbody2D rb;
    public GameObject gameOverMenu;

    public bool roller;
    public bool onFloor;
    public bool spread;
    public int timer = 0;

    public int damage;

	// Use this for initialization
	void Start () {
        //rb.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(onFloor && roller)
        {
            if(GlobalVariables.turn == 1)
            {
                transform.Rotate(Vector3.right * Time.deltaTime);
                transform.position += new Vector3(0.03f, 0);
            }
            else
            {
                transform.Rotate(Vector3.left * Time.deltaTime);
                transform.position += new Vector3(-0.03f, 0);
            }
            timer++;
            if(timer == 50)
            {
                timer = 0;
                rb.velocity = new Vector3(0, 0, 0);
                transform.position = parentTank.transform.position;
                onFloor = false;
                roller = false;
                cannon.SetActive(false);
            }
        }
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("collided");
        //print(collision.collider.name);
        if(collision.collider.name == "tank1base" && collision.collider.name != parentTank.name)
        {
            if(roller)
            {
                damage = 15;
            }
            else if(spread)
            {
                damage = 25;
            }
            else
            {
                damage = 34;
            }
            
            player1Script.Health -= damage;
            transform.position = parentTank.transform.position;
            rb.velocity = new Vector3(0, 0, 0);
            //rb.gravityScale = 0;
            cannon.SetActive(false);
            if(player1Script.Health <= 0)
            {
                GameOver();
            }
        }
        else if(collision.collider.name == "tank2base" && collision.collider.name != parentTank.name)
        {
            if (roller)
            {
                damage = 15;
            }
            else if (spread)
            {
                damage = 25;
            }
            else
            {
                damage = 34;
            }
            player2Script.Health -= damage;
            transform.position = parentTank.transform.position;
            rb.velocity = new Vector3(0, 0, 0);
            //rb.gravityScale = 0;
            cannon.SetActive(false);
            if (player2Script.Health <= 0)
            {
                GameOver();
            }
        }
        else if(collision.collider.name == "floor")
        {
            if(roller)
            {
                onFloor = true;
            }
            else
            {
                transform.position = parentTank.transform.position + new Vector3(0, 0.03f, 0);
                rb.velocity = new Vector3(0, 0, 0);
                //rb.gravityScale = 0;
                cannon.SetActive(false);
            }
            
        }

    }

    void GameOver()
    {
        gameOverMenu.SetActive(true);
        parentTank.SetActive(false);
        otherTank.SetActive(false);
    }

}
