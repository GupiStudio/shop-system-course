using UnityEngine;
using TMPro;

public class SharedUI : MonoBehaviour
{
    public static SharedUI instance;

    [SerializeField]
    private TMP_Text[] textsCoins;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        UpdateCoinsUITexts();
    }

    public void UpdateCoinsUITexts()
    {
        int countTextUI = textsCoins.Length;
        
        for (int i = 0; i < countTextUI; i++)
        {
            SetUICoinText(textsCoins[i], DataManager.GetCoins());
        }
    }

    private void SetUICoinText(TMP_Text textMesh, int value)
    {
        if (value >= 1000)
        {
            textMesh.text = 
                string.Format(
                    "{0}K.{1}", 
                    value / 1000, 
                    GetFirstDigitFromNumber(value % 1000));
        }
        else
        {
            textMesh.text = value.ToString();
        }
    }

    int GetFirstDigitFromNumber(int number)
    {
        return int.Parse(number.ToString()[0].ToString());
    }
}
