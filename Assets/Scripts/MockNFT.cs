using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MockNFT : MonoBehaviour, INFT
{
    public GameObject imageHolder;
    public GameObject creatorName;
    public GameObject creatorAddress;
    public GameObject nftName;
    public GameObject nftDescription;
    public GameObject ownerImage;

    private RectTransform _rectTransform;
    private RectTransform _imageHolderTransform;
    private RawImage _rawImage;
    private Text _creatorName;
    private Text _creatorAddress;
    private Text _nftName;
    private TextMeshProUGUI _nftDescription;
    private RawImage _ownerImage;

    public void OnInstance(Asset nft, Transform position)
    {
        GetComponents();
        AssignData(nft);
        Instantiate(this, position);
    }

    private void GetComponents()
    {
        _rectTransform = GetComponent<RectTransform>();
        _imageHolderTransform = GetComponent<RectTransform>();
        _rawImage = imageHolder.GetComponent<RawImage>();
        _creatorName = creatorName.GetComponent<Text>();
        _creatorAddress = creatorAddress.GetComponent<Text>();
        _nftName = nftName.GetComponent<Text>();
        _nftDescription = nftDescription.GetComponent<TextMeshProUGUI>();
        _ownerImage = ownerImage.GetComponent<RawImage>();

    }

    private void AssignData(Asset nft)
    {
        _rawImage.texture = nft.texture;
        _creatorName.text = nft.creator.user.username;
        _creatorAddress.text = nft.creator.address;
        _nftName.text = nft.name;
        _nftDescription.text = RemoveBreaks(nft.description);
        _ownerImage.texture = nft.owner.textureProfile;

        Vector2 size = ResizeImage(_rawImage);
        _imageHolderTransform.sizeDelta = size;
        _rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
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

    private string RemoveBreaks(string text)
    {
        try
        {
            text = text.Replace("\n", "");
            return text;

        }
        catch
        {
            return text;
        }

    }
}
