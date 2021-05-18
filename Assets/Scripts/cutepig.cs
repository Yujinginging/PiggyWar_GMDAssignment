using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutepig : MonoBehaviour
{
    //music
    public AudioClip select;
    public AudioClip flyClip;


    private bool isClicked = false;
    public Transform rightPosition;
    public float maxDistance = 2;

    [HideInInspector]
    public SpringJoint2D springJoint2D;
    protected Rigidbody2D rigidBody2D;

    //lines
    public LineRenderer rightLine;
    public LineRenderer leftLine;
    public Transform rightPos;
    public Transform leftPos;


    //
    public GameObject boom;

    //use a boolean to see if the pig has flied once
    private bool fly = true;

    public float smooth = 3;//for camera follow.. smooth

    //
    private bool isFly = false;

    //settings for trails
    private TestMyTrail myTrail;

    private void Awake()
    {
        springJoint2D = GetComponent<SpringJoint2D>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        //get trail
        myTrail = GetComponent<TestMyTrail>();
    }

    private void OnMouseDown() //press the mouse
    {
        if (fly)
        {
            //musicPlay
            AudioPlay(select);
            isClicked = true;
            rigidBody2D.isKinematic = true;
        }
    }

    private void OnMouseUp()
    {
        if (fly)
        {
            isClicked = false;
            rigidBody2D.isKinematic = false;
            Invoke("Fly", 0.1f);
            //unable line
            rightLine.enabled = false;
            leftLine.enabled = false;
            fly = false; //disable pig fly again
        }
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


        //camera follow objects
        float posX = transform.position.x;
        /*float smoothTime = (float) smooth * (float)Time.deltaTime;*/
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, 
            new Vector3(Mathf.Clamp(posX,7,13),Camera.main.transform.position.y, Camera.main.transform.position.z),
            smooth*Time.deltaTime);


        //
        if (isFly)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShowSpeedUpSkill();
            }
        }
    }

    void Fly()
    {
        isFly = true;
        AudioPlay(flyClip);
        myTrail.PigTrailStart();  
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isFly = false;
        myTrail.ClearPigTrail();
    }

    //
    public void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    //skill of special pig who is able to speed up when press during flying
    public virtual void ShowSpeedUpSkill()
    {
        isFly = false;
    }
}
