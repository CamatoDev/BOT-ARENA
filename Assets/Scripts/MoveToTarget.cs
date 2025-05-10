using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    Rigidbody2D _rigidbody2;
    public Transform waypoint;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2 = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, waypoint.position);
        Vector2 velocity;

        if(distance < 0.1f)
        {
            velocity = _rigidbody2.velocity;
            velocity.x = 2f;
            _rigidbody2.AddForce(velocity);
        }
    }
}
