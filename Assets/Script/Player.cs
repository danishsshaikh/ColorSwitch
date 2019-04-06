using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject obsticle;
    public GameObject colorChanger;
    public float jumpForce = 10f;
    public Rigidbody2D circle;
    public string currentColor;
    public SpriteRenderer sr;
    public Color Cyan;
    public Color Yellow;
    public Color Pink;
    public Color Purple;
    public static int score = 0;
    public Text scoreText;
    
    void Start()
    {
        setRandomColor();
    }

   
    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            circle.velocity = Vector2.up * jumpForce;
        }
        scoreText.text = score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "scored")
        {
            score++;
            Destroy(collision.gameObject);
            Instantiate(obsticle, new Vector2(transform.position.x , transform.position.y + 9f ), transform.rotation);
            return;
        }

        if(collision.tag == "colorChanger")
        {
            setRandomColor();
            Destroy(collision.gameObject);
            Instantiate(colorChanger, new Vector2(transform.position.x, transform.position.y + 11f), transform.rotation);
            return;
        }
        if(collision.tag != currentColor)
        {
            Debug.Log("You DED");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            score = 0;
        }
    }

    private void Instantiate(GameObject obsticle, Vector2 vector2)
    {
        throw new NotImplementedException();
    }

    void setRandomColor()
    {
        int rand = UnityEngine.Random.Range(0, 4);

        switch(rand)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = Cyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = Yellow;
                break;
            case 2:
                currentColor = "Pink";
                sr.color = Pink;
                break;
            case 3:
                currentColor = "Purple";
                sr.color = Purple;
                break;

        }
    }
}
