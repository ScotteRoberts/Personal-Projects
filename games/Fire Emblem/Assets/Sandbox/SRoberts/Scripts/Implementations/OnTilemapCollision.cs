using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTilemapCollision : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Tilemap: Enter Collision = " + col.gameObject.name);
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("Tilemap: Exit Collision = " + col.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Tilemap: Enter Trigger = " + col.gameObject.name);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Tilemap: Exit Trigger = " + col.gameObject.name);
    }
}
