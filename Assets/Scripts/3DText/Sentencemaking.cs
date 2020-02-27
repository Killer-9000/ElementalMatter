using Assets.Scripts.Database;
using Assets.Scripts.Database.Models;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Sentencemaking : MonoBehaviour
{
    public string sentence;

    private string prevSentence;

    // Start is called before the first frame update
    void Start()
    {
        prevSentence = sentence;
        TextMeshUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (prevSentence != sentence)
            TextMeshUpdate();   
    }

    void TextMeshUpdate()
    {
        bool charIsSpace = false;
        foreach (Transform child in transform)
            Destroy(child.gameObject);

        if (sentence.Length > 0)
        {
            for (int i = 0; i < sentence.Length; i++)
            {
                GameObject letterMesh = null;

                if (char.IsUpper(sentence[i]))
                    letterMesh = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Models/3DText/Uppercase/alphabet_{sentence[i]}.fbx", typeof(GameObject)));
                else if (char.IsLower(sentence[i]))
                    letterMesh = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Models/3DText/Lowercase/alphabet_{sentence[i]}.fbx", typeof(GameObject)));
                else if (char.IsDigit(sentence[i]))
                    letterMesh = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Models/3DText/Numbers/number_{sentence[i]}.fbx", typeof(GameObject)));
                else
                {
                    letterMesh = new GameObject("Space");
                    charIsSpace = true;
                }

                letterMesh.transform.SetParent(transform);

                if (i > 0)
                {
                    float offset = transform.GetChild(i - 1).transform.localPosition.x + TextDefinitions.textOffsets[sentence[i - 1]];
                    if (charIsSpace)
                        offset += 0.5f; charIsSpace = false;

                    letterMesh.transform.localPosition = new Vector3(offset, 0, 0);
                }
                else
                    letterMesh.transform.localPosition = new Vector3(0, 0, 0);

                letterMesh.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
        prevSentence = sentence;
    }

    void AddSymbolInfo()
    {
        IEnumerable<Elements> elements = DatabaseHandler.instance.GetAllElements();

        foreach(Elements element in elements)
        {

        }
    }
}
