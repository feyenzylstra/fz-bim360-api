using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    public class FieldApiClient : IDisposable
    {
        private static readonly Uri BaseAddress = new Uri("https://bim360field.autodesk.com/");
        private readonly HttpClient _http;
        private bool _disposed;
        private Guid _ticket;

        public TimeSpan Timeout
        {
            get { return _http.Timeout; }
            set { _http.Timeout = value; }
        }

        public FieldApiClient()
        {
            _http = new HttpClient();
            _http.BaseAddress = BaseAddress;
            _http.Timeout = TimeSpan.FromSeconds(3);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _disposed = true;
                _http.Dispose();
            }
        }

        public async Task LoginAsync(string username, string password)
        {
            var uri = new UriBuilder().Path("/api/login").Build();
            var request = new LoginRequest { Username = username, Password = password };
            var response = await _http.PostAsync(uri, Encode(request));

            if (!response.IsSuccessStatusCode)
                throw new FieldApiException("unauthorized");

            var content = await DecodeAsync<LoginResponse>(response);

            if (string.IsNullOrWhiteSpace(content.Ticket))
                throw new FieldApiException("empty authentication ticket");

            // cache auth ticket

            _ticket = Guid.Parse(content.Ticket);
        }

        public async Task LogoutAsync()
        {
            var uri = new UriBuilder().Path("/api/logout").Build();
            var request = new LogoutRequest { Ticket = _ticket.ToString() };
            var response = await _http.PostAsync(uri, Encode(request));

            if (!response.IsSuccessStatusCode)
                throw new FieldApiException("logout failed");
        }

        private static async Task<T> DecodeAsync<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            var decoded = JsonConvert.DeserializeObject<T>(content);

            return decoded;
        }

        private static StringContent Encode<T>(T value)
        {
            var encoded = JsonConvert.SerializeObject(value, Formatting.None);
            var content = new StringContent(encoded, Encoding.UTF8, "application/json");

            return content;
        }

        
    }
}
