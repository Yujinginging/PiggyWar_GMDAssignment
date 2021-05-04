using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutepig : MonoBehaviour
{
    private bool isClicked = false;
    public Transform rightPosition;
    public float maxDistance = 2;

    [HideInInspector]
    public SpringJoint2D springJoint2D;
    private Rigidbody2D rigidBody2D;

    //lines
    public LineRenderer rightLine;
    public LineRenderer leftLine;
    public Transform rightPos;
    public Transform leftPos;


    //
    public GameObject boom;

    private void Awake()
    {
        springJoint2D = GetComponent<SpringJoint2D>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown() //press the mouse
    {
        isClicked = true;
        rigidBody2D.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isClicked = false;
        rigidBody2D.isKinematic = false;
        Invoke("Fly", 0.1f);
        //unable line
        rightLine.enabled = false;
        leftLine.enabled = false;
    }

    private void Update() //
    {
        if (isClicked)//if mouse keeps pressed,follow the positions
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //transform.position += new Vector3(0,0,10) ??
            transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);

            //if ...true, limit the distance
            if (Vector3.Distance(transform.position, rightPosition.position) > maxDistance)
            {
                Vector3 pos = (transform.position - rightPosition.position).normalized;
                //length
                pos *= maxDistance; // max distance (vector)
                transform.position = pos + rightPosition.position;
            }
            HandleLines();
        }
    }

    void Fly()
    {
        springJoint2D.enabled = false; //let springjoint2d disabled -> let the pig fly
        Invoke("HandleNextPigFly", 4); //wait 4s and ...
    }

    //draw line
    void HandleLines()
    {
        rightLine.enabled = true;
        leftLine.enabled = true;

        rightLine.SetPosition(0, rightPos.position);
        rightLine.SetPosition(1,transform.position);


        leftLine.SetPosition(0, leftPos.position);
        leftLine.SetPosition(1, transform.position);
    }


    void HandleNextPigFly()
    {
        Manager._instance.cuties.Remove(this);
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        Manager._instance.NextCuty();
    }
}
