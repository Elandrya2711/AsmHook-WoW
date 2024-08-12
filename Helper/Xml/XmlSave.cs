using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tanaris.Helper.Xml
{
    internal class XmlSave
    {
        public static void SaveData(object IClass, string filename)
        {
            StreamWriter writer = null;
            try
            {

                XmlSerializer xmlSerializer = new XmlSerializer((IClass.GetType()));
                writer = new StreamWriter(filename);
                xmlSerializer.Serialize(writer, IClass);
            }
            catch (Exception e)
            {
            }
            finally
            {
                if (writer != null)
                    writer.Close();
                writer = null;
            }
        }
    }
}
