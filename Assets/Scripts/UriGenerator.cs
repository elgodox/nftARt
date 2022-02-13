using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUrigenerator
{
    public void SetOwner(string owner);
    public void SetTokenIds(string token_ids);
    public void SetAssetContractAddress(string asset_contract_address);
    public void SetAssetContractAddresses(string asset_contract_addresses);
    public void SetOrderDirection(string order_direction);
    public void SetCollection(string collection);
    public void SetLimit(string limit);
    public void SetOffset(string offset);
    public string GetUri();
}


public class UriGenerator : IUrigenerator
{
    private string _uri;
    private string _asset_contract_address;
    private string _asset_contract_addresses;
    private string _collection;
    private string _limit;
    private string _order_direction;
    private string _owner;
    private string _offset;
    private string _token_ids;

    public UriGenerator(string uri)
    {
        _uri = uri;
    }

    public string GetUri()
    {
        return _uri + BuildUri();
    }

    public void SetAssetContractAddress(string asset_contract_address)
    {
        if (asset_contract_address != "")
            _asset_contract_address = "&asset_contract_address=" + asset_contract_address;
    }

    public void SetAssetContractAddresses(string asset_contract_addresses)
    {
        if (asset_contract_addresses != "")
            _asset_contract_addresses = "&asset_contract_addresses=" + asset_contract_addresses;
    }

    public void SetCollection(string collection)
    {
        if (collection != "")
            _collection = "&collection=" + collection;
    }

    public void SetLimit(string limit)
    {
        if (limit != "")
            _limit = "&limit=" + limit;
        else
            _limit = "&limit=20";
    }

    public void SetOrderDirection(string order_direction)
    {
        if (order_direction != "")
            _order_direction = "&order_direction=" + order_direction;
        else
            _order_direction = "&order_direction=desc";
    }

    public void SetOwner(string owner)
    {
        if (owner != "")
            _owner = "&owner=" + owner;
    }

    public void SetTokenIds(string token_ids)
    {
        if (token_ids != "")
            _token_ids = "&token_ids=" + token_ids;
    }
    public void SetOffset(string offset)
    {
        if (offset != "")
            _offset = "&offset=" + offset;
        else
            _offset = "&offset=0";
    }

    private string BuildUri()
    {
        return _owner + _token_ids + _asset_contract_address + _asset_contract_addresses + _order_direction + _offset + _limit + _collection;
    }

}
