using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RestManager : MonoBehaviour
{
    [SerializeField]
    private String uri;
    [SerializeField]
    private String owner;
    [SerializeField]
    private String token_ids;
    [SerializeField]
    private String asset_contract_address;
    [SerializeField]
    private String asset_contract_addresses;
    [SerializeField]
    private String order_direction;
    [SerializeField]
    private String offset;
    [SerializeField]
    private String limit;
    [SerializeField]
    private String collection;
    public Action<bool> OnObtainingData;
    public Action<bool> OnObtainError;
    public Action<Asset> OnObtainNFT;


    public IEnumerator GetDataFromWeb()
    {
        IUrigenerator uriRest = new UriGenerator(uri);
        uriRest.SetOwner(owner);
        uriRest.SetTokenIds(token_ids);
        uriRest.SetAssetContractAddress(asset_contract_address);
        uriRest.SetAssetContractAddresses(asset_contract_addresses);
        uriRest.SetOrderDirection(order_direction);
        uriRest.SetOffset(offset);
        uriRest.SetLimit(limit);

        UnityWebRequest www = UnityWebRequest.Get(uriRest.GetUri());
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


