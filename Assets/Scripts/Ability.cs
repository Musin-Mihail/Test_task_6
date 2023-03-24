public class Ability
{
    private int _power;
    private int _speed;
    private int _health;

    public Ability()
    {
        _power = 1;
        _speed = 1;
        _health = 1;
    }

    public int AddPower()
    {
        _power++;
        return _power;
    }

    public int AddSpeed()
    {
        _speed++;
        return _speed;
    }

    public int AddHealth()
    {
        _health++;
        return _health;
    }
}