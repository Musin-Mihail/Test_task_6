using TMPro;

public class UIControl
{
    private TMP_Text _coins;
    private TMP_Text _power;
    private TMP_Text _speed;
    private TMP_Text _health;

    public UIControl(TMP_Text coins, TMP_Text power, TMP_Text speed, TMP_Text health)
    {
        _coins = coins;
        _power = power;
        _speed = speed;
        _health = health;
    }
    public void ChangeCoins(int value)
    {
        _coins.text = value.ToString();
    }

    public void ChangePower(int value)
    {
        _power.text = "Lv " + value;
    }

    public void ChangeSpeed(int value)
    {
        _speed.text = "Lv " + value;
    }

    public void ChangeHealth(int value)
    {
        _health.text = "Lv " + value;
    }
}