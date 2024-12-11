using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float playerHealth;
    public GameObject player1;
    public GameObject player2;

    private float playerHealth1;
    private float playerHealth2;
    private AudioSource audioSource;

    bool isPlayerDie1 = false;
    bool isPlayerDie2 = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        playerHealth1 = player1.GetComponent<PlayerController>().getHealth();
        playerHealth2 = player2.GetComponent<PlayerController>().getHealth();

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
}
