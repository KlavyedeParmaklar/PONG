 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControls : MonoBehaviour {

    private Rigidbody2D rb;

    //public GameObject ball;
    public GameObject player1;
    public GameObject player2;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();

        //ball = GameObject.Find("Ball");
        player1 = GameObject.Find("Player");
        player2 = GameObject.Find("Player2");

        StartCoroutine(Pause());
	}
	
	// Update is called once per frame
	void Update () {
        //Refactoring
        if(Mathf.Abs(this.transform.position.x) >= 10f)
        {
            this.transform.position = new Vector3(0f, 0f, 0f);
            StartCoroutine(Pause());
        }

        /*if (this.transform.position.x >= 10f)
        {
            this.transform.position = new Vector3(0f, 0f,0f);
        }
        else if(this.transform.position.x <= -10f)
        {
            this.transform.position = new Vector3(0f, 0f, 0f);
        }*/
	}

    IEnumerator Pause()
    {
        int directionX = Random.Range(-1, 2);
        int directionY = Random.Range(-1, 2);

        if(directionX == 0)
        {
            directionX = 1;
        }

        rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(1);
        rb.velocity = new Vector2(9f * directionX, 9f * directionY);
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        //Player
        if (hit.gameObject.name == "Player")
        {
            if(player1.GetComponent<Rigidbody2D>().velocity.y > 0.5f)
            {
                rb.velocity = new Vector2(9f, 9f);
            }
            else if(player1.GetComponent<Rigidbody2D>().velocity.y < -0.5f)
            {
                rb.velocity = new Vector2(9f, -9f);
            }
            else
            {
                rb.velocity = new Vector2(9f, 0);
            }
        }

        //Player2
        if(hit.gameObject.name == "Player2")
        {
            if(player2.GetComponent<Rigidbody2D>().velocity.y > 0.5f)
            {
                rb.velocity = new Vector2(-9f, 9f);
            }
            else if(player2.GetComponent<Rigidbody2D>().velocity.y < -0.5f)
            {
                rb.velocity = new Vector2(-9f, -9f);
            }
            else
            {
                rb.velocity = new Vector2(-9f, 0f);
            }
        }

        /*if(hit.gameObject.tag == "player")
        {
            print("HOPPPP"); 
        }*/
    }
}
