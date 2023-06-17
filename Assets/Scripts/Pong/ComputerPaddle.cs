using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inherit from paddle.cs
public class ComputerPaddle : Paddle
{
    public Rigidbody2D _square;

    private void FixedUpdate()
    {
        // Track location of the square to hit it
        if (this._square.velocity.x > 0f)
        {
            if (this._square.position.y > this.transform.position.y)
            {
                _rigidbody.AddForce(Vector2.up * this._speed);
            }
            else if (this._square.position.y < this.transform.position.y)
            {
                _rigidbody.AddForce(Vector2.down * this._speed);
            }
        }
        // Stay still if square coming directly at computer paddle
        else
        {
            if (this.transform.position.y > 0f)
            {
                _rigidbody.AddForce(Vector2.down * this._speed);
            }
            else if (this.transform.position.y < 0f)
            {
                _rigidbody.AddForce(Vector2.up * this._speed);
            }
        }
    }
}
