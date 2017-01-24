using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Sets the interacting player on a linear track to the position of this object, when interacting with the collision box of this object.
public class TrackSetter : Interactor {
    
    private bool isMoving = false;

    public float speed = 5f;

    override
    public void doInteraction()
    {
        isMoving = true;
        interactingPlayer.GetComponent<PlayerControllerDiag>().SetOnTrack(true);
    }
    
    override
    public void doPassive()
    {

        if (isMoving && Globals.isMoveMode())
        {
            Vector3 diff = transform.position - interactingPlayer.transform.position;
            diff.z = 0;
            interactingPlayer.transform.Translate(diff.normalized * Mathf.Min(speed * Time.deltaTime, diff.magnitude));
            if (diff.magnitude == 0)
            {
                isMoving = false;
                interactingPlayer.GetComponent<PlayerControllerDiag>().SetOnTrack(false);
            }
        }
    }
}
