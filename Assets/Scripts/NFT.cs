using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NFT : MonoBehaviour, INFT
{
    public void OnInstance(Asset nft, Transform position)
    {
        RawImage image = GetComponent<RawImage>();
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(Screen.width, Screen.width);

        name = nft.id.ToString();
        image.texture = nft.texture;
        
        Instantiate(this, position);
    }

}
