using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMesh;
    
    public void SetAmount(int amount)
    {
        if (amount >= 1000)
        {
            _textMesh.text = 
                string.Format(
                    "{0}K.{1}", 
                    amount / 1000, 
                    GetFirstDigitFromNumber(amount % 1000));
        }
        else
        {
            _textMesh.text = amount.ToString();
        }
    }
    
    private int GetFirstDigitFromNumber(int number)
    {
        return int.Parse(number.ToString()[0].ToString());
    }
}
