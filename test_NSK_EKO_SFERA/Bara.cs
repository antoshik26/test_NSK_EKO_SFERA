using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_NSK_EKO_SFERA
{
    class Bara
    {
        public string _Symvol { get; set; }
        public string _Description { get; set; }
        public DateTime _Date { get; set; }
        public DateTime _Time { get; set; }
        public Double _sellOpen { get; set; }
        public Double _sellHigh { get; set; }
        public Double _sellLow { get; set; }
        public Double _sellClose { get; set; }
        public int _TotalVolume { get; set; }

        public Bara(string Symvol, string Description, String date, String time, Double sellopen, Double sellHigh, Double sellLow, Double sellClose, int TotalVolume)
        {
            _Symvol = Symvol;
            _Description = Description;
            _Date = DateTime.Parse(date  + " " + time);
            _sellOpen = sellopen;
            _sellHigh = sellHigh;
            _sellLow = sellLow;
            _sellClose = sellClose;
            _TotalVolume = TotalVolume;
        }

        private string[] ConvertToStringArray()
        {
            string[] rezult = new string[9];
            rezult[0] = _Symvol.ToString();
            rezult[1] = _Description.ToString();
            rezult[2] = _Date.Date.ToString("d", CultureInfo.GetCultureInfo("de-DE"));
            rezult[3] = _Date.TimeOfDay.ToString();
            rezult[4] = _sellOpen.ToString();
            rezult[5] = _sellHigh.ToString();
            rezult[6] = _sellLow.ToString();
            rezult[7] = _sellClose.ToString();
            rezult[8] = _TotalVolume.ToString();
            return (rezult);
        }

        public string ConvertToCsvString()
        {
            string[] Baraarray = this.ConvertToStringArray();
            string rezult = "";
            for  (int i = 0; i < Baraarray.Length; i++)
            {
                if (i == Baraarray.Length - 1)
                    rezult += Baraarray[i];
                else
                {
                    rezult += Baraarray[i];
                    rezult += ",";
                }
            }
            return (rezult);
        }

    }
}
