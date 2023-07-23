﻿using ConsumeNow.Subpages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConsumeNow
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        LebensmittelPage lebensmittelpage = new LebensmittelPage();
        EinkaufslistePage einkaufslistepage = new EinkaufslistePage();
        ÜbersichtPage übersichtpage = new ÜbersichtPage();

        LebensmittelAddPage lebensmitteladdpage = new LebensmittelAddPage();
        EinkaufslisteAddPage einkaufslisteaddpage = new EinkaufslisteAddPage();
        CategoryAddPage categoryaddpage = new CategoryAddPage();   
        
        List<Entry> entries = new List<Entry>();

        public void ButtonClick(object sender, RoutedEventArgs e)
        {
            string senderName = (sender as Button).Name;
            switch (senderName)
            {
                case "LebensmittelButton":
                    CC.Content = lebensmittelpage;                 
                    break;
                case "EinkaufslisteButton":
                    CC.Content = einkaufslistepage;
                    break;
                case "ÜbersichtButton":
                    CC.Content = übersichtpage;
                    break;
                case "AddLebensmittelButton":
                    CC.Content = lebensmitteladdpage;
                    break;
                case "AddEinkaufButton":
                    CC.Content = einkaufslisteaddpage;
                    break;
                case "AddTypButton":
                    CC.Content = categoryaddpage;
                    break;
                default: break;
            }

        }
    }
}
