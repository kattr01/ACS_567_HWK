using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;
using System.Xml.Linq;

namespace HW2
{
	public class StoreItemsRepository
	{
        private static StoreItemsRepository? instance;
        private List<StoreItems> dataList;
        private static string? filePath;

        public StoreItemsRepository()
		{
            filePath = "./Testing.txt";


        }
        public static StoreItemsRepository getInstance()
        {
            if (instance == null) {
                instance = new StoreItemsRepository();
            }
            return instance;
        }

        public List<StoreItems> GetStore()
        {
            dataList = new List<StoreItems>();
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        //read line and split by ','
                        string[] line = sr.ReadLine().Split(',');
                        string[] format = { "mm/dd/yyyy" };
                        dataList.Add(new StoreItems(int.Parse(line[0]), line[1], line[2], line[3], double.Parse(line[4])));
                    }
                }
            }
            return dataList;
        }
        public StoreItems GetStore(int id)
        {


            GetStore();
   
            return dataList.Find(x => x.Id == id);
        }
        public bool AddDataToFile(StoreItems store)
        {
       
            File.AppendAllText(filePath, store.Id + ',' + store.Name + ',' + store.Description + ',' + store.Category + ',' + store.Cost + Environment.NewLine);

            return true;
        }
        public bool DeleteLine(int id)
        {

            GetStore();
            dataList.Remove(dataList.Find(x => x.Id == id));
            writerFile(dataList);

            return true;
        }
        public bool UpdateLine(int id,StoreItems store)
        {
            GetStore();
           
            int p =dataList.FindIndex(x => x.Id == id);

            dataList[p] = store;
            writerFile(dataList);

            return true;
        }

        public void writerFile(List<StoreItems> dataList)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (StoreItems cp in dataList)
                    sw.WriteLine(cp.Id + ',' + cp.Name + ',' + cp.Description + ',' + cp.Category + ',' + cp.Cost);
            }
        }
        public string Analyse(string type)
        {

            GetStore();
            double temp =0;
            string desc;
            if (type.ToUpper() == "AVG") {
                temp = dataList.Average(x => x.Cost);
                desc = "Average Bill Value: ";
            }
            else
            {
                temp = dataList.Sum(x => x.Cost);
                desc = "Total Bill Value: ";
            }
            return desc+temp;
        }
        // public int Analysis(
    }
}

