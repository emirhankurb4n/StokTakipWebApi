﻿namespace StokTakipWebApi.Protokol
{
    public class ApiCevap
    {
        public bool BasariliMi { get; set; }
        public string HataMesaji { get; set; }

        public object Data { get; set; }
    }
}