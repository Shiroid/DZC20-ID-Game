using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDiag : MonoBehaviour {

    public float moveForce = 1200f;
    public float maxHSpeed = 5f;
    public float maxVSpeed = 5f;
    public float fallForce = 1800f;
    public float maxFSpeed = 8f;
    public float friction = 1800f;
    public float stationaryThreshold = 1f;

    private bool falling;
    private bool isOnTrack;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        isOnTrack = false;
        falling = false;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (!isOnTrack && Globals.isMoveMode())
        {
            if (h * rb2d.velocity.x < maxHSpeed)
                rb2d.AddForce(Vector2.right * h * moveForce * Time.deltaTime);
            if (Mathf.Abs(h) < 0.1)
            {
                rb2d.AddForce(new Vector2(rb2d.velocity.x * -friction * Time.deltaTime, 0));
                if (Mathf.Abs(rb2d.velocity.x) < stationaryThreshold)
                    rb2d.velocity -= new Vector2(rb2d.velocity.x, 0);
            }

            if (falling)
            {
                if (-rb2d.velocity.y < maxFSpeed)
                    rb2d.AddForce(Vector2.down * fallForce * Time.deltaTime);
            }
            else
            {
                if (v * rb2d.velocity.y < maxVSpeed)
                    rb2d.AddForce(Vector2.up * v * moveForce * Time.deltaTime);
                if (Mathf.Abs(v) < 0.1)
                {
                    rb2d.AddForce(new Vector2(0, rb2d.velocity.y * -friction * Time.deltaTime));
                    if (Mathf.Abs(rb2d.velocity.y) < stationaryThreshold)
                        rb2d.velocity -= new Vector2(0, rb2d.velocity.y);
                }
            }
            if (Mathf.Abs(rb2d.velocity.x) > maxHSpeed)
                rb2d.velocity = new Vector2(maxHSpeed * Mathf.Sign(rb2d.velocity.x), rb2d.velocity.y);
            if (Mathf.Abs(rb2d.velocity.y) > maxVSpeed)
                rb2d.velocity = new Vector2(rb2d.velocity.x, maxVSpeed * Mathf.Sign(rb2d.velocity.y));
        }
    }

    public void setFall(bool doFall)
    {
        falling = doFall;
    }

    public void SetOnTrack(bool on)
    {
        isOnTrack = on;
    }
}
