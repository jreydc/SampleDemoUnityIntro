using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherScript : MonoBehaviour
{
    private float pushForce = 0.1f;

    public void DebugTesting(string message)
    {
        Debug.Log(message);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.X))
        {
            transform.Translate(new Vector3(1,0,0) * pushForce);
            Debug.Log(other.gameObject.name + " detected!");
        }

        Debug.Log("Collision detected!" + other.gameObject.name);
    }
}
