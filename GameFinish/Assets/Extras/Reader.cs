using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reader : MonoBehaviour
{
    public TextAsset jsonFile;
    // Start is called before the first frame update
    void Start()
    {
        BulletSaver bulletInJson = JsonUtility.FromJson<BulletSaver>(jsonFile.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
