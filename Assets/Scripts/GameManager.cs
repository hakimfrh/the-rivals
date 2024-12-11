using Unity.VisualScripting;
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
    private AudioSource audioSource;

    bool isPlayerDie1 = false;
    bool isPlayerDie2 = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth1 = playerHealth;
        playerHealth2 = playerHealth;
        healthBar1 = player1.GetComponentInChildren<UI_HealthBar>();
        healthBar2 = player2.GetComponentInChildren<UI_HealthBar>();
        healthBar1.updateHealth(playerHealth, playerHealth);
        healthBar2.updateHealth(playerHealth, playerHealth);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth1 <= 0 && !isPlayerDie1)
        {   
            PlayerController playerController = player1.GetComponent<PlayerController>();
            if(playerController.dieSound != null){
                AudioClip sfxDie = playerController.dieSound;
                audioSource.PlayOneShot(sfxDie);
            }
            player1.SetActive(false);
            isPlayerDie1 = true;
        }
        if (playerHealth2 <= 0 && !isPlayerDie2)
        {
            PlayerController playerController = player2.GetComponent<PlayerController>();
            if(playerController.dieSound != null){
                AudioClip sfxDie = playerController.dieSound;
                audioSource.PlayOneShot(sfxDie);
            }
            player2.SetActive(false);
            isPlayerDie2 = true;        
        }


    }
    public void hitPlayer1(float damage, AudioClip itemHit)
    {
        playerHealth1 -= damage;
        healthBar1.updateHealth(playerHealth1, playerHealth);
        player1.GetComponent<PlayerController>().sfxHit();
        if(itemHit != null){
            player1.GetComponent<PlayerController>().playSfx(itemHit);
        }

    }

    public void hitPlayer2(float damage, AudioClip itemHit)
    {
        playerHealth2 -= damage;
        healthBar2.updateHealth(playerHealth2, playerHealth);
        player2.GetComponent<PlayerController>().sfxHit();
        if(itemHit != null){
            player2.GetComponent<PlayerController>().playSfx(itemHit);
        }
    }
}
