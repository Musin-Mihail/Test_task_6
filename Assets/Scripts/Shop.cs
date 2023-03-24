public class Shop
{
    private readonly Coins _coins;
    private readonly Ability _ability;
    private readonly UIControl _uiControl;
    public Shop(UIControl uiControl, Coins coins)
    {
        _uiControl = uiControl;
        _coins = new(1000);
        _ability = new();
        _coins = coins;
    }

    public void BuyPower()
    {
        if (_coins.RemovedCoins(5))
        {
            _uiControl.ChangePower(_ability.AddPower());
            _uiControl.ChangeCoins(_coins.GetCoins());
        }
    }
    
    public void BuySpeed()
    {
        if (_coins.RemovedCoins(5))
        {
            _uiControl.ChangeSpeed(_ability.AddSpeed());
            _uiControl.ChangeCoins(_coins.GetCoins());
        }
    }
    
    public void BuyHealth()
    {
        if (_coins.RemovedCoins(5))
        {
            _uiControl.ChangeHealth(_ability.AddSpeed());
            _uiControl.ChangeCoins(_coins.GetCoins());
        }
    }
}