using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMesh;

    private int _amount;

    public int Amount
    {
        get => _amount;
        set
        {
            _amount = value;

            if (_amount >= 1000)
            {
                _textMesh.text =
                    $"{_amount / 1000}K.{GetFirstDigitFromNumber(_amount % 1000)}";
            }
            else
            {
                _textMesh.text = _amount.ToString();
            }
        }
    }

    private int GetFirstDigitFromNumber(int number)
    {
        return int.Parse(number.ToString()[0].ToString());
    }
}