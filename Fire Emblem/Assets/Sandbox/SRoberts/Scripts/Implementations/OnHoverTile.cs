using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OnHoverTile : MonoBehaviour
{
    private Transform cursorPosition;
    private Tilemap tilemap;
    private void Start()
    {
        cursorPosition = GetComponent<Transform>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Cursor: Enter Collision = " + col.gameObject.name);
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("Cursor: Exit Collision = " + col.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Cursor: Enter Trigger = " + col.gameObject.name);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Cursor: Exit Trigger = " + col.gameObject.name);
    }
}
