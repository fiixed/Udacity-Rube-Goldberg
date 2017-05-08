using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour {

    public static int collectiblesCount;
    public Material inBounds;
    private GameObject[] collectibles;
    private Vector3 position;
    private Rigidbody rb;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        position = transform.position;
        collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        collectiblesCount = collectibles.Length;
       
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            gameObject.tag = "Throwable";
            gameObject.GetComponent<Renderer>().material = inBounds;
            transform.position = position;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            foreach (var item in collectibles) {
                item.GetComponent<MeshRenderer>().enabled = true;
                collectiblesCount = collectibles.Length;
            }
        }

       

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Collectible")) {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            if (collectiblesCount > 0) {
                collectiblesCount--;
            }
        }
    }






}
