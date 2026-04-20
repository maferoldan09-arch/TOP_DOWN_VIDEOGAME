using UnityEngine;
using TMPro; 

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int score = 0;
    public bool hasKey = false;
    public bool hasWater = false;

    public TextMeshProUGUI textScore; 
    public TextMeshProUGUI notificationText;

    void Start()
    {
       // ❌ COMENTAR porque textScore es null
       // UpdateTextScore(); 
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Collectable"))
        {
            score = score + 1;

            // ❌ COMENTAR
            // UpdateTextScore();
            // ShowNotification("Collected!"); 

            Destroy(other.gameObject);
            Debug.Log("Collected!");
            Debug.Log("Score: " + score);
        }

        if(other.CompareTag("Key"))
        {
            hasKey = true;
            score = score + 5;

            // ❌ COMENTAR
            // UpdateTextScore();
            // ShowNotification("KEY Collected!"); 

            Debug.Log("KEY Collected!");
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Water"))
        {
            hasWater = true;

            // ❌ COMENTAR
            // ShowNotification("Has tocado el agua, no puedes ganar");

            Debug.Log("Has tocado el agua, comunicate con el servicio tecnico de Samsung, Oh!");
        }
                
        if (score >= 3 && hasKey == true && !hasWater)
        {
            // ❌ COMENTAR
            // ShowNotification("You Won!");

            Debug.Log("You Won!");
        }
    }

    void UpdateTextScore()
    {
        // ❌ COMENTAR
        // textScore.text = "Score: " + score;
    }

    void ShowNotification(string message)
    {
        // ❌ COMENTAR
        // notificationText.text = message; 
    }
}