﻿using System;
using System.Linq;
using System.Web;

namespace BM.DemoWeb.ViewModels
{
    public class GadgetFormViewModel
    {
        public HttpPostedFileBase File { get; set; }
        public string GadgetTitle { get; set; }
        public string GadgetDescription { get; set; }
        public decimal GadgetPrice { get; set; }
        public int GadgetCategory { get; set; }
    }
}