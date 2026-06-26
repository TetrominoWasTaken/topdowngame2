using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider slider;
    public float maxHealth;

    void Update()
    {
        slider.value -= Time.deltaTime;
        if (slider.value <= 0)
        {
            LevelManager.LoadDeath();
        }
    }

    public void addHealth(float healthToAdd)
    {
        slider.value += healthToAdd;
    }
}
