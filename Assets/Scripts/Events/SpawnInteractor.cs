using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInteractor : MonoBehaviour
{
    public Interactor interactor;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            interactor.doInteraction();
        }
    }
}
