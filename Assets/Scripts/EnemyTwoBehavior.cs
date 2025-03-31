using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyTwoBehavior : MonoBehaviour
{
    private bool movingLeft;
    private bool movingRight;
    private float leftThreshold = -8f;
    private float rightThreshold = 8f;
    private Vector3 direction = Vector3.left;

    // Start is called before the first frame update
    void Start()
    {
        movingLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 0.75f);
        /*
        if (movingLeft == true)
        {
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 2.5f);
        }

        if (transform.position.x <= leftThreshold)
        {
            movingLeft = false;
            movingRight = true;
        }

        if (movingRight == true)
        {
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 2.5f);
        }

        if (transform.position.x >= rightThreshold)
        {
            movingRight = false;
            movingLeft = true;
        }
        */

        transform.Translate(direction * Time.deltaTime * 2.5f);
        if (transform.position.x <= leftThreshold)
        {
            direction = Vector3.right;
        }
        else if (transform.position.x >= rightThreshold)
        {
            direction = Vector3.left;
        }

        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }
}
