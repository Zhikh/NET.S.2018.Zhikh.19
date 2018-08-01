using DAL.Destination.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Mappers
{
    public static class UriMappers
    {
        public static UrlAddress ToUrlAddress(this Uri uri)
        {
            string query = uri.Query;
            string[] parameters = query.Split('=');

            string value = null;
            string key = null;
            
            if (parameters != null)
            {
                value = parameters[0];

                if (parameters.Count() == 2)
                {
                    key = parameters[1];
                }
            }

            return new UrlAddress
            {
                HostName = uri.Host,
                Segments = uri.Segments,
                ParametrValue = value,
                ParametrKey = key
            };
        }

        public static IEnumerable<UrlAddress> ToUrlAddress(this IEnumerable<Uri> uris)
        {
            foreach (var uri in uris)
            {
                yield return ToUrlAddress(uri);
            }
        }
    }
}
