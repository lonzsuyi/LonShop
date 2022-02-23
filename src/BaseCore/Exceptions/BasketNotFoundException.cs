using System;

namespace LonShop.BaseCore.Exceptions;

public class BasketNotFoundException : Exception
{
    public BasketNotFoundException(long basketId) : base($"No basket found with id {basketId}")
    {
    }
}