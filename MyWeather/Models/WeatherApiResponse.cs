﻿namespace MyWeather.Models
{
    public class WeatherApiResponse
    {

        public Coord coord { get; set; } = new Coord();
        public  Weather[] weather { get; set; }= new Weather[0];
        public string Base { get; set; } = "";
        public Main main { get; set; } = new Main();
        public int visibility { get; set; }
        public Wind wind { get; set; } = new Wind();
        public  Rain rain { get; set; }=new Rain();
        public  Clouds clouds { get; set; }=new Clouds();
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; } = "";
        public int cod { get; set; }
    }



    public class Main
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public int   pressure { get; set; }
        public int humidity { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
    }

    public class Wind
    {
        public float speed { get; set; }
        public int deg { get; set; }
        public float gust { get; set; }
    }

    public class Rain
    {
        public float _1h { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; } = "";
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; } = "";
        public string description { get; set; } = "";
        public string icon { get; set; } = "";
    }


}
