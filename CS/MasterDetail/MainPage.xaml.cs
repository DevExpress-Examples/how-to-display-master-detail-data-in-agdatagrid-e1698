﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.IO;
using System.Globalization;
using System.Windows.Data;

namespace MasterDetail
{
    public partial class MainPage : UserControl
    {
        public MainPage() {
            InitializeComponent();
            masterGrid.DataSource = CategoriesData.DataSource;
        }
    }
}
