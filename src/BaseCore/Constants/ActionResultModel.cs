using System.Collections.Generic;

namespace LonShop.BaseCore.Constants
{
    public class ActionResultModel
    {
        /// <summary>
        /// ActionResultModel constructor
        /// </summary>
        /// <param name="code">HttpCode</param>
        /// <param name="msgCodeArr">Message code</param>
        /// <param name="result">return Result</param>
        public ActionResultModel(int code, List<MsgKV> msg, object result = null)
        {
            this.code = code;

            this.msg = msg;

            this.result = result;
        }
        public int code { get; set; }

        public List<MsgKV> msg { get; set; }

        public object result { get; set; }
    }
}
