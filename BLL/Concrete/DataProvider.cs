using System;
using System.Collections.Generic;
using System.IO;
using BLL.Interface;

namespace BLL.Concrete
{
    public sealed class DataProvider : IDataProvider<string>
    {
        private readonly FileInfo _file;

        public DataProvider(FileInfo file)
        {
            _file = file ?? throw new ArgumentNullException(nameof(file));
        }

        public IEnumerable<string> GetAll()
        {
            List<string> result = new List<string>();

            using (StreamReader reader = new StreamReader(_file.FullName))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }

            return result;
        }
    }
}
