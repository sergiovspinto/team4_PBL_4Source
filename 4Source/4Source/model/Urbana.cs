﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _4Source
{
    [Serializable()]
    class Urbana : IClassificacao
    {
        double area;
        int valorBase = 10;
        double areaConst;
        double indiceCont;
        DateTime dataConst;
        string tipologia;

        public Urbana()
        {

        }
       

        public Urbana(double indiceCont, string tipologia, double areaConst, DateTime dataConst, double area)
        {
            this.indiceCont = indiceCont;
            this.tipologia = tipologia;
            this.areaConst = areaConst;
            this.dataConst = dataConst;
            this.area = area;
        }

        public override string ToString()
        {
            return "Urbana\nTipo: " + tipologia + "\nArea de construção: " + areaConst + "\nData de construção " + dataConst.ToString("dd/MM/yyyy");
        }

        public double CalcIMI()
        {
            double IMI = indiceCont * valorBase + (areaConst / area * 0.05);
            return IMI;
        }


        public string GetClassificacao()
        {
            return "Urbana";
        }
        public double GetIndiceCont()
        {
            return indiceCont;
        }
        public string GetUso()
        {
            return "PPHARD";
        }

        public DateTime GetData()
        {
            return this.dataConst;
        }

       
        }
    }

