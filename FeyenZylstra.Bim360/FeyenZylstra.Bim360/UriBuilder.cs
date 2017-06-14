using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeyenZylstra.Bim360
{
    public class UriBuilder
    {
        private readonly IDictionary<string, string> _params;
        private Uri _base;
        private string _path;

        public UriBuilder()
        {
            _params = new Dictionary<string, string>();
        }

        public UriBuilder Reset()
        {
            _params.Clear();
            return this;
        }

        public UriBuilder BaseAddress(Uri uri)
        {
            _base = uri;
            return this;
        }

        public UriBuilder BaseAddress(string uri)
        {
            _base = new Uri(uri);
            return this;
        }

        public UriBuilder Path(params object[] args)
        {
            if (args != null)
            {
                _path = string.Join("/", args.Select(x => x.ToString()));
            }
            return this;
        }

        public UriBuilder Path(string value)
        {
            _path = value ?? string.Empty;
            return this;
        }

        public UriBuilder Query(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _params.Add(key, value);
            return this;
        }
        
        public Uri Build()
        {
            var builder = new StringBuilder();

            if (_base != null)
                builder.Append(_base.ToString());

            if (_path != null)
                builder.Append(_path);

            var queryParameters =
                string.Join("&",
                    _params.Select(x => string.Format("{0}={1}",
                        Uri.EscapeDataString(x.Key), Uri.EscapeDataString(x.Value))));

            if (!string.IsNullOrWhiteSpace(queryParameters))
            {
                builder.Append("?");
                builder.Append(queryParameters);
            }

            return new Uri(builder.ToString(), UriKind.RelativeOrAbsolute);
        }
    }
}
