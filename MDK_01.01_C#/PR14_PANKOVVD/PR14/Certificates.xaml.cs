using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CarEngine;

namespace PR14
{
    public partial class Certificates : Page
    {
        private int _indexNow;

        public Certificates()
        {
            InitializeComponent();
            if (EngineData.EngineList.Count != 0)
                DataContext = EngineData.EngineList[0];
            else ;
        }

        public Certificates(int indexNow) : this()
        {
            _indexNow = indexNow;
            DataContext = EngineData.EngineList[_indexNow];
        }

        private void nextEngine(object sender, RoutedEventArgs e)
        {
            if (EngineData.EngineList.Count - 1 < _indexNow)
                return;
            DataContext = EngineData.EngineList[++_indexNow];
        }

        private void backEngine(object sender, RoutedEventArgs e)
        {
            if (EngineData.EngineList.Count - 1 < _indexNow)
                return;
            DataContext = EngineData.EngineList[--_indexNow];
        }
    }
}