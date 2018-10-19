using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cursor controller.
/// </summary>
// TODO @Movement Does not account for other planes than the XY Axis.
public class OverworldCursorController : MonoBehaviour
{
    private Overworld overworld;
    private OverworldManager oManager;

    // For Keyboard Input
    private Rigidbody2D m_MyRigidbody2D;
    private float m_NextMovementTime;
    private const float m_SlowMovementPauseTime = 0.1f;
    // Figure out how to do extra input to speed up the movement rate.
    private const float m_FastMovementPauseTime = 0.05f;

    // Events
    public delegate void InputAction(Vector3Int localPoint);
    public static event InputAction OnCursorMove;
    public static event InputAction OnSubmit;
    public static event InputAction OnCancel;
    public static event InputAction OnHelp;
    public static event InputAction OnCycle;
    public static event InputAction OnStart;
    public static event InputAction OnSelect;

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
        InputDirectionalMove();
        InputMouseMove();
        InputSubmit();
        InputCancel();
        InputHelp();
        InputCycle();
        InputStart();
        InputSelect();
    }

    private void InputMouseMove()
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
    private void InputDirectionalMove()
    {
        // Do I have any input?
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            // Am I allowed to move again, yet?
            if (Time.time > m_NextMovementTime)
            {
                m_NextMovementTime = Time.time + m_SlowMovementPauseTime;

                // Getting movement input for keys, mouse, and joystick.
                var input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                var localPoint = new Vector3Int(Mathf.FloorToInt(transform.position.x + Mathf.Ceil(input.x)),
                                         Mathf.FloorToInt(transform.position.y + Mathf.Ceil(input.y)), 0);

                // Can we move to a tile?
                if (overworld.IsMovable(localPoint))
                {
                    var worldPoint = oManager.IncludeTilemapAnchor(localPoint);
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

    // GBA "A" Button
    private void InputSubmit()
    {
        if(Input.GetButtonDown("Submit"))
            print("Submit Successful");
    }

    // GBA "B" Button
    private void InputCancel()
    {

        if (Input.GetButtonDown("Cancel"))
            print("Cancel Successful");
    }

    // GBA "R" Button
    private void InputHelp()
    {
        if (Input.GetButtonDown("Help"))
            print("Help Successful");
    }

    // GBA "L" Button
    private void InputCycle()
    {
        if (Input.GetButtonDown("Cycle"))
            print("Cycle Successful");
    }

    // GBA "Start" Button
    private void InputStart()
    {
        if (Input.GetButtonDown("Start"))
            print("Start Successful");
    }

    // GBA "Select" Button
    private void InputSelect()
    {
        if (Input.GetButtonDown("Select"))
            print("Select Successful");
    }
}