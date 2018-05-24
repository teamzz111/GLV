using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObject : MonoBehaviour {

    private Vector3 Position;

    void Start()
    {
        Position = this.gameObject.transform.position;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Collider")
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.transform.position = Position;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
