using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ThirdParty
{
    class ReadjsonAndWriteCsv
    {
        public static void ImplementJSONInCSV()
        {
            string importFilePath = @"E:\third\ThirdParti\ThirdParty\ThirdParty\utility\export.json";
            string exportFilePath = @"E:\third\ThirdParti\ThirdParty\ThirdParty\utility\Jsondata.csv";

            IList<AddressData> addressData = JsonConvert.DeserializeObject<IList<AddressData>>(File.ReadAllText(importFilePath));

            using var writer = new StreamWriter(exportFilePath);
            using var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvExport.WriteRecords(addressData);
        }
    }
}