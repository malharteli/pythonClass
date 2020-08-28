using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private Rigidbody2D targetRB;

    // Start is called before the first frame update
    void Start()
    {
        targetRB = target.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetRB.position.x, targetRB.position.y, transform.position.z);
    }
}
