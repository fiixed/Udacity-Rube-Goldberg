using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Throwable")) {
            Debug.Log("collision");
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            collision.gameObject.transform.position = new Vector3(
                collision.gameObject.transform.position.x, collision.gameObject.transform.position.y + 2.9f,
                collision.gameObject.transform.position.z + 2.1f);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

        }

    }

  
}
