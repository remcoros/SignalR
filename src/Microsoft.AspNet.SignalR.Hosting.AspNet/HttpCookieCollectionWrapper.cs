﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

using System.Web;

namespace Microsoft.AspNet.SignalR.Hosting.AspNet
{
    internal class HttpCookieCollectionWrapper : IRequestCookieCollection
    {
        private readonly HttpCookieCollection _cookies;

        public HttpCookieCollectionWrapper(HttpCookieCollection cookies)
        {
            _cookies = cookies;
        }

        public Cookie this[string name]
        {
            get { return ToSignalRCookie(_cookies[name]); }
        }

        public int Count
        {
            get { return _cookies.Count; }
        }

        private static Cookie ToSignalRCookie(HttpCookie source)
        {
            if (source == null)
            {
                return null;
            }

            return new Cookie(
                source.Name,
                source.Value,
                source.Domain,
                source.Path
            );
        }
    }
}
