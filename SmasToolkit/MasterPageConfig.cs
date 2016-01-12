using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit
{
    class MasterPageConfig
    {
        public string PageId{get; set;}
        public string Title{get; set;}
        List<IHtmlTag> Buttons = new List<IHtmlTag>();
        List<IHtmlTag> QueryConditions = new List<IHtmlTag>();

        public string Sql { get; set; }
        public string OrderBy { get; set; }
        public string DetailSql { get; set; }

        private bool _ChkBox; // ChkBox="N"
        public bool ChkBox
        {
            get
            {
                return _ChkBox;
            }
            set
            {
                _ChkBox = value;
            }
        }

        private string[] _Gridwidth; // gridwidth="20%,20%,30%"
        public string[] Gridwidth
        {
            get
            {
                return _Gridwidth;
            }
            set
            {
                _Gridwidth = value;
            }
        }

        private string[] _Hidecolumn; // hidecolumn=""
        public string[] Hidecolumn
        {
            get
            {
                return _Hidecolumn;
            }
            set
            {
                _Hidecolumn = value;
            }
        }

        private string[] _TextAlign; // TextAlign="L,C,L"
        public string[] TextAlign
        {
            get
            {
                return _TextAlign;
            }
            set
            {
                _TextAlign = value;
            }
        }
    }

    interface IHtmlTag
    {
    }
}
