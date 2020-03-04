using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    public TextMeshProUGUI Moneytext;
    // Start is called before the first frame update
    void Awwake()
    {
        //Moneytext = GetComponentInParent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Moneytext.text = "Деньги: " + (int)MoneyManager.Money;
    }
}
