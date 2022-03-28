using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace App1Final
{
    public partial class World
    {
        [JsonProperty("All")]
        public All All { get; set; }

        [JsonProperty("Baden-Wurttemberg")]
        public District BadenWurttemberg { get; set; }

        [JsonProperty("Bayern")]
        public District Bayern { get; set; }

        [JsonProperty("Berlin")]
        public District Berlin { get; set; }

        [JsonProperty("Brandenburg")]
        public District Brandenburg { get; set; }

        [JsonProperty("Bremen")]
        public District Bremen { get; set; }

        [JsonProperty("Hamburg")]
        public District Hamburg { get; set; }

        [JsonProperty("Hessen")]
        public District Hessen { get; set; }

        [JsonProperty("Mecklenburg-Vorpommern")]
        public District MecklenburgVorpommern { get; set; }

        [JsonProperty("Niedersachsen")]
        public District Niedersachsen { get; set; }

        [JsonProperty("Nordrhein-Westfalen")]
        public District NordrheinWestfalen { get; set; }

        [JsonProperty("Rheinland-Pfalz")]
        public District RheinlandPfalz { get; set; }

        [JsonProperty("Saarland")]
        public District Saarland { get; set; }

        [JsonProperty("Sachsen")]
        public District Sachsen { get; set; }

        [JsonProperty("Sachsen-Anhalt")]
        public District SachsenAnhalt { get; set; }

        [JsonProperty("Schleswig-Holstein")]
        public District SchleswigHolstein { get; set; }

        [JsonProperty("Thuringen")]
        public District Thuringen { get; set; }

        [JsonProperty("Unknown")]
        public District Unknown { get; set; }
    }

    public partial class All
    {
        [JsonProperty("confirmed")]
        public long Confirmed { get; set; }

        [JsonProperty("recovered")]
        public long Recovered { get; set; }

        [JsonProperty("deaths")]
        public long Deaths { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("population")]
        public long Population { get; set; }

        [JsonProperty("sq_km_area")]
        public long SqKmArea { get; set; }

        [JsonProperty("life_expectancy")]
        public string LifeExpectancy { get; set; }

        [JsonProperty("elevation_in_meters")]
        public long ElevationInMeters { get; set; }

        [JsonProperty("continent")]
        public string Continent { get; set; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("iso")]
        public long Iso { get; set; }

        [JsonProperty("capital_city")]
        public string CapitalCity { get; set; }
    }

    public partial class District
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("long")]
        public string Long { get; set; }

        [JsonProperty("confirmed")]
        public long Confirmed { get; set; }

        [JsonProperty("recovered")]
        public long Recovered { get; set; }

        [JsonProperty("deaths")]
        public long Deaths { get; set; }

        [JsonProperty("updated")]
        public DateTimeOffset Updated { get; set; }
    }
}


public partial class World
{
    public static World FromJson(string json) => JsonConvert.DeserializeObject<World>(json, Converter.Settings);
}

public static class Serialize
{
    public static string ToJson(this World self) => JsonConvert.SerializeObject(self, Converter.Settings);
}

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
    };
}