using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove2D : MonoBehaviour
{//https://forum.unity.com/threads/make-object-follow-mouse-2d-game.211186/

    public Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }
}
