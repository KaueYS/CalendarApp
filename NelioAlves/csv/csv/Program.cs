using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        {
            string filePath = @"C:\Users\kauey\OneDrive\Documentos\DemonstrativoUnimed2023\KAUEUnimed.csv";
            string text = File.ReadAllText(filePath);
            text = text.Replace(";", ",");
            text = text.Replace(",,", ",");
            File.WriteAllText(filePath, text);

        }
    }
}


//        List<Data> dataList = new List<Data>();

//        using (StreamReader reader = new StreamReader(filePath))
//        {
//            while (!reader.EndOfStream)
//            {
//                string line = reader.ReadLine();
//                string[] values = line.Split(',');

//                Data data = new Data
//                {
//                    Column1 = values[0],
//                    Column2 = values[1],
//                    Column3 = values[2],
//                    Column4 = values[3],
//                    Column5 = values[4]
//                };

//                dataList.Add(data);
//            }
//        }
//    }
//}

//class Data
//{
//    public string Column1 { get; set; }
//    public string Column2 { get; set; }
//    public string Column3 { get; set; }
//    public string Column4 { get; set; }
//    public string Column5 { get; set; }
//}