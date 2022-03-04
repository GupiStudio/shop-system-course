using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterShopDatabase", menuName = "Character Shop Database")]
public class CharacterShopDatabase : ScriptableObject
{
    public Character[] Characters;

    public int CharacterCount => Characters.Length;

    public Character GetCharacter(int index)
    {
        return Characters[index];
    }

    public bool PurchaseCharacter(int index)
    {
        if (Characters[index].isPurchased)
        {
            return false;
        }

        Characters[index].isPurchased = true;

        return true;
    }
}
