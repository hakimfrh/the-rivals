using UnityEngine;
using UnityEngine.UI;
public class UI_HealthBar : MonoBehaviour
{

    [SerializeField]private Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updateHealth(float health, float maxHealth){
        slider.value = health/maxHealth;
    }
}
