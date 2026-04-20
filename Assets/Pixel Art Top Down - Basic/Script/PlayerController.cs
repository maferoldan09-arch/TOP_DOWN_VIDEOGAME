using UnityEngine;
using TMPro; 

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int score = 0;

    public bool hasCofre = false;   // 🔄 antes hasKey
    public bool hasTumba = false;   // 🔄 antes hasWater

    public TextMeshProUGUI textScore; 
    public TextMeshProUGUI notificationText;

    void Start()
    {
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

            // UpdateTextScore();
            // ShowNotification("Collected!"); 

            Destroy(other.gameObject);
            Debug.Log("Collected!");
            Debug.Log("Score: " + score);
        }

        if(other.CompareTag("Cofre"))
        {
            hasCofre = true;
            score = score + 5;

            // UpdateTextScore();
            // ShowNotification("COFRE Collected!"); 

            Debug.Log("COFRE Collected!");
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Tumba"))
        {
            hasTumba = true;

            // ShowNotification("Has tocado la tumba, no puedes ganar");

            Debug.Log("Has tocado la tumba, no puedes ganar");
        }
                
        if (score >= 3 && hasCofre == true && !hasTumba)
        {
            // ShowNotification("You Won!");

            Debug.Log("You Won!");
        }
    }

    void UpdateTextScore()
    {
        // textScore.text = "Score: " + score;
    }

    void ShowNotification(string message)
    {
        // notificationText.text = message; 
    }
}