using System;
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

        name = nft.id.ToString();
        image.texture = nft.texture;

        Vector2 size = ResizeImage(image);
        rectTransform.sizeDelta = size;

        Instantiate(this, position);
    }

    private Vector2 ResizeImage(RawImage image)
    {
        var ratioX = (double)Screen.width / image.mainTexture.width;
        var ratioY = (double)Screen.width / image.mainTexture.height;
        var ratio = Math.Min(ratioX, ratioY);

        var newWidth = (int)(image.mainTexture.width * ratio);
        var newHeight = (int)(image.mainTexture.height * ratio);

        var newSize = new Vector2(newWidth, newHeight);

        return newSize;
    }

}
