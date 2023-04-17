using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Player3DMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public float speed = 4.0f;
    public Vector3 cameraOffset = new Vector3(5.0f, 15.0f, 15.0f);
    public TextMeshProUGUI count;
    public int counter = 0;
    public Slider healthBar;
    public int maxHealth = 100;
    public int currentHealth;
    void Start()
    {
        healthBar.maxValue = maxHealth;
        currentHealth = maxHealth;
        healthBar.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetAxis("Horizontal") != 0)
        {
            float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + horizontal, gameObject.transform.position.y, 
                gameObject.transform.position.z);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y ,
                gameObject.transform.position.z + vertical);
        }
        cam.transform.position = gameObject.transform.position + cameraOffset;
    }
    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject != null)
        {
            Debug.Log("colliding");
        }
        if (collision.gameObject.CompareTag("Collectible"))
        {
            Debug.Log("Collided");
            Destroy(collision.gameObject);
            counter++;
            count.text = counter.ToString();
            
        }
        if (collision.gameObject.CompareTag("Bomb"))
        {
            currentHealth -= 10;
            healthBar.value = currentHealth;
            Destroy(collision.gameObject);
        }
    }
    


}
