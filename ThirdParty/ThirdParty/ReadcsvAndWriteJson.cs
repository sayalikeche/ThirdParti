using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ThirdParty
{
    class ReadcsvAndWriteJson
    {
        public static void ImplementCSVInJSON()
        {
            string importFilePath = @"E:\third\ThirdParti\ThirdParty\ThirdParty\utility\Jsondata.csv";
            string exportFilePath = @"E:\third\ThirdParti\ThirdParty\ThirdParty\utility\export.json";

            using var reader = new StreamReader(importFilePath); // Readaing CSV File
            using var csv = new CsvReader(reader, CultureInfo.CurrentCulture);
            var records = csv.GetRecords<AddressData>().ToList();
            foreach (AddressData addressData in records)
            {
                Console.Write("\t" + addressData.firstname + "\t" + addressData.lastname + "\t" +
                   addressData.address + "\t" + addressData.city + "\t" + addressData.state + "\t" + addressData.code);
            }
            JsonSerializer serializer = new JsonSerializer();
            using StreamWriter sw = new StreamWriter(exportFilePath); // Writing Json File
            using JsonWriter writer = new JsonTextWriter(sw);
            serializer.Serialize(writer, records);
        }
    }
}