using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using Aop.Api.Util;

namespace alipay_demo
{
    public partial class notify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lock (this)
            {
                string ALIPAY_PUBLIC_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAq/+IkPABoJGN9fPsUJXqbY3PB7fyE/C81xN0qjS9K+Fnw4edf66P235YQnSoM7jfXRVq7zWtwxQ/RC/fCEAoAQgwVNrPndQcKVH+TDCopcj0+yM7pGm8lBOg/hclNzRqqeedTljpedKDfSsbfhaQ5gJvS4cIuwJ+ziB5V3EbH3XQwkig7zLoRv1ZgJYTLyi3LM1PZ5mMbf+wyqmUZuwTFWRkMxV3c3motKZRVZs6XWO1yGjnkrzfabwes9uazCJyEg3YM+P48G1S0Sld64MaXl0BcDcbHn4yG5Lq8/N/xpHumGEatGQRPS5w0QZw7FTdiaexEKZoUFmwVyvgycVqVQIDAQAB";
                SortedDictionary<string, string> paramsMap = GetRequestPost();
                Boolean signVerified = AlipaySignature.RSACheckV1(paramsMap, ALIPAY_PUBLIC_KEY, "utf-8");//调用SDK验证签名
                if (signVerified)
                {
                    Response.Write("success");
                    // TODO 验签成功后，按照支付结果异步通知中的描述，对支付结果中的业务内容进行二次校验，校验成功后在response中返回success并继续商户自身业务处理，校验失败返回failure
                }
                else
                {
                    // TODO 验签失败则记录异常日志，并在response中返回failure.
                }
            }
        }
        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            coll = Request.Form;
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }
            return sArray;
        }
    }
}