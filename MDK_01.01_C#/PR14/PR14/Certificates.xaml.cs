using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PR14
{
    public partial class Certificates : Page
    {
        private List<string[]> _data =
            new List<string[]>();

        private int _indexNow = 0;
        public Certificates()
        {
            
            InitializeComponent();
            using (StreamReader file_r = new StreamReader("1.txt"))
            {
                while (!file_r.EndOfStream)
                {
                    string str = file_r.ReadLine();
                    _data.Add(str.Split("~").ToArray());
                }
                
            }
            updateInfo();
        }

        void updateInfo()
        {
            if (_data.Count - 1 < _indexNow)
                return;
            string[] arr = _data[_indexNow];
            FactoryName.Text = arr[0];
            Type.Text = "Вид машин: " + arr[1];
            Mark.Text = "Марка машин: " + arr[2];
            Price.Text = "Цена за одну: " + arr[3];
            Qnt.Text = "Количество: " + arr[4];
            Percent.Text = "Наценка: " + arr[6];
            // Cost.Text = "";
            Date.Text = "Дата: " + arr[5];
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _indexNow++;
            updateInfo();
        }
    }
}