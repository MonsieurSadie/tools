using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Shop
{
    // enums for data
    public enum ItemType
    {
        Arme,
        Bouclier,
        Divers
    }

    public enum ItemRarity
    {
        Common,
        Rare,
        Lengendary
    }

    public class ItemData : ScriptableObject
    {
        public int ID;
        public string Name;
        public ItemType Type;
        public ItemRarity Rarity;
        public int Price;
        public int ATK;
        public int DEF;
        public string Description_fr;
        public string Description_en;
        public string Description_es;
    }
}
