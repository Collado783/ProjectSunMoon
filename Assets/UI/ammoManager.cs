using UnityEngine;
using UnityEngine.UI;

public class ammoManager : MonoBehaviour
{
    public Text ammoText;
    public int ammoIndex = 100;
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
        if(ammoIndex>0)
        ammoIndex -= 10;
        ammoText.text = ammoIndex.ToString() + "/100";
    }
    public void AddPoint()
    {
        ammoIndex = 100;
        ammoText.text = ammoIndex.ToString() + "/100";
    }
}
