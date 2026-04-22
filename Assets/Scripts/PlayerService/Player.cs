using System;
using UnityEngine;

namespace EdwinGameDev.PlayerService
{
    public class Player
    {
        public int Money { get; private set; }
        public event Action<int> OnMoneyChanged;
        
        public void AddMoney(int amount)
        {
            Money += amount;

            OnMoneyChanged?.Invoke(Money);
        }

        public void RemoveMoney(int amount)
        {
            Money = Mathf.Max(0, Money - amount);
            OnMoneyChanged?.Invoke(Money);
        }
    }
}