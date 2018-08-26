using System;
using UnityEngine;

/// <summary>
/// Cursor controller.
/// </summary>
public class CursorController : MonoBehaviour
{
    //private GameObject m_Cursor;
    private Rigidbody2D m_MyRigidbody2D;
    private Grid m_Grid;
    private float m_NextMovementTime;
    private const float m_SlowMovementPauseTime = 0.1f;

    // For Mouse Clicks
    [SerializeField]
    private float m_XTileAnchor;
    [SerializeField]
    private float m_YTileAnchor;

    // Figure out how to do extra input to speed up the movement rate.
    private const float m_FastMovementPauseTime = 0.1f;

    public void Start()
    {
        // Not sure about setting the cursor like this..
        //m_Cursor = GameObject.FindWithTag("Cursor");
        m_MyRigidbody2D = GetComponent<Rigidbody2D>();
        m_NextMovementTime = Time.time;

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
            var worldPoint = new Vector2(Mathf.FloorToInt(point.x) + m_XTileAnchor, Mathf.FloorToInt(point.y) + m_YTileAnchor);
            transform.position = worldPoint;

            //var tiles = GameGrid.instance.tiles; // This is our Dictionary of tiles

            //if (tiles.TryGetValue(worldPoint, out _tile))
            //{
            //    print("Tile " + _tile.Name + " costs: " + _tile.Cost);
            //    _tile.TilemapMember.SetTileFlags(_tile.LocalPlace, TileFlags.None);
            //    _tile.TilemapMember.SetColor(_tile.LocalPlace, Color.green);
            //}
        }
    }

    private void DirectionalMove()
    {
        // Getting movement input for keys, mouse, and joystick.
        // Need to find a way to move with rapid key clicks...
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // TODO: @KeyMapping Figure out key mapping for fast and slow movement with keyboard / gamepad.
        if (Time.time > m_NextMovementTime)
        {
            var startPosition = transform.position;
            m_NextMovementTime = Time.time + m_SlowMovementPauseTime;
            m_MyRigidbody2D.MovePosition(new Vector2(startPosition.x + Mathf.Ceil(input.x), startPosition.y + Mathf.Ceil(input.y)));
        }
    }

    private void Select()
    {
        
    }
}