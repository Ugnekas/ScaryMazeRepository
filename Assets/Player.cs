using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed;

    public GameObject JumpScareImage;

    public AudioSource jumpScareSound;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        jumpScareSound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;

        var finalPosition = Vector3.MoveTowards(transform.position, mousePos, maxSpeed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(finalPosition);


    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.name.Contains("Wall"))
        {
            transform.position = Vector3.zero;
           
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("JumpScareTrigger"))
        {
            JumpScareImage.SetActive(true);
            Time.timeScale = 0;
            jumpScareSound.Play();
        }
    }
}
