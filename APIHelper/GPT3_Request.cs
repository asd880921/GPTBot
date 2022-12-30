using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DCBot
{
    public class GPT3_Request
    {    
        public string Request(string postText)
        {
            try 
            {
            // 設定 API 的終點 URL
            string apiUrl = "https://api.openai.com/v1/completions";

            // 設定 API 的請求參數  
            var requestParams = new
            {
                model = "text-davinci-003",
                prompt = postText,
                max_tokens = 256,
                temperature = 0.7,
                top_p = 1,
                frequency_penalty = 0,
                fresence_penalty = 0,
                best_of=1
            };

            // 建立 HTTP 請求
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(apiUrl),
                Content = new StringContent(JsonConvert.SerializeObject(requestParams), Encoding.UTF8, "application/json")
            };

            // 設定 API Key
            request.Headers.Add("Authorization","Bearer " + BaseValues.GPT3_Token);

            // 建立 HTTP 客戶端
            var client = new HttpClient();

            // 發出請求並取得回應
            var response = client.SendAsync(request).Result;

            // 讀取回應的內容
            var responseContent = response.Content.ReadAsStringAsync().Result;

            // 顯示回應的內容
            Console.WriteLine(responseContent);
            
            dynamic dynObj = JsonConvert.DeserializeObject(responseContent);
            
            if (dynObj != null)
            {
                return dynObj.choices[0].text.ToString();
            }
            }
            catch(Exception ex)
            {
                Console.WriteLine("GPT3_API EX:" + ex.Message);
            }
            return "API_Error";
        }  
    }
}
