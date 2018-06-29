using System;
using System.Collections.Generic;
using System.Text;

namespace PathOfLowestCost.Models
{
    public class ResultItem
    {
        public bool CompletePath { get; set; }
        public int TotalCost { get; set; }
        public string Path { get; set; }

        public ResultItem(bool commplete, int cost, string path)
        {
            CompletePath = commplete;
            TotalCost = cost;
            Path = path;
        }

        public ResultItem()
        {

        }
    }
}
