using UnityEngine;
using UnityEngine.UI;

public class ammoManager : MonoBehaviour
{
    public Text ammoText;
    int ammoIndex = 1000;
    public static ammoManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ammoText.text = ammoIndex.ToString() + "/100";
    }
    public void Fire()
    {
        ammoIndex -= 10;
        ammoText.text = ammoIndex.ToString() + "/100";
    }
    public void AddPoint()
    {
        ammoIndex = 100;
        ammoText.text = ammoIndex.ToString() + "/100";
    }
}
