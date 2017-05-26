using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aop.Api;
using Aop.Api.Request;
using Aop.Api.Response;
using Newtonsoft.Json;
using Aop.Api.Util;


namespace alipay_demo
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string APPID = "2016080400168714";
            string ALIPAY_PUBLIC_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAq/+IkPABoJGN9fPsUJXqbY3PB7fyE/C81xN0qjS9K+Fnw4edf66P235YQnSoM7jfXRVq7zWtwxQ/RC/fCEAoAQgwVNrPndQcKVH+TDCopcj0+yM7pGm8lBOg/hclNzRqqeedTljpedKDfSsbfhaQ5gJvS4cIuwJ+ziB5V3EbH3XQwkig7zLoRv1ZgJYTLyi3LM1PZ5mMbf+wyqmUZuwTFWRkMxV3c3motKZRVZs6XWO1yGjnkrzfabwes9uazCJyEg3YM+P48G1S0Sld64MaXl0BcDcbHn4yG5Lq8/N/xpHumGEatGQRPS5w0QZw7FTdiaexEKZoUFmwVyvgycVqVQIDAQAB";
            string APP_PRIVATE_KEY = "MIIEpAIBAAKCAQEA0u5E9i09AclVVmXfVN7GH4nG7mr7AsT4rRcZYMVzurX9x47htsz8k0K9svjQqEY30DyEfewS9WtZhQIesdMO7vj0F+gL7t0/oZAHgjoTH2vPWo94dwqeRADaJj0cVlz6TrUX7pOjz4hKaRsZC3Zw11PVU81FDiFC/agKmjDJcCAPDOTBq7Sr5yZNLvzfyHM3p8Iq90t6KZSBY0t/4Ai8JzEbZARsYmKL4eReHdZS2vm5cxObDb/Gk3plry1kCS7sySdTPf9lpdaehW2hoQ800OBGrW2IYiYxRVtodmK13wOMqR0+8oQElcn0nG3sQdP0962gqOIQWTplqfzvbMJZTwIDAQABAoIBAQCnps6VRJuq4dW8WDhMgszCoIXHVqywJNLq8OMw8X/stV5C0SRCYWeXvIJ+0Bk4xqbyEkfUtmDTREHg4DB5cqH5+1I39i4V6zD6PzpYncQ5Qz2KY2KCa6QjtPGvVv9A/aHOEU42SI75EwDhzbH4VGmYHIAAnbT3aCSQ7JGQwJo7TS5faWm0ZexPS4bfP12TdLPKIrVG66RT5iQ953bpJEv/i5MM2EkFlWqjTAiyQxu5fHSk3VQ22MqyXNNL45iODHiHZ9kbW3vS7MWV7NFM/cTTDEiMhFnneNwoe0nF3XgY0e5RO6y2JJON1XOnJVbUgjY6zufjFnVyQAYjVDv0X1WRAoGBAO7fW3eQxjyX63u8511eJNK2MagtVJnuyB4riiB+/yo/8wq8eJ0ovUhOlLh3lz27Hk64h2+HjIrQtSfLHW1G6FRGCWXbPy7S/zQ1UpzOt63mIH0j8Z5vsFqHfb/foSLPGoO24UncJx1P3FRj3I8FomQoxOHGA/q9dZpQBe6HkcXTAoGBAOIOBm26GLTawVbGLlVz5eoLtSMdJ1ja7DGotpsMfbIVrWqeWW0K4tyzO52E7TSxVlvy8oF4KL98PSiyGzTNW6WdcoOtXutki7VvAaJLlsTEjDS1x5ESqCVtW6q52ZPRTGvwiyuy709aF7oCe6bYqJpO2XpCWJofGTcF5PXxUAUVAoGBAJC/dmy4pPeY05BywvyYDNZGo0aW2XpB8LAfkB7q9fKDN+KcnLYXNsP3IjW5+kLk/ZOUTDWwPODtYakQcu+CFUzj99PqDJpyL0VSvpHYzgMpvSw3uLVaVtI04mV/vOQb/aQtEM2yA13Gw+u7a66bKnFpJwzs8gJiBj6RGVcWfaYTAoGAKPTlkUfgZhQkZ3ZsuqrPA0KvxPbpRB4WIUEyJJF0zKlEzEZ4aVtJkzceHAITgDKJNQuliHOe3mLCKfdrGnwCmNUYBGeLBRcogOzl3OPZIzmBNaOhztUUhgN0UlBt7WxEbmIctQQse7IVDmyYvrgOhDa5DH+s0e/Ef8WfoDfiiakCgYBkawQzUZyp7eeR+uNq6FU4Lbgtl3RqmPgm+d67+g6mxXK0YELNJDpazX5IhkaF2k6yi9fMg+HhZapFywXDygoH2avqhMXzDZf5w18+f8KWMcQWEYls8aZHnFVKhHEQQ6Ne101Sm1SDs+3dl+YaK2VTrh24FCzIgCCawAnWPsoG/Q==";
            IAopClient client = new DefaultAopClient("https://openapi.alipaydev.com/gateway.do", APPID, APP_PRIVATE_KEY, "json", "1.0", "RSA2", ALIPAY_PUBLIC_KEY, "utf-8", false);//初始化
            AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();//参数配置
            request.SetNotifyUrl("http://www.baidu.com");//异步通知地址
            request.SetReturnUrl("http://www.baidu.com");//同步返回地址
            request.BizContent = JsonConvert.SerializeObject(new
            {//附加参数
                body = "商品1",
                subject = "介绍",
                out_trade_no = "20138374726281726271",
                total_amount = "0.01",
                product_code = "FAST_INSTANT_TRADE_PAY"
            });
            AlipayTradePagePayResponse response = client.pageExecute(request);
            string form = response.Body;
            Response.Write(form);
        }
    }
}