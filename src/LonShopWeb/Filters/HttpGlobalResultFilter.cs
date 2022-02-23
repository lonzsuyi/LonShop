using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using LonShop.BaseCore.Constants;

namespace LonShop.LonShopWeb.Filters
{
    public class HttpGlobalResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            //throw new System.NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is BadRequestObjectResult)
            {
                // Response format 
                var badRequestObjectResult = context.Result as BadRequestObjectResult;
                var msgList = new List<MsgKV>();
                foreach (var modelStateKey in context.ModelState.Keys)
                {
                    var value = context.ModelState[modelStateKey];
                    foreach (var error in value.Errors)
                    {
                        if (error.Exception == null)
                        {
                            msgList.Add(new MsgKV { itemKey = modelStateKey, msgCode = error.ErrorMessage });
                        }
                        else
                        {
                            msgList.Add(new MsgKV { itemKey = modelStateKey, msgCode = error.Exception.Message });
                        }

                    }
                }

                context.Result = new BadRequestObjectResult(new ActionResultModel((int)badRequestObjectResult.StatusCode, msgList));
            }
            else if (context.Result is FileContentResult)
            {
                context.Result = context.Result;
            }
            else if (context.Result is ChallengeResult)
            {
                context.Result = context.Result;
            }
            else if (context.Result is FileStreamResult)
            {
                context.Result = context.Result;
            }
            else if (context.Result is VirtualFileResult)
            {
                context.Result = context.Result;
            }
            else if (context.Result is RedirectResult)
            {
                context.Result = context.Result;
            }
            else
            {
                // Response format 
                var objectResult = context.Result as ObjectResult;
                context.Result = new ObjectResult(new ActionResultModel((int)objectResult.StatusCode, new List<MsgKV>(), objectResult.Value));
            }
        }
    }
}
