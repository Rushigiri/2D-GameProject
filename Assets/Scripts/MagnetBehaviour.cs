using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagnetBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject magnet;
    public GameObject hook;
    public Canvas CarryText;
    float distance;
    bool playerPickMagnet;
    public GameObject magnetPosition;
    public Rigidbody2D rb;
    public bool isDrag;
    public float unHookTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // GetComponent<SpringJoint2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.transform.position, magnet.transform.position);

        if((distance < 2f)&& !playerPickMagnet)
        {
            CarryText.gameObject.SetActive(true);
        }
        else
        {
            CarryText.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            
            rb.isKinematic = false;
           rb.simulated = true;
            CarryMagnet();
           
            //OnMouseDown();
            //rb.position = magnetPosition.transform.position;
            //rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //GetComponent<BoxCollider2D>().enabled = true;

            //rb.constraints = RigidbodyConstraints2D.FreezeAll;



        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.isKinematic = false;
            rb.simulated = false;
            DropMagnet();
           //OnMouseUp();
            //GetComponent<BoxCollider2D>().enabled = false;

            //rb.constraints = RigidbodyConstraints2D.None;
            //OnMouseUp();
        }
        if (isDrag)
        {
            //if(Input.GetKeyDown(KeyCode.LeftControl))

           rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          //rb.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,0,0));

        }


    }

    public void CarryMagnet()
    {
        CarryText.gameObject.SetActive(false);
        //hook.transform.SetParent(magnetPosition.transform);
        //transform.SetParent(magnetPosition.transform);
        transform.position = magnetPosition.transform.position;
       // transform.localPosition = new Vector2(0, 1.1f);
        playerPickMagnet = true;
        GetComponent<SpringJoint2D>().enabled = true;
    }

    public void DropMagnet()
    {
        CarryText.gameObject.SetActive(true);
       //transform.parent = null;
        playerPickMagnet = false;
        //GetComponent<SpringJoint2D>().enabled = true;
       // GetComponent<SpringJoint2D>().enabled = false;
    }

    private void OnMouseDown()
    {
        Debug.Log("onmdown");
        isDrag = true;
        //rb.isKinematic = true;
        //rb.simulated = true;
        // GetComponent<SpringJoint2D>().enabled = true;
        //GetComponent<BoxCollider2D>().enabled = false;

        //rb.constraints = RigidbodyConstraints2D.None;
        //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        //GetComponent<SpringJoint2D>().enabled = false;
       // GetComponent<SpringJoint2D>().enabled = true;
        //StopCoroutine(UnHook());
    }

    private void OnMouseUp()
    {
        isDrag = false;
       //rb.isKinematic = false;
       // rb.simulated = false;
        //StartCoroutine(UnHook());
       GetComponent<SpringJoint2D>().enabled = false;
        //GetComponent<BoxCollider2D>().enabled = false;

       // 
    }

    IEnumerator UnHook()
    {
        yield return new WaitForSeconds(unHookTime);
        //GetComponent<SpringJoint2D>().enabled = false;
        //this.enabled = false;

    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        Debug.Log("trigger");
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if((collision.gameObject.tag == "magnet") && (Input.GetKeyDown(KeyCode.E)))
    //    {
    //        magnet2.gameObject.SetActive(true);
    //        magnet1.gameObject.SetActive(false);
    //    }
    //    else
    //    {
    //        magnet2.gameObject.SetActive(false);
    //        magnet1.gameObject.SetActive(true);
    //    }
    //}
}
