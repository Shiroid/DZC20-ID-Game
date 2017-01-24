using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactor : MonoBehaviour {

    protected GameObject interactingPlayer;
    protected int canInteract;

    public bool isAssertive = false;

    void Start()
    {
        canInteract = 0;
    }

    void Update()
    {
        if (canInteract > 0 && Input.GetKeyDown("space") && Globals.isMoveMode())
        {
            doInteraction();
        }
        doPassive();
        if (canInteract > 0)
            canInteract--;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactingPlayer = other.gameObject;
            canInteract = 2;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && isAssertive)
        {
            doInteraction();
        }
    }

    abstract public void doInteraction();
    abstract public void doPassive();
}
