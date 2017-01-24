using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour {
    public float moveSpeed;

    private Rigidbody2D rb2d;

    private bool isWalking;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    private float walkTime;
    private float waitTime;
    private float walkCounter;
    private float waitCounter;

    private float randomX;
    private float randomY;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        maxX += transform.position.x;
        maxY += transform.position.y;
        minX += transform.position.x;
        minY += transform.position.y;
        ChooseDirection();
	}
	
	// Update is called once per frame
	void Update () {
        if (Globals.isMoveMode())
        {
            if (isWalking)
            {
                walkCounter -= Time.deltaTime;

                if (walkCounter < 0)
                {
                    isWalking = false;
                    waitCounter = waitTime;
                }

                if (transform.position.x > maxX || transform.position.x < minX)
                {
                    if (transform.position.x > maxX) transform.Translate(new Vector3(maxX - transform.position.x, 0, 0));
                    if (transform.position.x < minX) transform.Translate(new Vector3(minX - transform.position.x, 0, 0));
                    randomX = -randomX;
                }
                if (transform.position.y > maxY || transform.position.y < minY)
                {
                    if (transform.position.y > maxY) transform.Translate(new Vector3(0, maxY - transform.position.y, 0));
                    if (transform.position.y < minY) transform.Translate(new Vector3(0, minY - transform.position.y, 0));
                    randomY = -randomY;
                }
                rb2d.velocity = new Vector2(randomX * moveSpeed, randomY * moveSpeed);
            }
            else
            {
                waitCounter -= Time.deltaTime;

                rb2d.velocity = new Vector2(0, 0);

                if (waitCounter < 0)
                {
                    ChooseDirection();
                }

            }
        }
    }

    public void ChooseDirection() {
        randomX = Random.Range(-1.0f, 1.0f);
        randomY = Random.Range(-1.0f, 1.0f);
        waitTime = Random.Range(0f, 2.0f);
        walkTime = Random.Range(1.0f, 3.0f);

        waitCounter = waitTime;
        walkCounter = walkTime;

        isWalking = true;
        walkCounter = walkTime;
    }
}
