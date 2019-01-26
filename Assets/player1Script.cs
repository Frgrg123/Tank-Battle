using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player1Script : MonoBehaviour {

    public TextMesh hpDisplay;
    public TextMesh Power;
    public AudioSource move;
    public AudioSource fire;

    public GameObject cannon;
    public GameObject leftBall;
    public GameObject rightBall;


    public static int p1Fuel = 100;
    public static int Health = 100;

    public float vertical = 0;
    public float horizontal= 0;

    public static int shootingSetup = 1;

    private cannonCollision cannonScript;
    public static bool spread;
    public static bool rollerShot;


	// Use this for initialization
	void Start () {
        cannonScript = cannon.GetComponent<cannonCollision>();
    }
	
	// Update is called once per frame
	void Update () {
		if(GlobalVariables.turn == 1)
        {
            movementDetect();
            shooting();
            Power.text = horizontal.ToString() + " x " + vertical.ToString();
        }
        else
        {
            Power.text = "";
        }
        hpDisplay.text = Health.ToString();

    }

    void movementDetect()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(p1Fuel > 0)
            {
                if(!move.isPlaying)
                {
                    move.Play();
                }
                transform.position += new Vector3(0.03f, 0, 0);
                p1Fuel--;
            }
            else
            {
                if (move.isPlaying)
                {
                    move.Stop();
                }
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (p1Fuel > 0)
            {
                if (!move.isPlaying)
                {
                    move.Play();
                }
                transform.position += new Vector3(-0.03f, 0, 0);
                p1Fuel--;
            }
            else
            {
                if (move.isPlaying)
                {
                    move.Stop();
                }
            }
        }
        else
        {
            if (move.isPlaying)
            {
                move.Stop();
            }
        }
    }

    void shooting()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            shootingSetup++;
        }
        if (shootingSetup == 1)
        {
            if (Input.GetKey(KeyCode.UpArrow) && horizontal < 100)
            {
                horizontal++;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && horizontal > -100)
            {
                horizontal--;
            }
        }
        else if (shootingSetup == 2)
        {
            if (Input.GetKey(KeyCode.UpArrow) && vertical < 100)
            {
                vertical++;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && vertical > -100)
            {
                vertical--;
            }
        }
        else if (shootingSetup == 3)
        {
            fire.Play();
            cannon.SetActive(true);
            cannon.GetComponent<Rigidbody2D>().velocity = new Vector3(horizontal/10, vertical/10, 0);
            //cannonScript = cannon.GetComponent<cannonCollision>();
            cannonScript.roller = rollerShot;
            if(spread)
            {
                leftBall.SetActive(true);
                leftBall.GetComponent<Rigidbody2D>().velocity = new Vector3((horizontal/10) - 1.5f, (vertical/10) - 1.5f, 0);
                rightBall.SetActive(true);
                rightBall.GetComponent<Rigidbody2D>().velocity = new Vector3((horizontal / 10) + 1.5f, (vertical / 10) + 1.5f, 0);
                cannonScript.spread = spread;
                leftBall.GetComponent<cannonCollision>().spread = spread;
                rightBall.GetComponent<cannonCollision>().spread = spread;
            }
            //cannon.GetComponent<Rigidbody2D>().gravityScale = 1;
            shootingSetup = 4;
            player2Script.shootingSetup = 1;
            player2Script.p2Fuel = 100;
        }
    }
}
