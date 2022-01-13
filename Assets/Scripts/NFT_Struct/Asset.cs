using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Asset
{
    public int id { get; set; }
    public string token_id { get; set; }
    public int num_sales { get; set; }
    public object background_color { get; set; }
    public string image_url { get; set; }
    public string image_preview_url { get; set; }
    public string image_thumbnail_url { get; set; }
    public object image_original_url { get; set; }
    public string animation_url { get; set; }
    public string animation_original_url { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string external_link { get; set; }
    public AssetContract asset_contract { get; set; }
    public string permalink { get; set; }
    public Collection collection { get; set; }
    public object decimals { get; set; }
    public object token_metadata { get; set; }
    public Owner owner { get; set; }
    public object sell_orders { get; set; }
    public Creator creator { get; set; }
    public List<Trait> traits { get; set; }
    public object last_sale { get; set; }
    public object top_bid { get; set; }
    public object listing_date { get; set; }
    public bool is_presale { get; set; }
    public object transfer_fee_payment_token { get; set; }
    public object transfer_fee { get; set; }
    
    public Texture texture{ get; set; }
    public VideoClip video { get; set; }
}