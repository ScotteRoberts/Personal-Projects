using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cursor controller.
/// </summary>
// TODO @Movement Does not account for other planes than the XY Axis.
public class OverworldCursorMovement : MonoBehaviour
{
    private Overworld overworld;
    private OverworldManager oManager;

    // For Keyboard Input
    private Rigidbody2D m_MyRigidbody2D;
    private float m_NextMovementTime;
    private const float m_SlowMovementPauseTime = 0.2f;
    // Figure out how to do extra input to speed up the movement rate.
    private const float m_FastMovementPauseTime = 0.1f;

    // Events
    public delegate void InputAction(Vector3Int localPoint);
    public static event InputAction OnCursorMove;

    public void Awake()
    {

    }

    public void Start()
    {
        // Cannot be initialized during Awake!!
        overworld = Overworld.GetInstance();
        oManager = OverworldManager.GetInstance();

        m_MyRigidbody2D = GetComponent<Rigidbody2D>();
        m_NextMovementTime = Time.time;
        var localPoint = new Vector3Int(Mathf.FloorToInt(transform.position.x),
                                        Mathf.FloorToInt(transform.position.y), 0);

        // Start off position
        if (OnCursorMove != null)
        {
            OnCursorMove(localPoint);
        }
    }

    public void Update()
    {
        DirectionalMove();
        MouseMove();
        Select();
    }

    private void MouseMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var localPoint = new Vector3Int(Mathf.FloorToInt(point.x), 
                                         Mathf.FloorToInt(point.y), 0);
            // Can we move to a tile?
            if (overworld.IsMovable(localPoint))
            {
                var worldPoint = oManager.IncludeTilemapAnchor(localPoint);
                transform.position = worldPoint;

                // Fire Event
                if (OnCursorMove != null)
                {
                    OnCursorMove(localPoint);
                }
            }
                
        }
    }

    // TODO: @KeyMapping Figure out key mapping for fast and slow movement with keyboard / gamepad.
    private void DirectionalMove()
    {
        // Do I have any input?
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0 || 
            Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0)
        {
            // Am I allowed to move again, yet?
            if (Time.time > m_NextMovementTime)
            {
                m_NextMovementTime = Time.time + m_FastMovementPauseTime;

                // Getting movement input for keys, mouse, and joystick.
                var input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                var localPoint = new Vector3Int(Mathf.FloorToInt(transform.position.x + Mathf.Ceil(input.x)),
                                         Mathf.FloorToInt(transform.position.y + Mathf.Ceil(input.y)), 0);

                // Can we move to a tile?
                if (overworld.IsMovable(localPoint))
                {
                    var worldPoint = oManager.IncludeTilemapAnchor(localPoint);
                    print("After cursor: " + worldPoint);
                    transform.position = worldPoint;

                    // Fire Event for successful move.
                    if (OnCursorMove != null)
                    {
                        OnCursorMove(localPoint);
                    }
                }
            }
        }
    }

    private void Select()
    {
        
    }
}