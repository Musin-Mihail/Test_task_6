public class Coins
{
    private int _coins;

    public Coins(int coins)
    {
        _coins = coins;
    }

    public void AddCoins(int coins)
    {
        _coins += coins;
    }

    public bool RemovedCoins(int coins)
    {
        if (_coins >= coins)
        {
            _coins -= coins;
            return true;
        }

        return false;
    }

    public int GetCoins()
    {
        return _coins;
    }
}