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
        foreach (Transform child in this.transform)
            Destroy(child.gameObject);

        if (sentence.Length > 0)
        {
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] != ' ')
                {
                    GameObject letterMesh;

                    if (char.IsUpper(sentence[i]))
                        letterMesh = (GameObject)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Models/3DText/Uppercase/alphabet_{sentence[i]}.fbx", typeof(GameObject));
                    else if (char.IsLower(sentence[i]))
                        letterMesh = (GameObject)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Models/3DText/Lowercase/alphabet_{sentence[i]}.fbx", typeof(GameObject));
                    else
                        letterMesh = (GameObject)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Models/3DText/Numbers/number_{sentence[i]}.fbx", typeof(GameObject));

                    GameObject initalisationOfIt = Instantiate(letterMesh);
                    initalisationOfIt.transform.SetParent(this.transform);

                    initalisationOfIt.transform.position = transform.position;

                    if(i > 0)
                        initalisationOfIt.transform.position = new Vector3(-transform.GetChild(i - 1).transform.position.x * TextDefinitions.textOffsets[sentence[i - 1]], 0, 0);

                    initalisationOfIt.GetComponent<MeshRenderer>();
                    initalisationOfIt.AddComponent<MeshCollider>().convex = true;
                    //thingyXD.AddComponent<Throwable>();
                }
            }
        }

        prevSentence = sentence;
    }
}
