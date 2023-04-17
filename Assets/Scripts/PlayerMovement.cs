using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public float speed = 3.0f;
    public float jumpHeight = 4.0f;
    public Rigidbody2D rb;
    public Camera cam;
    public bool ladder = false;
    public float climbSpeed = 10.0f;
    public float xPos = 0f;
    public bool climb = false;
    public TextMeshProUGUI coinCount;
    public int coins;
    public Slider healthSlider;
    public float maxHealth = 100f;
    public float currentHealth;
    public int jumpCount = 0;
    public bool grounded = false;
    public GameObject win;
    // Start is called before the first frame update
    void Start()
    {

        rb = player.GetComponent<Rigidbody2D>();
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        currentHealth = healthSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        if(grounded)
        {
            jumpCount = 0;
        }
        //if the keys linked to the horizontal input which are a & d are pressed causing the input to not equal 0 as the player either moves left or right.
        //then calculate velocity of player and add it to current x-pos of player.
        if (Input.GetAxis("Horizontal") != 0)
        {
            float hMove = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            
            Vector3 pos = new Vector3(player.transform.position.x + hMove, player.transform.position.y, 0);
            player.transform.position = pos;
        }

        if (Input.GetButtonDown("Jump") && climb == false)
        {
            if (jumpCount < 2)
            {
                rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                Debug.Log("jump");
                jumpCount++;
                if (grounded == false && jumpCount == 1)
                {
                    Debug.Log("jump2");
                    rb.AddForce(Vector2.up * jumpHeight * 0.5f, ForceMode2D.Impulse);
                    jumpCount++;
                }

            }

            
            
        }
        if (Input.GetAxis("Vertical") != 0 && ladder == true)
        {
            rb.gravityScale = 0;
            float vMove = Input.GetAxis("Vertical") * Time.deltaTime * climbSpeed;
            Vector3 pos = new Vector3(xPos, player.transform.position.y + vMove, 0);
            player.transform.position = pos;
            climb = true;
        }
        
        cam.transform.position = new Vector3(player.transform.position.x + 2.0f, player.transform.position.y + 3.0f, -10.0f);
    }
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            jumpCount = 0;
            grounded = true;

        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            jumpCount = 0;
            grounded = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounded = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            ladder = true;
            xPos = player.transform.position.x + 0.5f;
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            CoinCounts();

        }
        if (collision.gameObject.CompareTag("Spikes"))
        {
            Debug.Log("hit spike. Current Health: " + healthSlider.value);
            currentHealth = currentHealth - 5.0f;
            Health();
        }
        if (collision.gameObject.CompareTag("Door"))
        {
            win.gameObject.SetActive(true);
        }
        
    }

    
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            ladder = false;
            if (climb)
            {
                player.transform.position = new Vector3(xPos, player.transform.position.y + 2.5f, 0);
                
                rb.gravityScale = 1;
                climb = false;
            }
            
        }
    }
    public void CoinCounts()
    {
        coins += 1;
        coinCount.text = " " + coins.ToString();

    }
    public void Health()
    {
        
        healthSlider.value = currentHealth;
        
        Debug.Log("Health after hit: " + healthSlider.value);
    }
  


}
