using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СrsWork
{
    class SampleRow
    {
        public string Name { get; set; } //обязательно нужно использовать get конструкцию
        public int Number { get; set; }
        public string Addres { get; set; }
        public int Cash { get; set; }
        public int Contract { get; set; }

        public string Hidden = ""; //Данное свойство не будет отображаться как колонка

        public SampleRow(string name,int number,int cash, string addres,int contract)
        {
            this.Name = name;
            this.Number = number;
            this.Addres = addres;
            this.Cash = cash;
            this.Contract = contract;
            
        }
    }
}
