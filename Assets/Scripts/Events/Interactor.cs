using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactor : MonoBehaviour {

    protected GameObject interactingPlayer;
    protected int canInteract;

    public Interactor onSucceed;
    public Interactor onFail;
    public bool isAssertive = false;

    void Start()
    {
        canInteract = 0;
    }

    void Update()
    {
        if (canInteract > 0 && Input.GetKeyDown("space") && Globals.isMoveMode() && !isAssertive)
        {
            doInteraction(interactingPlayer);
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
        if (other.gameObject.CompareTag("Player") && isAssertive && Globals.assertionDelay == 0)
        {
            Globals.assertionDelay = 2;
            interactingPlayer = other.gameObject;
            doInteraction(interactingPlayer);
        }
    }

    abstract public void doInteraction(GameObject intPlayer);
    abstract public void doPassive();
}
