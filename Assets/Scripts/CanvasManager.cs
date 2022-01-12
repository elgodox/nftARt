using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject panelToShowNFTs;
    private RestManager _restManager;
    private NFT _nft;


    void Start()
    {
        _restManager = FindObjectOfType<RestManager>();
        _restManager.OnObtainingData += ObtainingData;
        _restManager.OnObtainError += ObtainError;
        _restManager.OnObtainNFT += ObtainNFT;
    }

    public void GetDataForNFT()
    {
        StartCoroutine(_restManager.GetDataFromWeb());
    }

    public void ObtainingData(bool obtaining)
    {
        Debug.Log("OBTAINING DATA: " + obtaining);
    }

    public void ObtainError(bool obtaining)
    {
        Debug.Log("OBTAING ERROR " + obtaining);
    }

    public void ObtainNFT(NFTData nftData)
    {
        StartCoroutine(ObtainData(nftData));
    }

    public IEnumerator ObtainData(NFTData nftData)
    {
        _nft = Resources.Load<NFT>("Prefabs/NFT");

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(nftData.image_thumbnail_url);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            nftData.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;

        _nft.OnInstance(nftData, panelToShowNFTs.transform);
    }
}