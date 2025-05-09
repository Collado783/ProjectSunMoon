using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health characterHealth;
    [SerializeField] private Image completeHealthbar;
    [SerializeField] private Image currentHealthbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        completeHealthbar.fillAmount = characterHealth.currentHealth / 8;
    }

    // Update is called once per frame
    private void Update()
    {
        currentHealthbar.fillAmount = characterHealth.currentHealth / 8;
    }
}
