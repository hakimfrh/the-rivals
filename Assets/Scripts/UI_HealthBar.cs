using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
public class UI_HealthBar : MonoBehaviour
{

    [SerializeField]private Slider slider;
    private PlayerController player;
    private bool isFlippedLast = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isFlipped = player.isFlipped();
        if(isFlipped != isFlippedLast){
            transform.Rotate(new Vector3(0,180,0));
            isFlippedLast = isFlipped;
            }
    }

    public void updateHealth(float health, float maxHealth){
        slider.value = math.clamp(health/maxHealth,0,1);
    }
}
