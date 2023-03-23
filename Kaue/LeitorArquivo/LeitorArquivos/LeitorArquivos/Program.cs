var path = @"C:\Users\kauey\OneDrive\Área de Trabalho\KAUE2.csv";

StreamReader sr = null;

sr = new StreamReader(path);
Console.WriteLine(sr.ReadToEnd());

sr.Close();
