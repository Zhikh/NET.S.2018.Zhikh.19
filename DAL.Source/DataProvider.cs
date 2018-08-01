using System;
using System.Collections.Generic;
using System.IO;
using DAL.Source.Interface;

namespace DAL.Source
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
            using (StreamReader reader = new StreamReader(_file.FullName))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
