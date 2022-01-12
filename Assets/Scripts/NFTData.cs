using UnityEngine;
using UnityEngine.Video;

public class NFTData
{
    public string id { get; set; } 
    public string image_thumbnail_url { get; set; }
    public string animation_url { get; set; }
    public Texture texture { get; set; }
    public VideoClip animationVideo { get; set; }
}