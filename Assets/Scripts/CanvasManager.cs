using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;
using System;

public class CanvasManager : MonoBehaviour
{
    public GameObject panelToShowNFTs;
    public Action<bool> onShowNFTs;
    private bool _canUpdateContent;
    private Content _panelToShowNFTs;
    private RestManager _restManager;
    private INFT _mockNFT;


    void Start()
    {
        _restManager = FindObjectOfType<RestManager>();
        _panelToShowNFTs = FindObjectOfType<Content>();
        _restManager.OnObtainingData += ObtainingData;
        _restManager.OnObtainError += ObtainError;
        _restManager.OnObtainNFT += ObtainNFT;
        _panelToShowNFTs.updateContent += GetDataForNFT;
    }

    public void GetDataForNFT()
    {
        _canUpdateContent = true;
        if (_canUpdateContent)
        {
            StartCoroutine(_restManager.GetDataFromWeb());
        }
           
    }

    public void ObtainingData(bool obtaining)
    {
        Debug.Log("OBTAINING DATA: " + obtaining);
        _canUpdateContent = !obtaining;
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
        yield return StartCoroutine(RequestTextureForNFT(nft));
        yield return StartCoroutine(RequestTextureForOwnerProfile(nft));
        if (nft.image_preview_url != null)
        {
            if (nft.texture!=default)
            {
                _mockNFT = Resources.Load<MockNFT>("Prefabs/MockNFT");
                _mockNFT.OnInstance(nft, panelToShowNFTs.transform);
                yield break;
            }

        }
    }

    private IEnumerator RequestTextureForNFT(Asset nft)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(nft.image_url);
        yield return request.SendWebRequest();
        if(request.result == UnityWebRequest.Result.ConnectionError|| (request.result == UnityWebRequest.Result.ProtocolError))
        {
            Debug.Log(request.error);
            yield break;
        }
        else
        {
            if (request.downloadHandler.text.Contains("JPG")|| request.downloadHandler.text.Contains("PNG"))
                yield return nft.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }

    private IEnumerator RequestTextureForOwnerProfile(Asset nft)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(nft.owner.profile_img_url);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || (request.result == UnityWebRequest.Result.ProtocolError))
        {
            Debug.Log(request.error);
            yield break;
        }
        else
        {
            if (request.downloadHandler.text.Contains("JPG") || request.downloadHandler.text.Contains("PNG"))
                yield return nft.owner.textureProfile = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
}