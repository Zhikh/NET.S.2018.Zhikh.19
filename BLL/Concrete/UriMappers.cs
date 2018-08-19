using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Concrete
{
    public static class UriMappers
    {
        /// <summary>
        /// Mappers <see cref="Uri"/> in <see cref="UrlAddress"/>
        /// </summary>
        /// <param name="uri"> Entity for mapping from </param>
        /// <returns> Entity of <see cref="UrlAddress"/> </returns>
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

            var result = new UrlAddress
            {
                HostName = uri.Host,
                ParametrValue = value,
                ParametrKey = key,
                Segments = new List<string>()
            };

            string tempSegment = "";
            foreach (var segment in uri.Segments)
            {
                var index = segment.IndexOf('/');
                if (index >= 0)
                {
                    tempSegment = segment.Remove(index);
                }

                if (tempSegment != string.Empty)
                {
                    result.Segments.Add(tempSegment);
                }
            }

            return result;
        }

        /// <summary>
        /// Mappers collection of <see cref="Uri"/> in collection of <see cref="UrlAddress"/>
        /// </summary>
        /// <param name="uri"> Entities for mapping from </param>
        /// <returns> Entities of <see cref="UrlAddress"/> </returns>
        public static IEnumerable<UrlAddress> ToMany(this IEnumerable<Uri> uris)
        {
            foreach (var uri in uris)
            {
                yield return ToUrlAddress(uri);
            }
        }

    }
}
