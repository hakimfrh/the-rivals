using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float playerHealth;
    public GameObject player1;
    public GameObject player2;

    private float playerHealth1;
    private float playerHealth2;
    private UI_HealthBar healthBar1;
    private UI_HealthBar healthBar2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth1 = playerHealth;
        playerHealth2 = playerHealth;
        healthBar1 = player1.GetComponentInChildren<UI_HealthBar>();
        healthBar2 = player2.GetComponentInChildren<UI_HealthBar>();
        healthBar1.updateHealth(playerHealth, playerHealth);
        healthBar2.updateHealth(playerHealth, playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth1 <= 0)
        {
            player1.SetActive(false);
        }
        if (playerHealth2 <= 0)
        {
            player2.SetActive(false);
        }


    }
    public void hitPlayer1(float damage)
    {
        playerHealth1 -= damage;
        healthBar1.updateHealth(playerHealth1, playerHealth);
    }

    public void hitPlayer2(float damage)
    {
        playerHealth2 -= damage;
        healthBar2.updateHealth(playerHealth2, playerHealth);
    }
}
