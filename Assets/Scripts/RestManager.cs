using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RestManager : MonoBehaviour
{
    public String uri;
    public Action<bool> OnObtainingData;
    public Action<bool> OnObtainError;
    public Action<Asset> OnObtainNFT;


    public IEnumerator GetDataFromWeb()
    {
        UnityWebRequest www = UnityWebRequest.Get(uri);
        www.SetRequestHeader("Accept", "application/json");
        www.SetRequestHeader("X-API-KEY", "ede9cdaa66d0421c995acc00fb40ec77");
        OnObtainingData.Invoke(true);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            OnObtainError.Invoke(true);
        }
        else
        {
            var deserializer = new NFTJsonDeserializer();
            var rData = deserializer.Deserialize(www.downloadHandler.text);
            foreach (var item in rData.assets)
            {
                OnObtainNFT.Invoke(item);
            }
            OnObtainingData.Invoke(false);
        }
    }

    public IEnumerator GetDataFromLocal()
    {
        var deserializer = new NFTJsonDeserializer();
        var rData = deserializer.Deserialize(Resources.Load("response_test").ToString());
        foreach (var item in rData.assets)
        {
            OnObtainNFT.Invoke(item);
        }
        OnObtainingData.Invoke(false);
        yield return default;
    }
}


