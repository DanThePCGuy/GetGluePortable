using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GetGluePortable.Model;
using GetGluePortable.Utilities;
using Newtonsoft.Json;
using Object = GetGluePortable.Model.Object;

namespace GetGluePortable
{
    public class GetGlueClient
    {
        #region Fields

        private readonly HttpClient _httpClient;

        private const string BaseUrl = "https://api.getglue.com/";

        private const string AuthorisationEndPoint = "oauth2/authorize";

        private const string AuthorisationAccessTokenEndPoint = "oauth2/access_token";

        #endregion

        #region Properties

        public string ClientId { get; private set; }

        public string ClientSecret { get; private set; }

        public string AccessToken { get; internal set; }

        #endregion

        #region Constructors

        public GetGlueClient(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", clientId);
        }

        #endregion

        #region Authorization

        // <summary>
        // Gets the Authentication Url
        // </summary>
        // <returns>The Authentication Url</returns>
        public string GetAuthenticationUrl()
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("response_type", "code"),
                new KeyValuePair<string, string>("client_id", ClientId)
            };

            return new Uri(string.Format("{0}{1}", BaseUrl, AuthorisationEndPoint)).ToQueryString(parameters).AbsoluteUri;
        }

        // <summary>
        // Gets the Acess Token
        // </summary>
        // <param name="code">The Authentication code</param>
        // <returns>The Access Token</returns>
        public async Task<AccessToken> GetAccessTokenAsync(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("code", "Code cannot be null or empty");

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("client_id", ClientId),
                new KeyValuePair<string, string>("client_secret", ClientSecret)
            };


            return await GetResponseAsync<AccessToken>(AuthorisationAccessTokenEndPoint, parameters);
        }

        // <summary>
        // Gets the Access Token
        // </summary>
        // <param name="refreshToken">The Refresh Token</param>
        // <returns>The Access Token</returns>
        public async Task<AccessToken> GetRefreshTokenAsync(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
                throw new ArgumentNullException("refreshToken", "Refresh Token cannot be null or empty");

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", ClientId),
                new KeyValuePair<string, string>("client_secret", ClientSecret),
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("refresh_token", refreshToken),
            };

            return await GetResponseAsync<AccessToken>(AuthorisationAccessTokenEndPoint, parameters);
        }

        // <summary>
        // Sets the Access Token
        // </summary>
        // <param name="accessToken">The Access Token</param>
        public void SetAccessToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException("accessToken", "Access Token cannot be null or empty");

            AccessToken = accessToken;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        #endregion

        #region User

        // <summary>
        // Gets the User
        // </summary>
        // <param name="userId">The User Identifier</param>
        // <returns>The User</returns>
        public async Task<User> GetUserAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException("userId", "User Id cannot be null or empty");

            var response = await GetResponseAsync<Response>(string.Format("v3/{0}", userId));

            return response.User;
        }

        // <summary>
        // Gets the User's friends
        // </summary>
        // <param name="userId">The User Identifier</param>
        // <returns>The User's friends</returns>
        public async Task<Users> GetUserFriendsAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException("userId", "User Id cannot be null or empty");

            return await GetResponseAsync<Users>(string.Format("v3/{0}/friends", userId));
        }

        // <summary>
        // Gets the User's followers
        // </summary>
        // <param name="userId">The User Identifier</param>
        // <returns>The User's followers</returns>
        public async Task<Users> GetUserFollowersAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException("userId", "User Id cannot be null or empty");

            return await GetResponseAsync<Users>(string.Format("v3/{0}/followers", userId));
        }

        #endregion

        #region Object

        public async Task<Object> GetObjectAsync(string objectId, GetGlueObjectType objectType)
        {
            if (string.IsNullOrEmpty(objectId))
                throw new ArgumentNullException("objectId", "Object Id cannot be null or empty");

            var objectTypePath = GetObjectType(objectType);

            var response = await GetResponseAsync<Response>(string.Format("v3/{0}/{1}", objectTypePath, objectId));

            return response.Object;
        }

        public async Task<Objects> SearchObjectsAsync(string query, GetGlueObjectType objectType)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentNullException("query", "Query cannot be null or empty");

            var objectTypePath = GetObjectType(objectType);

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("category", objectTypePath),
                new KeyValuePair<string, string>("q", query)
            };

            var response = await GetResponseAsync<Response>("v4/search/objects", parameters);

            return response.Objects;
        }

        public async Task<Interactions> GetObjectFeedAsync(string objectId, GetGlueObjectType objectType)
        {
            if (string.IsNullOrEmpty(objectId))
                throw new ArgumentNullException("objectId", "Object Id cannot be null or empty");

            var objectTypePath = GetObjectType(objectType);

            return await GetResponseAsync<Interactions>(string.Format("v3/{0}/{1}/feed?limit=100", objectTypePath, objectId));
        }

        public async Task<Objects> GetTrendingObjects(GetGlueObjectType objectType)
        {
            var objectTypePath = GetObjectType(objectType);

            return await GetResponseAsync<Objects>(string.Format("v3/guide/trending/{0}", objectTypePath));
        }

        public async Task<bool> CheckinObjectAsync(string objectId, GetGlueObjectType objectType, string comment = null)
        {
            if (string.IsNullOrEmpty(objectId))
                throw new ArgumentNullException("objectId", "Object Id cannot be null or empty");

            var objectTypePath = GetObjectType(objectType);

            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("comment", comment)
            });

            var response = await PostResponseAsync<Interaction>(string.Format("v3/{0}/{1}/checkins", objectTypePath, objectId), content);

            return !string.IsNullOrEmpty(response.Id);
        }

        public async Task<bool> LikeObjectAysnc(string objectId, GetGlueObjectType objectType)
        {
            if (string.IsNullOrEmpty(objectId))
                throw new ArgumentNullException("objectId", "Object Id cannot be null or empty");

            var objectTypePath = GetObjectType(objectType);

            var response = await PostResponseAsync<Interaction>(string.Format("v3/{0}/{1}/likes", objectTypePath, objectId), null);

            return !string.IsNullOrEmpty(response.Id);
        }

        private static string GetObjectType(GetGlueObjectType objectType)
        {
            switch (objectType)
            {
                case GetGlueObjectType.TvShows:
                    return "tv_shows";
                case GetGlueObjectType.Movies:
                    return "movies";
                case GetGlueObjectType.Games:
                    return "games";
                case GetGlueObjectType.Sports:
                    return "sports";
            }

            throw new ArgumentException("Unknown object type");
        }

        #endregion

        #region Guide

        public async Task<Providers> GetProvidersAsync(string latitude, string longitude)
        {
            if (string.IsNullOrEmpty(latitude))
                throw new ArgumentNullException("latitude", "Latitude cannot be null or empty");

            if (string.IsNullOrEmpty(longitude))
                throw new ArgumentNullException("longitude", "Longitude Id cannot be null or empty");

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("longitude", longitude),
                new KeyValuePair<string, string>("latitude", latitude)
            };

            var response = await GetResponseAsync<Response>("tms/api/providers/list", parameters);

            return response.Providers;
        }

        public async Task<Shows> GetGuideAsync(string provider)
        {
            if (string.IsNullOrEmpty(provider))
                throw new ArgumentNullException("provider", "Provider cannot be null or empty");

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("provider", provider)
            };

            return await GetResponseAsync<Shows>("v3/guide", parameters);
        }

        #endregion

        #region Interaction

        public async Task<Interaction> GetInteractonAsync(string interactionId)
        {
            var response = await GetResponseAsync<Response>(string.Format("v3/{0}", interactionId));

            return response.Interaction;
        }

        public async Task<Votes> GetInteractonVotesAsync(string interactionId)
        {
            return await GetResponseAsync<Votes>(string.Format("v3/{0}/votes", interactionId));
        }

        public async Task<Comments> GetInteractonCommentsAsync(string interactionId)
        {
            return await GetResponseAsync<Comments>(string.Format("v3/{0}/replies", interactionId));
        }

        #endregion

        #region Web Calls

        private async Task<T> GetResponseAsync<T>(string path, List<KeyValuePair<string, string>> paramaters = null)
        {
            var url = new Uri(string.Format("{0}{1}", BaseUrl, path));

            if (paramaters != null)
                url = url.ToQueryString(paramaters);

            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string responseUri = response.RequestMessage.RequestUri.ToString();

            var json = await response.Content.ReadAsStringAsync();

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));
        }

        private async Task<T> PostResponseAsync<T>(string path, HttpContent content)
        {
            var url = new Uri(string.Format("{0}{1}", BaseUrl, path));

            var response = await _httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));
        }

        #endregion

        //Test Area to return stuff as plain data
        public async Task<string> Test(string s)
        {
            var response = await _httpClient.GetAsync("http://api.getglue.com/v3?access_token=" + s);

            var linkHeader =  response.Headers.GetValues("Link").FirstOrDefault();

            LinkHeader.Parse(linkHeader);

            return string.Empty;
        }
    }
}