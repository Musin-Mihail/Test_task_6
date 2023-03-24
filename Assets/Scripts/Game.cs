using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Shop _shop;
    private UIControl _uiControl;
    private Coins _coins;
    public TMP_Text coins;
    public TMP_Text power;
    public TMP_Text speed;
    public TMP_Text health;

    private void Start()
    {
        _uiControl = new UIControl(coins, power, speed, health);
        _coins = new Coins(0);
        _shop = new Shop(_uiControl, _coins);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _coins.AddCoins(5);
            _uiControl.ChangeCoins(_coins.GetCoins());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _shop.BuyPower();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _shop.BuySpeed();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _shop.BuyHealth();
        }
    }
}