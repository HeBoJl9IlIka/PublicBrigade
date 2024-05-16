using System;
using UnityEngine;

namespace Nevalyashka.Brigade.Model
{
    public class Bucket
    {
        private ConstructionMaterial _currentMaterial;
        private int _amountMaterial;

        public int EmptyAmount => Config.MaxAmountBucket - _amountMaterial;
        public Config.TypeConstructionMaterial TypeMaterial => _currentMaterial != null ? _currentMaterial.Type : Config.TypeConstructionMaterial.Null;

        public event Action<int> Changed;
        public event Action Selected;
        public event Action Canceled;

        public void Select()
        {
            Selected?.Invoke();
        }

        public void Cancel()
        {
            Canceled?.Invoke();
        }

        public void AddMaterial(ConstructionMaterial material, int amount)
        {
            if (_currentMaterial != null)
            {
                if (TypeMaterial != material.Type)
                    return;
            }

            _currentMaterial = material;
            _amountMaterial += amount;
            _amountMaterial = Mathf.Clamp(_amountMaterial, 0, Config.MaxAmountBucket);
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

        public void Unload()
        {
            _amountMaterial = 0;
            _currentMaterial = null;
            Changed?.Invoke(_amountMaterial);
        }

        public void Drop()
        {
            _amountMaterial -= Config.AmountDroppedMaterial;
            _amountMaterial = Mathf.Clamp(_amountMaterial, 0, Config.MaxAmountBucket);
            Changed?.Invoke(_amountMaterial);
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
