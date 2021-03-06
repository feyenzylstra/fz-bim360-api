﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using FeyenZylstra.Bim360.Field.Serialization;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    public class FieldApiClient : IDisposable
    {
        private static readonly Uri BaseAddress = new Uri("https://bim360field.autodesk.com/");
        private readonly HttpClient _http;
        private readonly JsonSerializer _serializer;
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
            _serializer = new JsonSerializer();
            _serializer.Converters.Add(new GuidConverter());
            _serializer.DefaultValueHandling = DefaultValueHandling.Ignore;
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

        public async Task<IEnumerable<Company>> GetCompaniesAsync(Guid projectId)
        {
            var uri = new UriBuilder().Path("/fieldapi/admin/v1/companies").Build();
            var request = new GetCompaniesRequest()
            {
                Ticket = _ticket,
                ProjectId = projectId
            };

            var response = await _http.PostAsync(uri, await EncodeAsync(request));
            var content = await DecodeAsync<List<Company>>(response);

            return content;
        }

        public async Task<IEnumerable<TaskFilter>> GetTaskFiltersAsync(Guid projectId)
        {
            var uri = new UriBuilder().Path("/fieldapi/admin/v1/filters").Build();
            var request = new GetAdminFiltersRequest
            {
                Ticket = _ticket,
                ProjectId = projectId,
                Category = ContainerCategory.Task
            };

            var response = await _http.PostAsync(uri, await EncodeAsync(request));
            var content = await DecodeAsync<List<TaskFilter>>(response);

            return content;
        }

        /// <summary>
        /// Attempts to authenticate with the mobile API using BIM 360 Field credentials. 
        /// </summary>
        /// <param name="username">The username to authenticate as.</param>
        /// <param name="password">The password to authenticate with.</param>
        public async Task LoginAsync(string username, string password)
        {
            var uri = new UriBuilder().Path("/api/login").Build();
            var request = new LoginRequest { Username = username, Password = password };
            var response = await _http.PostAsync(uri, await EncodeAsync(request));

            if (!response.IsSuccessStatusCode)
                throw new FieldApiException("unauthorized");

            var content = await DecodeAsync<LoginResponse>(response);

            if (string.IsNullOrWhiteSpace(content.Ticket))
                throw new FieldApiException("empty authentication ticket");

            // cache auth ticket

            _ticket = Guid.Parse(content.Ticket);
        }

        /// <summary>
        /// Closes the current active session by expiring the ticket.
        /// </summary>
        public async Task LogoutAsync()
        {
            var uri = new UriBuilder().Path("/api/logout").Build();
            var request = new LogoutRequest { Ticket = _ticket.ToString() };
            var response = await _http.PostAsync(uri, await EncodeAsync(request));

            if (!response.IsSuccessStatusCode)
                throw new FieldApiException("logout failed");
        }

        public async Task<IEnumerable<ProjectTask>> GetTasksAsync(Guid projectId, Guid? filterId, PageOptions options = null)
        {
            if (options == null)
                options = PageOptions.GetDefault();

            var result = new List<ProjectTask>();
            var offset = options.Offset;

            while (true)
            {
                var tasks = await GetTasksAsync(projectId, filterId, offset, options.BatchSize);
                if (!tasks.Any())
                    break;
                offset += tasks.Count();
                result.AddRange(tasks);
                if (options.Limit != 0 && offset >= options.Limit)
                    break;
            }

            return result;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(Guid projectId)
        {
            var uri = new UriBuilder().Path("/fieldapi/admin/v1/users").Build();
            var request = new GetUsersRequest() { Ticket = _ticket, ProjectId = projectId };

            var response = await _http.PostAsync(uri, await EncodeAsync(request));

            if (!response.IsSuccessStatusCode)
                throw new FieldApiException("failed to retrieve users");

            var content = await DecodeAsync<List<User>>(response);
            return content;
        }

        public async Task<IEnumerable<ProjectTask>> GetTasksAsync(Guid projectId, Guid? filterId, int offset, int limit)
        {
            var uri = new UriBuilder().Path("/api/get_tasks").Build();
            var request = new GetTasksRequest
            {
                Ticket = _ticket,
                ProjectId = projectId,
                FilterId = filterId,
                Offset = offset,
                Limit = limit
            };

            var response = await _http.PostAsync(uri, await EncodeAsync(request));

            if (!response.IsSuccessStatusCode)
                throw new FieldApiException("failed to retrieve tasks");

            var content = await DecodeAsync<List<ProjectTask>>(response);
            return content;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var uri = new UriBuilder().Path("/api/projects").Build();
            var request = new FieldRequest { Ticket = _ticket };
            var response = await _http.PostAsync(uri, await EncodeAsync(request));

            if (!response.IsSuccessStatusCode)
                throw new FieldApiException("failed to retrieve projects");

            var content = await DecodeAsync<List<Project>>(response);

            return content;
        }

        private async Task<T> DecodeAsync<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            using (var reader = new JsonTextReader(new StringReader(content)))
                return _serializer.Deserialize<T>(reader);
        }

        private async Task<StringContent> EncodeAsync<T>(T value)
        {
            using (var swriter = new StringWriter())
            using (var writer = new JsonTextWriter(swriter))
            {
                _serializer.Serialize(writer, value);
                await swriter.FlushAsync();
                return new StringContent(swriter.ToString(), Encoding.UTF8, "application/json");
            }
        }

        
    }
}
