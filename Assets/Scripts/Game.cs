using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Shop _shop;
    private UIControl _uiControl;
    private Coins _coins;
    private Ability _ability;
    private SpawnEnemy _spawner;
    public Transform enemy;
    private List<CoinControl> _coinControls;
    public Transform coinPrefab;
    public Transform player;
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
        _ability = player.GetComponent<Player>().GetAbility();
        _shop = new Shop(_uiControl, _coins, _ability);
        var enemies = new List<Transform>();
        for (int i = 0; i < 10; i++)
        {
            var newEnemy = Instantiate(enemy);
            newEnemy.gameObject.SetActive(false);
            newEnemy.GetComponent<Enemy>().SetPlayer(player);
            enemies.Add(newEnemy);
        }

        EventManager.AddEnemies?.Invoke(enemies);
        _spawner = new SpawnEnemy(enemies);
        StartCoroutine(_spawner.Spawn());
        EventManager.DeadEnemy += CreateCoin;
        EventManager.EndCoin += AddCoin;
        EventManager.Hit += GetDamage;
        EventManager.SpawnEnemy += Spawn;
        _coinControls = new List<CoinControl>();
    }

    private void Spawn(Transform newEnemy, Vector3 vector)
    {
        newEnemy.position = vector;
        newEnemy.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _coins.AddCoins(500);
        }
    }

    private void AddCoin()
    {
        _coins.AddCoins(50);
        _uiControl.ChangeCoins(_coins.GetCoins());
    }

    private int GetDamage()
    {
        return _ability.GetPowerValue();
    }

    private void CreateCoin(Vector3 enemy)
    {
        StartCoroutine(GetCoinControl().Move(enemy));
    }

    private CoinControl GetCoinControl()
    {
        foreach (var coinControl in _coinControls)
        {
            if (!coinControl.Busy)
            {
                return coinControl;
            }
        }

        return CreateCoinControl();
    }

    private CoinControl CreateCoinControl()
    {
        var coinControl = new CoinControl(CreateCoin());
        _coinControls.Add(coinControl);
        return coinControl;
    }

    private Transform CreateCoin()
    {
        var newCoin = Instantiate(coinPrefab).gameObject;
        return newCoin.transform;
    }

    public void BuyPower()
    {
        _shop.BuyPower();
        _uiControl.ChangeCoins(_coins.GetCoins());
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