using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using to.Models;

namespace to.Storage
{
    public class FileStorage : MemCache, IStorage<lr1Data>
    {
        private Timer _timer;

        public string FileName { get; }
        public int FlushPeriod { get; }

        public FileStorage(string fileName, int flushPeriod)
        {
            FileName = fileName;
            FlushPeriod = flushPeriod;

            Load();

            _timer = new Timer((x) => Flush(), null, flushPeriod, flushPeriod);
        }

        private void Load()
        {
            if (File.Exists(FileName))
            {
                var allLines = File.ReadAllText(FileName);

                try
                {
                    var deserialized = JsonConvert.DeserializeObject<List<lr1Data>>(allLines);

                    if (deserialized != null)
                    {
                        foreach (var labData in deserialized)
                        {
                            base[labData.Id] = labData;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new FileLoadException($"Cannot load data from file {FileName}:\r\n{ex.Message}");
                }
            }
        }
         public string StorageType => $"{nameof(FileStorage)}";
        private void Flush()
        {
            var serializedContents = JsonConvert.SerializeObject(All);

            File.WriteAllText(FileName, serializedContents);
        }
    }
}