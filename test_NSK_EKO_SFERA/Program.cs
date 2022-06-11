using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace test_NSK_EKO_SFERA
{
    class Program
    {
        static void Main(string[] args)
        {
            
            if (args.Length < 1 || args.Length > 2)
            {
                Console.WriteLine("error");
                Environment.Exit(-1);
            }
            try
            {   
                List<Bara> DateSetFirstFile = new List<Bara>();
                if (args.Length > 1)
                {
                    string[] line;
                    StreamReader file_first = new StreamReader(args[0]);
                    string headline = file_first.ReadLine();
                    while (file_first.Peek() >= 0)
                    {
                        line = file_first.ReadLine().Split(',');
                        Bara tmp = new Bara(line[0], line[1], line[2], line[3], double.Parse(line[4], CultureInfo.InvariantCulture), double.Parse(line[5], CultureInfo.InvariantCulture), double.Parse(line[6], CultureInfo.InvariantCulture), double.Parse(line[7], CultureInfo.InvariantCulture), Convert.ToInt32(line[8]));
                        DateSetFirstFile.Add(tmp);
                    }
                    StreamWriter FileDateSetMaxMin = new StreamWriter(Path.GetDirectoryName(args[0]) + "\\FileDateSetMaxMin.txt");
                    StreamWriter FileDataSetHighLow = new StreamWriter(Path.GetDirectoryName(args[0]) + "\\DileDataSetHighLow.txt");
                    FileDateSetMaxMin.WriteLine(headline);
                    FileDataSetHighLow.WriteLine(headline);
                    int maxday = 0;
                    int minday = 0;
                    Double maxvalueday = DateSetFirstFile[0]._sellHigh;
                    Double minvalueday = DateSetFirstFile[0]._sellLow;
                    DateTime day = DateSetFirstFile[0]._Date;
                    int minhouer = 0;
                    int maxgouer = 0;
                    Double maxvaluerhouer = 0;
                    Double minvaluerhouer = 0;
                    DateTime houer = DateSetFirstFile[0]._Date;
                    for(int i = 0; i < DateSetFirstFile.Count; i++)
                    {
                        if ((DateSetFirstFile[i]._Date - day).TotalHours >= 24)
                        {
                            FileDateSetMaxMin.WriteLine(DateSetFirstFile[minday].ConvertToCsvString());
                            FileDateSetMaxMin.WriteLine(DateSetFirstFile[maxday].ConvertToCsvString());
                            maxday = i;
                            minday = i;
                            maxvalueday = DateSetFirstFile[i]._sellHigh;
                            maxvalueday = DateSetFirstFile[i]._sellLow;
                            day = DateSetFirstFile[i]._Date;
                        }
                        if (DateSetFirstFile[i]._sellHigh > maxvalueday)
                        {
                            maxday = i;
                            maxvalueday = DateSetFirstFile[i]._sellHigh;
                        }
                        if (DateSetFirstFile[i]._sellLow > minvalueday)
                        {
                            minday = i;
                            minvalueday = DateSetFirstFile[i]._sellLow;
                        }
                        if ((DateSetFirstFile[i]._Date - houer).TotalHours >= 1)
                        {
                            string z = DateSetFirstFile[minhouer].ConvertToCsvString();
                            string z2 = DateSetFirstFile[maxgouer].ConvertToCsvString();
                            FileDataSetHighLow.WriteLine(z);
                            FileDataSetHighLow.WriteLine(z2);
                            minhouer = i;
                            maxgouer = i;
                            maxvaluerhouer = DateSetFirstFile[i]._sellOpen;
                            minvaluerhouer = DateSetFirstFile[i]._sellClose;
                            houer = DateSetFirstFile[i]._Time;
                        }
                        if (DateSetFirstFile[i]._sellOpen > maxvalueday)
                        {
                            maxday = i;
                            maxvalueday = DateSetFirstFile[i]._sellHigh;
                        }
                        if (DateSetFirstFile[i]._sellClose > minvalueday)
                        {
                            minday = i;
                            minvalueday = DateSetFirstFile[i]._sellLow;
                        }
                    }
                    FileDateSetMaxMin.Close();
                    FileDataSetHighLow.Close();
                }
                List<Bara> DateSetSecondFile = new List<Bara>();
                if (args.Length == 2)
                {
                    StreamReader file_second = new StreamReader(args[1]);
                    string[] line;
                    string headline = file_second.ReadLine();
                    while (file_second.Peek() >= 0)
                    {
                        line = file_second.ReadLine().Split(',');
                        Bara tmp_bara = new Bara(line[0], line[1], line[2], line[3], double.Parse(line[4], CultureInfo.InvariantCulture), double.Parse(line[5], CultureInfo.InvariantCulture), double.Parse(line[6], CultureInfo.InvariantCulture), double.Parse(line[7], CultureInfo.InvariantCulture), Convert.ToInt32(line[8]));
                        DateSetSecondFile.Add(tmp_bara);
                    }
                    StreamWriter NewString = new StreamWriter(Path.GetDirectoryName(args[1]) + "\\NewString.txt");
                    StreamWriter LostString = new StreamWriter(Path.GetDirectoryName(args[1]) + "\\LostString.txt");
                    StreamWriter UniqueString = new StreamWriter(Path.GetDirectoryName(args[1]) + "\\UniqueString.txt");
                    NewString.WriteLine(headline);
                    LostString.WriteLine(headline);
                    UniqueString.WriteLine(headline);
                    List<Bara> tmp = DateSetFirstFile;
                    List<Bara> tmp2 = DateSetSecondFile;
                    List<Bara> tmp3 = new List<Bara>();
                    for (int i = 0; i < tmp2.Count; i++)
                    {
                        if (!tmp.Contains(tmp2[i]))
                            NewString.WriteLine(tmp2[i].ConvertToCsvString());
                    }
                    foreach (var obj in tmp)
                    {
                        if (!tmp2.Contains(obj))
                            LostString.WriteLine(obj.ConvertToCsvString());
                        if (tmp2.Contains(obj) && !tmp3.Contains(obj))
                            tmp3.Add(obj);
                    }
                    NewString.Close();
                    LostString.Close();
                    UniqueString.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
            }

        }
    }
}
