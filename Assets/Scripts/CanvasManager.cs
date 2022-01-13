using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Windows;

public class CanvasManager : MonoBehaviour
{
    public GameObject panelToShowNFTs;
    private RestManager _restManager;
    private INFT _nft;


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

    public void ObtainNFT(Asset asset)
    {
        StartCoroutine(ObtainData(asset));
    }

    public IEnumerator ObtainData(Asset nft)
    {
        if (nft.image_preview_url!=null)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(nft.image_preview_url);
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
                yield break;
            }
            if (request.downloadHandler.text.Contains("GIF"))
                yield break;

            if (request.downloadHandler.text.Contains("MP4"))
            {
                yield return _nft = Resources.Load<NFTVideo>("Prefabs/NFTVideo");
                _nft.OnInstance(nft, panelToShowNFTs.transform);
                yield break;
            }

            yield return nft.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            _nft = Resources.Load<NFT>("Prefabs/NFT");
            _nft.OnInstance(nft, panelToShowNFTs.transform);
        }
    }
}