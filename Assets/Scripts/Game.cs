using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Shop _shop;
    private UIControl _uiControl;
    private Coins _coins;
    public TMP_Text allCoins;
    public TMP_Text powerLevel;
    public TMP_Text speedLevel;
    public TMP_Text healthLevel;
    public TMP_Text powerValue;
    public TMP_Text speedValue;
    public TMP_Text healthValue;
    public TMP_Text powerCost;
    public TMP_Text speedCost;
    public TMP_Text healthCost;

    private void Start()
    {
        _uiControl = new UIControl(allCoins, powerLevel, speedLevel, healthLevel, powerValue, speedValue, healthValue, powerCost, speedCost, healthCost);
        _coins = new Coins(0);
        _shop = new Shop(_uiControl, _coins);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _coins.AddCoins(500);
            _uiControl.ChangeCoins(_coins.GetCoins());
        }
    }

    public void BuyPower()
    {
        _shop.BuyPower();
    }

    public void BuySpeed()
    {
        _shop.BuySpeed();
    }

    public void BuyHealth()
    {
        _shop.BuyHealth();
    }
}