using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class NFTVideo : MonoBehaviour, INFT
{
    public VideoPlayer videoPlayer;
    public void OnInstance(Asset nft, Transform position)
    {
        videoPlayer.url = nft.image_preview_url;
        Instantiate(this, position);
    }
}
