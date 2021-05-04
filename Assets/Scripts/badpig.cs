using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badpig : MonoBehaviour
{

    public float minSpeed = 8;
    public float maxSpeed = 10;

    public Sprite hurt;
    //public Sprite laugh;

    private SpriteRenderer renderer;

    public GameObject boom;
    public GameObject thumb;



    //if it is a pig or stones...
    public bool isPig = false;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude > maxSpeed) // die immediately >.<
        {
            //Destroy(gameObject);            
            BadPigDead();
        }
        else if(collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed) //bad pig gets hurt
        {
            renderer.sprite = hurt;
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collider)
    {

    }*/

    void BadPigDead()
    {
        if (isPig)
        {
            Manager._instance.badPigs.Remove(this);
        }
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameObject gO = Instantiate(thumb, transform.position + new Vector3(0,1.5f,0), Quaternion.identity);  // make the thumb a little bit higher than the pig's original position
        Destroy(gO, 2f);
    }
}
