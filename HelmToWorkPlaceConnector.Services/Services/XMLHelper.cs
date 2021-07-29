using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace HelmToWorkPlaceConnector.Services.Services
{
   public static class XMLHelper
    {

        public static string SerializeToXml(object input)
        {
            XmlSerializer ser = new XmlSerializer(input.GetType(), "http://schemas.yournamespace.com");
            string result = string.Empty;

            using (MemoryStream memStm = new MemoryStream())
            {
                ser.Serialize(memStm, input);

                memStm.Position = 0;
                result = new StreamReader(memStm).ReadToEnd();
            }

            return result;
        }
    }
}
