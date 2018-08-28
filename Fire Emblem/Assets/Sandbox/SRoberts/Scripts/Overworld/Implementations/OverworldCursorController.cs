using System;
using UnityEngine;

/// <summary>
/// Cursor controller.
/// </summary>
// TODO @Movement Does not account for other planes than the XY Axis.
public class OverworldCursorController : MonoBehaviour
{
    // For Keyboard Input
    private Rigidbody2D m_MyRigidbody2D;
    private float m_NextMovementTime;
    private const float m_SlowMovementPauseTime = 0.2f;
    // Figure out how to do extra input to speed up the movement rate.
    private const float m_FastMovementPauseTime = 0.1f;

    // Events
    public delegate void InputAction(Vector3 worldPoint, Vector2 tileAnchor);
    public static event InputAction OnCursorMove;

    // TODO @Movement Try to get rid of these fucking offsets without it looking bad.
    // For Mouse Clicks
    [SerializeField]
    private float m_XTileAnchor;
    [SerializeField]
    private float m_YTileAnchor;
    private Vector3 worldPoint;
    private Vector2 tileAnchor;

    public void Start()
    {

        m_MyRigidbody2D = GetComponent<Rigidbody2D>();
        m_NextMovementTime = Time.time;
        worldPoint = transform.position;
        tileAnchor = new Vector2(m_XTileAnchor, m_YTileAnchor);

        // Start off position
        if (OnCursorMove != null)
        {
            OnCursorMove(worldPoint, tileAnchor);
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
            worldPoint = new Vector3(Mathf.FloorToInt(point.x) + tileAnchor.x, 
                                         Mathf.FloorToInt(point.y) + tileAnchor.y);
            transform.position = worldPoint;

            // Fire Event
            if (OnCursorMove != null)
            {
                OnCursorMove(worldPoint, tileAnchor);
            }
        }
    }

    private void DirectionalMove()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0 || 
            Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0)
        {
            // TODO: @KeyMapping Figure out key mapping for fast and slow movement with keyboard / gamepad.
            if (Time.time > m_NextMovementTime)
            {
                m_NextMovementTime = Time.time + m_FastMovementPauseTime;

                // Getting movement input for keys, mouse, and joystick.
                // Need to find a way to move with rapid key clicks...
                var input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                worldPoint = new Vector3(transform.position.x + Mathf.Ceil(input.x),
                                         transform.position.y + Mathf.Ceil(input.y));
                m_MyRigidbody2D.MovePosition(worldPoint);

                // Fire Event
                if (OnCursorMove != null)
                {
                    OnCursorMove(worldPoint, tileAnchor);
                }
            }
        }
    }

    private void Select()
    {
        
    }
}