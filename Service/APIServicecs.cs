﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace GitHubOauth.Services
{
    public class APIServicecs
    {
        HttpClient GitClient;
        public APIServicecs(string PAT = null)
        {
            GitClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.github.com/")
            };
            GitClient.DefaultRequestHeaders.Add("User-Agent", "MyConsoleApp");
            GitClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            if (PAT != null)
                GitClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", PAT);
        }
        public string ApiService(string Url, string Method = "GET", string RequestBody = null)
        {
            StringContent JsonContent = null;
            var request = new HttpRequestMessage(new HttpMethod(Method), new Uri(Url));
            if (RequestBody != null)
            {
                JsonContent = new StringContent(RequestBody, Encoding.UTF8, "application/json");
                request.Content = JsonContent;
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.inertia-preview+json"));

            }
            var response = GitClient.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseString = response.Content.ReadAsStringAsync().Result;
                return responseString;
            }
            return null;

        }
        public string ApiServiceRepo(string Url, string Method = "GET", string RequestBody = null)
        {
            StringContent JsonContent = null;
            var request = new HttpRequestMessage(new HttpMethod(Method), new Uri(Url));
            if (RequestBody != null)
            {
                JsonContent = new StringContent(RequestBody, Encoding.UTF8, "application/json");
                request.Content = JsonContent;
                //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.inertia-preview+json"));

            }
            var response = GitClient.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseString = response.Content.ReadAsStringAsync().Result;
                return responseString;
            }
            return null;
        }
        public string ApiService1(string Url, string Method = "GET", string RequestBody = null,string EmptyData=null)
        {
            StringContent JsonContent = null;
            var request = new HttpRequestMessage(new HttpMethod(Method), new Uri(Url));
            if (RequestBody != null)
            {
                JsonContent = new StringContent(RequestBody, Encoding.UTF8, "application/json");
                request.Content = JsonContent;
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.baptiste-preview+json"));//"application/vnd.github.nebula-preview+json"));

            }
            var response = GitClient.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseString = response.Content.ReadAsStringAsync().Result;
                return responseString;
            }
            return null;

        }
        public string ApiService2(string Url, string Method = "GET", string RequestBody = null, string EmptyData = null)
        {
            StringContent JsonContent = null;
            var request = new HttpRequestMessage(new HttpMethod(Method), new Uri(Url));
            if (RequestBody != null)
            {
                JsonContent = new StringContent(RequestBody, Encoding.UTF8, "application/json");
                request.Content = JsonContent;
                //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.baptiste-preview+json"));//"application/vnd.github.nebula-preview+json"));
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.nebula-preview+json"));
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.baptiste-preview+json"));
                
            }
            var response = GitClient.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseString = response.Content.ReadAsStringAsync().Result;
                return responseString;
            }
            return null;

        }
        public string GetAccessToken(string body)
        {
            string clientId = System.Configuration.ConfigurationManager.AppSettings["ClientId"];
            string data = "";
          //  data.Replace("login/oauth/authorize?client_id={0}&scope=user%20public_repo", clientId);
            try
            {
                string baseAddress = "https://github.com/";
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(baseAddress)
                };


                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "login/oauth/access_token");
                //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, data);

                string requestContent = body;
                request.Content = new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded");

                HttpResponseMessage response = client.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;

                    char[] splitChars = { '&', '=' };
                    string Access_Token = result.Split(splitChars)[1];

                    return Access_Token;
                }
            }
            catch (Exception ex)
            {
                //log.Error("Method:" + MethodBase.GetCurrentMethod().Name + ", Line:" + LogService.getLine(ex) + ", Message:" + ex.Message);
            }
            return null;
        }
    }
}