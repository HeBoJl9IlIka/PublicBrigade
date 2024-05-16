using System;
using UnityEngine;

namespace Nevalyashka.Brigade.Model
{
    public class Inventory
    {
        private ConstructionMaterial _currentMaterial;
        private int _amountMaterial;

        public Config.TypeConstructionMaterial TypeMaterial => _currentMaterial != null ? _currentMaterial.Type : Config.TypeConstructionMaterial.Null;
        public int EmptyAmount => Config.MaxAmountInventory - _amountMaterial;

        public event Action<int> Changed;

        public void AddMaterial(ConstructionMaterial constructionMaterial, int amount = 0)
        {
            if (_currentMaterial != null)
            {
                if (constructionMaterial.Type != _currentMaterial.Type)
                    return;
            }

            if (amount == 0)
                _amountMaterial += constructionMaterial.Amount;
            else
                _amountMaterial += amount;

            _currentMaterial = constructionMaterial;
            _amountMaterial = Mathf.Clamp(_amountMaterial, 0, Config.MaxAmountInventory);
            Changed?.Invoke(_amountMaterial);
        }

        public bool TryRemoveMaterial(int targetAmount, out ConstructionMaterial material, out int gettingAmount)
        {
            material = null;
            gettingAmount = 0;

            if (_amountMaterial == 0)
                return false;

            if (_currentMaterial == null)
                return false;

            material = _currentMaterial;

            if (targetAmount >= _amountMaterial)
            {
                gettingAmount = _amountMaterial;
                _amountMaterial = 0;
                _currentMaterial = null;
            }
            else
            {
                _amountMaterial -= targetAmount;
                gettingAmount = targetAmount;
            }

            Changed?.Invoke(_amountMaterial);
            return true;
        }

        public bool CanAddMaterial(Config.TypeConstructionMaterial type)
        {
            if (_currentMaterial == null)
                return true;

            if (_currentMaterial != null)
            {
                if (_currentMaterial.Type != type)
                    return false;
            }

            if (_amountMaterial >= Config.MaxAmountBucket)
                return false;

            return true;
        }
    }
}
