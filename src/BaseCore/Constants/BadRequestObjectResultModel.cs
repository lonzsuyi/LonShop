using System.Collections.Generic;

namespace LonShop.BaseCore.Constants
{
    public class BadRequestObjectResultModel
    {
        public BadRequestObjectResultModel(List<MsgKV> msg)
        {
            ErrMsgs = msg;
        }
        public List<MsgKV> ErrMsgs { get; set; }
    }
}