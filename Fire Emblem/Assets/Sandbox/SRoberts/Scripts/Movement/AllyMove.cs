using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMove : MonoBehaviour {
    [SerializeField]
    private float speed;

    public void Update()
    {
        Move();
    }
    public void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    public void GetInput()
    {
        if(Input.GetAxis("Horizontal") > 0.1)
        {

        }
    }
}
