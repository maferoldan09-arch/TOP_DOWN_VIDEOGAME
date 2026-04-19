using UnityEngine;
using TMPro; 

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int score = 0;
    public bool hasKey = false;
    public bool hasWater = false;
    public TextMeshProUGUI textScore; //variable para conectar con nuestro Texto en la UI
     public TextMeshProUGUI notificationText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       UpdateTextScore(); 
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    //este método especial de unity se ejecuta cuando interactuamos con un objeto en modo Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Collectable"))
        {
            score = score + 1;//le sumo 1 a la variable score
            UpdateTextScore();
            ShowNotification("Collected!");; 

            Destroy(other.gameObject);
            Debug.Log("Collected!");
            Debug.Log("Score: " + score);
           
        }
        if(other.CompareTag("Key"))
        {
            hasKey = true;
            score = score + 5;
            UpdateTextScore();
            ShowNotification("KEY Collected!"); 

            Debug.Log("KEY Collected!");
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Water"))
        {
            hasWater = true;
            ShowNotification("Has tocado el agua, no puedes ganar");
            Debug.Log("Has tocado el agua, comunicate con el servicio tecnico de Samsung, Oh!");
            
        }
                
        if (score >= 3 && hasKey == true && !hasWater) //
        {
            ShowNotification("You Won!");
            Debug.Log("You Won!");
        }
        /*else
        {
             Debug.Log("Keep trying, you need 3 and the KEY to win");
        }*/
    }

    void UpdateTextScore()
    {
         textScore.text = "Score: " + score;
    }

    void ShowNotification(string message)
    {
         notificationText.text = message; 
    }

}