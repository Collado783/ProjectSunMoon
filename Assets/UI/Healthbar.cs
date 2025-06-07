using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health characterHealth;
    [SerializeField] private Image completeHealthbar;
    [SerializeField] private Image currentHealthbar;
    private void Start()
    {
        completeHealthbar.fillAmount = characterHealth.currentHealth / 8;
    }

    private void Update()
    {
        currentHealthbar.fillAmount = characterHealth.currentHealth / 8;
    }
}
