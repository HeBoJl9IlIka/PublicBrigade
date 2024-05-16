using System;

namespace Nevalyashka.Brigade.Model
{
    public class WateringCan
    {
        private int _amount;

        public bool HasWater => _amount > 0;

        public event Action<int> Changed;

        public void Fill()
        {
            _amount = Config.MaxAmountWateringCan;
            Changed?.Invoke(_amount);
        }

        public void Water(int targetAmount, out int gettingAmount)
        {
            gettingAmount = 0;

            if (_amount == 0)
                return;

            if (_amount < targetAmount)
            {
                gettingAmount = _amount;
                _amount = 0;
            }
            else
            {
                gettingAmount = targetAmount;
                _amount -= targetAmount;
            }

            Changed?.Invoke(_amount);
        }
    }
}
