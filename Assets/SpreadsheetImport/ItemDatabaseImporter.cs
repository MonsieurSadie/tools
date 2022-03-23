using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Shop
{
    public class ItemDatabaseImporter : MonoBehaviour
    {
        // C'est une bonne pratique de créer des variables qui contiennent le nom des colonnes
        const int NAME    = 1;
        const int TYPE    = 2;
        const int RARITY  = 3;
        const int PRICE   = 4;
        const int ATK     = 5;
        const int DEF     = 6;
        const int FR      = 7;
        const int EN      = 8;
        const int ES      = 9;

        [MenuItem("Custom Data/Import")]
        static void ImportData()
        {
            string outputFolder = "Assets/SpreadsheetImport/ItemsImportedData/";
            string filepath = Application.dataPath + "/SpreadsheetImport/GameDataBase.csv";
            
            string[] filecontent = System.IO.File.ReadAllLines(filepath);

            foreach (var line in filecontent)
            {
                // skip first line as it is juste the columns names (first line starts with #)
                if (line[0] == '#') continue;

                // before reading current line data, create the data structure that will hold the data
                ItemData newData    = ScriptableObject.CreateInstance<ItemData>();

                Debug.LogFormat("Parsing line {0}", line);
                string[] lineData   = line.Split(',');
                newData.Name        = lineData[NAME];
                // Pour convertir une string en valeur d'enum, il y a deux méthodes
                // 1 : on passe le type de l'enum en paramètre de la fonction Enum.Parse puis on cast le résultat
                newData.Type        = (ItemType) System.Enum.Parse(typeof(ItemType), lineData[TYPE]);
                // 2: on utilise la version TryParse qui fait automatiquement le cast mais demande de passer l'adresse de la varaible dans laquelle on veut ranger la donnée. Ceci se fait en ajoutant le mot-clef "out"
                System.Enum.TryParse<ItemRarity>(lineData[RARITY], out newData.Rarity);

                newData.ATK         = int.Parse(lineData[ATK]); // Ici, int.Parse échouera (lancera une Exception) si la donnée lue dans le fichier csv n'est pas un entier. On aura donc une erreur qui nous indiquera un problème avec le contenu du fichier
                newData.DEF         = int.Parse(lineData[DEF]);
                newData.Price       = int.Parse(lineData[PRICE]);

                // create asset file
                string assetFileName = line[0] + ".asset";
                AssetDatabase.CreateAsset(newData, outputFolder + assetFileName);
            }
            // save asset files
            AssetDatabase.SaveAssets();
        }
    }
}
