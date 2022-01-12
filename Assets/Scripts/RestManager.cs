using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RestManager : MonoBehaviour
{
     public Action<bool> OnObtainingData;
     public Action<bool> OnObtainError;
     public Action<NFTData> OnObtainNFT;


    public IEnumerator GetDataFromWeb()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://api.opensea.io/api/v1/assets?order_direction=desc&offset=0&limit=20");
        OnObtainingData.Invoke(true);
        
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            OnObtainError.Invoke(true);
        }
        else
        {
            OnObtainingData.Invoke(false);
            var deserializer = new NFTJsonDeserializer();
            var rData = deserializer.Deserialize(www.downloadHandler.text);
            foreach (var item in rData.assets)
            {
                OnObtainNFT.Invoke(item);
            }
        }
    }
}

