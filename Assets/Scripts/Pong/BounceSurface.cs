using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSurface : MonoBehaviour
{
    public float _bounce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Square square = collision.gameObject.GetComponent<Square>();

        if (square != null)
        {
            Vector2 normal = collision.GetContact(0).normal;
            // -normal to bounce in opposite direction
            square.AddForce(-normal * this._bounce);
        }
    }
}
