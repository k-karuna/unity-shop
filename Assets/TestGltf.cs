using System;
using System.Collections;
using Siccity.GLTFUtility;
using UnityEngine;
using UnityEngine.Networking;

public class TestGltf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadModelBytes(ModelLoaded));
    }

    void ModelLoaded(byte[] bytes)
    {
        var model = Importer.LoadFromBytes(bytes);
        var rock = GameObject.Find("PT_Menhir_Rock_02");
        model.transform.position = rock.transform.position + new Vector3(0, 6, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator LoadModelBytes(Action<byte[]> cb)
    {
        const string url =
            "https://assets.objkt.media/file/assets-003/Qmd3A5LayPoyhoTyAeQkPForCPZsqQtnzHNTGayXRNb28K/artifact";
        var www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        cb.Invoke(www.isDone ? www.downloadHandler.data : Array.Empty<byte>());
    }
}