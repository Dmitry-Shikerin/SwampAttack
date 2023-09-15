using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemConteiner;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(Weapon weapon)
    {
        WeaponView view = Instantiate(_template, _itemConteiner.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Set(weapon);
    }

    private void OnSellButtonClick(Weapon weapon, WeaponView weaponView)
    {
        TrySellWeapon(weapon, weaponView);
    }

    private void TrySellWeapon(Weapon weapon, WeaponView view)
    {
        
        if (weapon.Price <= _player.Money)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            Instantiate(weapon);
            view.SellButtonClick -= OnSellButtonClick;
        }
    }
}