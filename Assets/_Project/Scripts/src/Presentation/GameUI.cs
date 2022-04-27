using UnityEngine;

namespace Froggi.Presentation
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private WalletUI _wallet;

        public void UpdateWallet(int amount)
        {
            _wallet.Amount = amount;
        }
    }
}
