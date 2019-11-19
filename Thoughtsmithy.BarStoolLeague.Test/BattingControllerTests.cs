using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using TestSupport.EfHelpers;
using Thoughtsmithy.BarStoolLeague.Controllers;
using Thoughtsmithy.BarStoolLeague.Models;
using Xunit;

namespace Thoughtsmithy.BarStoolLeague.Test
{
    public class BattingControllerTests : IDisposable
    {
        #region const
        private const string batting01 = "{\"PlayerID\":\"aardsda01\",\"YearID\":2004,\"Stint\":1,\"TeamID\":\"SFN\",\"LgID\":\"NL\",\"G\":11,\"G_batting\":null,\"AB\":0,\"R\":0,\"H\":0,\"_2B\":0,\"_3B\":0,\"HR\":0,\"RBI\":0,\"SB\":0,\"CS\":0,\"BB\":0,\"SO\":0,\"IBB\":0,\"HBP\":0,\"SH\":0,\"SF\":0,\"GIDP\":0}";
        private const string batting02 = "{\"PlayerID\":\"aardsda01\",\"YearID\":2006,\"Stint\":1,\"TeamID\":\"CHN\",\"LgID\":\"NL\",\"G\":45,\"G_batting\":null,\"AB\":2,\"R\":0,\"H\":0,\"_2B\":0,\"_3B\":0,\"HR\":0,\"RBI\":0,\"SB\":0,\"CS\":0,\"BB\":0,\"SO\":0,\"IBB\":0,\"HBP\":0,\"SH\":1,\"SF\":0,\"GIDP\":0}";
        private const string batting03 = "{\"PlayerID\":\"aardsda01\",\"YearID\":2007,\"Stint\":1,\"TeamID\":\"CHA\",\"LgID\":\"AL\",\"G\":25,\"G_batting\":null,\"AB\":0,\"R\":0,\"H\":0,\"_2B\":0,\"_3B\":0,\"HR\":0,\"RBI\":0,\"SB\":0,\"CS\":0,\"BB\":0,\"SO\":0,\"IBB\":0,\"HBP\":0,\"SH\":0,\"SF\":0,\"GIDP\":0}";
        private const string batting04 = "{\"PlayerID\":\"aardsda01\",\"YearID\":2008,\"Stint\":1,\"TeamID\":\"BOS\",\"LgID\":\"AL\",\"G\":47,\"G_batting\":null,\"AB\":1,\"R\":0,\"H\":0,\"_2B\":0,\"_3B\":0,\"HR\":0,\"RBI\":0,\"SB\":0,\"CS\":0,\"BB\":0,\"SO\":1,\"IBB\":0,\"HBP\":0,\"SH\":0,\"SF\":0,\"GIDP\":0}";
        private const string batting05 = "{\"PlayerID\":\"aardsda01\",\"YearID\":2009,\"Stint\":1,\"TeamID\":\"SEA\",\"LgID\":\"AL\",\"G\":73,\"G_batting\":null,\"AB\":0,\"R\":0,\"H\":0,\"_2B\":0,\"_3B\":0,\"HR\":0,\"RBI\":0,\"SB\":0,\"CS\":0,\"BB\":0,\"SO\":0,\"IBB\":0,\"HBP\":0,\"SH\":0,\"SF\":0,\"GIDP\":0}";
        private const string batting06 = "{\"PlayerID\":\"aardsda01\",\"YearID\":2010,\"Stint\":1,\"TeamID\":\"SEA\",\"LgID\":\"AL\",\"G\":53,\"G_batting\":null,\"AB\":0,\"R\":0,\"H\":0,\"_2B\":0,\"_3B\":0,\"HR\":0,\"RBI\":0,\"SB\":0,\"CS\":0,\"BB\":0,\"SO\":0,\"IBB\":0,\"HBP\":0,\"SH\":0,\"SF\":0,\"GIDP\":0}";
        private const string batting07 = "{\"PlayerID\":\"aardsda01\",\"YearID\":2012,\"Stint\":1,\"TeamID\":\"NYA\",\"LgID\":\"AL\",\"G\":1,\"G_batting\":null,\"AB\":0,\"R\":0,\"H\":0,\"_2B\":0,\"_3B\":0,\"HR\":0,\"RBI\":0,\"SB\":0,\"CS\":0,\"BB\":0,\"SO\":0,\"IBB\":0,\"HBP\":0,\"SH\":0,\"SF\":0,\"GIDP\":0}";
        private const string batting08 = "{\"PlayerID\":\"aardsda01\",\"YearID\":2013,\"Stint\":1,\"TeamID\":\"NYN\",\"LgID\":\"NL\",\"G\":43,\"G_batting\":null,\"AB\":0,\"R\":0,\"H\":0,\"_2B\":0,\"_3B\":0,\"HR\":0,\"RBI\":0,\"SB\":0,\"CS\":0,\"BB\":0,\"SO\":0,\"IBB\":0,\"HBP\":0,\"SH\":0,\"SF\":0,\"GIDP\":0}";
        private const string batting09 = "{\"PlayerID\":\"aardsda01\",\"YearID\":2015,\"Stint\":1,\"TeamID\":\"ATL\",\"LgID\":\"NL\",\"G\":33,\"G_batting\":null,\"AB\":1,\"R\":0,\"H\":0,\"_2B\":0,\"_3B\":0,\"HR\":0,\"RBI\":0,\"SB\":0,\"CS\":0,\"BB\":0,\"SO\":1,\"IBB\":0,\"HBP\":0,\"SH\":0,\"SF\":0,\"GIDP\":0}";
        private const string batting10 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1954,\"Stint\":1,\"TeamID\":\"ML1\",\"LgID\":\"NL\",\"G\":122,\"G_batting\":null,\"AB\":468,\"R\":58,\"H\":131,\"_2B\":27,\"_3B\":6,\"HR\":13,\"RBI\":69,\"SB\":2,\"CS\":2,\"BB\":28,\"SO\":39,\"IBB\":null,\"HBP\":3,\"SH\":6,\"SF\":4,\"GIDP\":13}";
        private const string batting11 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1955,\"Stint\":1,\"TeamID\":\"ML1\",\"LgID\":\"NL\",\"G\":153,\"G_batting\":null,\"AB\":602,\"R\":105,\"H\":189,\"_2B\":37,\"_3B\":9,\"HR\":27,\"RBI\":106,\"SB\":3,\"CS\":1,\"BB\":49,\"SO\":61,\"IBB\":5,\"HBP\":3,\"SH\":7,\"SF\":4,\"GIDP\":20}";
        private const string batting12 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1956,\"Stint\":1,\"TeamID\":\"ML1\",\"LgID\":\"NL\",\"G\":153,\"G_batting\":null,\"AB\":609,\"R\":106,\"H\":200,\"_2B\":34,\"_3B\":14,\"HR\":26,\"RBI\":92,\"SB\":2,\"CS\":4,\"BB\":37,\"SO\":54,\"IBB\":6,\"HBP\":2,\"SH\":5,\"SF\":7,\"GIDP\":21}";
        private const string batting13 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1957,\"Stint\":1,\"TeamID\":\"ML1\",\"LgID\":\"NL\",\"G\":151,\"G_batting\":null,\"AB\":615,\"R\":118,\"H\":198,\"_2B\":27,\"_3B\":6,\"HR\":44,\"RBI\":132,\"SB\":1,\"CS\":1,\"BB\":57,\"SO\":58,\"IBB\":15,\"HBP\":0,\"SH\":0,\"SF\":3,\"GIDP\":13}";
        private const string batting14 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1958,\"Stint\":1,\"TeamID\":\"ML1\",\"LgID\":\"NL\",\"G\":153,\"G_batting\":null,\"AB\":601,\"R\":109,\"H\":196,\"_2B\":34,\"_3B\":4,\"HR\":30,\"RBI\":95,\"SB\":4,\"CS\":1,\"BB\":59,\"SO\":49,\"IBB\":16,\"HBP\":1,\"SH\":0,\"SF\":3,\"GIDP\":21}";
        private const string batting15 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1959,\"Stint\":1,\"TeamID\":\"ML1\",\"LgID\":\"NL\",\"G\":154,\"G_batting\":null,\"AB\":629,\"R\":116,\"H\":223,\"_2B\":46,\"_3B\":7,\"HR\":39,\"RBI\":123,\"SB\":8,\"CS\":0,\"BB\":51,\"SO\":54,\"IBB\":17,\"HBP\":4,\"SH\":0,\"SF\":9,\"GIDP\":19}";
        private const string batting16 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1960,\"Stint\":1,\"TeamID\":\"ML1\",\"LgID\":\"NL\",\"G\":153,\"G_batting\":null,\"AB\":590,\"R\":102,\"H\":172,\"_2B\":20,\"_3B\":11,\"HR\":40,\"RBI\":126,\"SB\":16,\"CS\":7,\"BB\":60,\"SO\":63,\"IBB\":13,\"HBP\":2,\"SH\":0,\"SF\":12,\"GIDP\":8}";
        private const string batting17 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1961,\"Stint\":1,\"TeamID\":\"ML1\",\"LgID\":\"NL\",\"G\":155,\"G_batting\":null,\"AB\":603,\"R\":115,\"H\":197,\"_2B\":39,\"_3B\":10,\"HR\":34,\"RBI\":120,\"SB\":21,\"CS\":9,\"BB\":56,\"SO\":64,\"IBB\":20,\"HBP\":2,\"SH\":1,\"SF\":9,\"GIDP\":16}";
        private const string batting18 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1962,\"Stint\":1,\"TeamID\":\"ML1\",\"LgID\":\"NL\",\"G\":156,\"G_batting\":null,\"AB\":592,\"R\":127,\"H\":191,\"_2B\":28,\"_3B\":6,\"HR\":45,\"RBI\":128,\"SB\":15,\"CS\":7,\"BB\":66,\"SO\":73,\"IBB\":14,\"HBP\":3,\"SH\":0,\"SF\":6,\"GIDP\":14}";
        private const string batting19 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1963,\"Stint\":1,\"TeamID\":\"ML1\",\"LgID\":\"NL\",\"G\":161,\"G_batting\":null,\"AB\":631,\"R\":121,\"H\":201,\"_2B\":29,\"_3B\":4,\"HR\":44,\"RBI\":130,\"SB\":31,\"CS\":5,\"BB\":78,\"SO\":94,\"IBB\":18,\"HBP\":0,\"SH\":0,\"SF\":5,\"GIDP\":11}";
        private const string batting20 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1964,\"Stint\":1,\"TeamID\":\"ML1\",\"LgID\":\"NL\",\"G\":145,\"G_batting\":null,\"AB\":570,\"R\":103,\"H\":187,\"_2B\":30,\"_3B\":2,\"HR\":24,\"RBI\":95,\"SB\":22,\"CS\":4,\"BB\":62,\"SO\":46,\"IBB\":9,\"HBP\":0,\"SH\":0,\"SF\":2,\"GIDP\":22}";
        private const string batting21 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1965,\"Stint\":1,\"TeamID\":\"ML1\",\"LgID\":\"NL\",\"G\":150,\"G_batting\":null,\"AB\":570,\"R\":109,\"H\":181,\"_2B\":40,\"_3B\":1,\"HR\":32,\"RBI\":89,\"SB\":24,\"CS\":4,\"BB\":60,\"SO\":81,\"IBB\":10,\"HBP\":1,\"SH\":0,\"SF\":8,\"GIDP\":15}";
        private const string batting22 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1966,\"Stint\":1,\"TeamID\":\"ATL\",\"LgID\":\"NL\",\"G\":158,\"G_batting\":null,\"AB\":603,\"R\":117,\"H\":168,\"_2B\":23,\"_3B\":1,\"HR\":44,\"RBI\":127,\"SB\":21,\"CS\":3,\"BB\":76,\"SO\":96,\"IBB\":15,\"HBP\":1,\"SH\":0,\"SF\":8,\"GIDP\":14}";
        private const string batting23 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1967,\"Stint\":1,\"TeamID\":\"ATL\",\"LgID\":\"NL\",\"G\":155,\"G_batting\":null,\"AB\":600,\"R\":113,\"H\":184,\"_2B\":37,\"_3B\":3,\"HR\":39,\"RBI\":109,\"SB\":17,\"CS\":6,\"BB\":63,\"SO\":97,\"IBB\":19,\"HBP\":0,\"SH\":0,\"SF\":6,\"GIDP\":11}";
        private const string batting24 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1968,\"Stint\":1,\"TeamID\":\"ATL\",\"LgID\":\"NL\",\"G\":160,\"G_batting\":null,\"AB\":606,\"R\":84,\"H\":174,\"_2B\":33,\"_3B\":4,\"HR\":29,\"RBI\":86,\"SB\":28,\"CS\":5,\"BB\":64,\"SO\":62,\"IBB\":23,\"HBP\":1,\"SH\":0,\"SF\":5,\"GIDP\":21}";
        private const string batting25 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1969,\"Stint\":1,\"TeamID\":\"ATL\",\"LgID\":\"NL\",\"G\":147,\"G_batting\":null,\"AB\":547,\"R\":100,\"H\":164,\"_2B\":30,\"_3B\":3,\"HR\":44,\"RBI\":97,\"SB\":9,\"CS\":10,\"BB\":87,\"SO\":47,\"IBB\":19,\"HBP\":2,\"SH\":0,\"SF\":3,\"GIDP\":14}";
        private const string batting26 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1970,\"Stint\":1,\"TeamID\":\"ATL\",\"LgID\":\"NL\",\"G\":150,\"G_batting\":null,\"AB\":516,\"R\":103,\"H\":154,\"_2B\":26,\"_3B\":1,\"HR\":38,\"RBI\":118,\"SB\":9,\"CS\":0,\"BB\":74,\"SO\":63,\"IBB\":15,\"HBP\":2,\"SH\":0,\"SF\":6,\"GIDP\":13}";
        private const string batting27 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1971,\"Stint\":1,\"TeamID\":\"ATL\",\"LgID\":\"NL\",\"G\":139,\"G_batting\":null,\"AB\":495,\"R\":95,\"H\":162,\"_2B\":22,\"_3B\":3,\"HR\":47,\"RBI\":118,\"SB\":1,\"CS\":1,\"BB\":71,\"SO\":58,\"IBB\":21,\"HBP\":2,\"SH\":0,\"SF\":5,\"GIDP\":9}";
        private const string batting28 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1972,\"Stint\":1,\"TeamID\":\"ATL\",\"LgID\":\"NL\",\"G\":129,\"G_batting\":null,\"AB\":449,\"R\":75,\"H\":119,\"_2B\":10,\"_3B\":0,\"HR\":34,\"RBI\":77,\"SB\":4,\"CS\":0,\"BB\":92,\"SO\":55,\"IBB\":15,\"HBP\":1,\"SH\":0,\"SF\":2,\"GIDP\":17}";
        private const string batting29 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1973,\"Stint\":1,\"TeamID\":\"ATL\",\"LgID\":\"NL\",\"G\":120,\"G_batting\":null,\"AB\":392,\"R\":84,\"H\":118,\"_2B\":12,\"_3B\":1,\"HR\":40,\"RBI\":96,\"SB\":1,\"CS\":1,\"BB\":68,\"SO\":51,\"IBB\":13,\"HBP\":1,\"SH\":0,\"SF\":4,\"GIDP\":7}";
        private const string batting30 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1974,\"Stint\":1,\"TeamID\":\"ATL\",\"LgID\":\"NL\",\"G\":112,\"G_batting\":null,\"AB\":340,\"R\":47,\"H\":91,\"_2B\":16,\"_3B\":0,\"HR\":20,\"RBI\":69,\"SB\":1,\"CS\":0,\"BB\":39,\"SO\":29,\"IBB\":6,\"HBP\":0,\"SH\":1,\"SF\":2,\"GIDP\":6}";
        private const string batting31 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1975,\"Stint\":1,\"TeamID\":\"ML4\",\"LgID\":\"AL\",\"G\":137,\"G_batting\":null,\"AB\":465,\"R\":45,\"H\":109,\"_2B\":16,\"_3B\":2,\"HR\":12,\"RBI\":60,\"SB\":0,\"CS\":1,\"BB\":70,\"SO\":51,\"IBB\":3,\"HBP\":1,\"SH\":1,\"SF\":6,\"GIDP\":15}";
        private const string batting32 = "{\"PlayerID\":\"aaronha01\",\"YearID\":1976,\"Stint\":1,\"TeamID\":\"ML4\",\"LgID\":\"AL\",\"G\":85,\"G_batting\":null,\"AB\":271,\"R\":22,\"H\":62,\"_2B\":8,\"_3B\":0,\"HR\":10,\"RBI\":35,\"SB\":0,\"CS\":1,\"BB\":35,\"SO\":38,\"IBB\":1,\"HBP\":0,\"SH\":0,\"SF\":2,\"GIDP\":8}";
        private const string batting33 = "{\"PlayerID\":\"aaronto01\",\"YearID\":1962,\"Stint\":1,\"TeamID\":\"ML1\",\"LgID\":\"NL\",\"G\":141,\"G_batting\":null,\"AB\":334,\"R\":54,\"H\":77,\"_2B\":20,\"_3B\":2,\"HR\":8,\"RBI\":38,\"SB\":6,\"CS\":0,\"BB\":41,\"SO\":58,\"IBB\":0,\"HBP\":0,\"SH\":4,\"SF\":3,\"GIDP\":10}";
        private const string batting34 = "{\"PlayerID\":\"aaronto01\",\"YearID\":1963,\"Stint\":1,\"TeamID\":\"ML1\",\"LgID\":\"NL\",\"G\":72,\"G_batting\":null,\"AB\":135,\"R\":6,\"H\":27,\"_2B\":6,\"_3B\":1,\"HR\":1,\"RBI\":15,\"SB\":0,\"CS\":3,\"BB\":11,\"SO\":27,\"IBB\":1,\"HBP\":0,\"SH\":3,\"SF\":2,\"GIDP\":7}";
        private const string batting35 = "{\"PlayerID\":\"aaronto01\",\"YearID\":1965,\"Stint\":1,\"TeamID\":\"ML1\",\"LgID\":\"NL\",\"G\":8,\"G_batting\":null,\"AB\":16,\"R\":1,\"H\":3,\"_2B\":0,\"_3B\":0,\"HR\":0,\"RBI\":1,\"SB\":0,\"CS\":0,\"BB\":1,\"SO\":2,\"IBB\":0,\"HBP\":0,\"SH\":0,\"SF\":0,\"GIDP\":1}";
        private const string batting36 = "{\"PlayerID\":\"aaronto01\",\"YearID\":1968,\"Stint\":1,\"TeamID\":\"ATL\",\"LgID\":\"NL\",\"G\":98,\"G_batting\":null,\"AB\":283,\"R\":21,\"H\":69,\"_2B\":10,\"_3B\":3,\"HR\":1,\"RBI\":25,\"SB\":3,\"CS\":4,\"BB\":21,\"SO\":37,\"IBB\":1,\"HBP\":0,\"SH\":2,\"SF\":1,\"GIDP\":9}";
        private const string batting37 = "{\"PlayerID\":\"aaronto01\",\"YearID\":1969,\"Stint\":1,\"TeamID\":\"ATL\",\"LgID\":\"NL\",\"G\":49,\"G_batting\":null,\"AB\":60,\"R\":13,\"H\":15,\"_2B\":2,\"_3B\":0,\"HR\":1,\"RBI\":5,\"SB\":0,\"CS\":1,\"BB\":6,\"SO\":6,\"IBB\":0,\"HBP\":0,\"SH\":0,\"SF\":0,\"GIDP\":1}";
        private const string batting38 = "{\"PlayerID\":\"aaronto01\",\"YearID\":1970,\"Stint\":1,\"TeamID\":\"ATL\",\"LgID\":\"NL\",\"G\":44,\"G_batting\":null,\"AB\":63,\"R\":3,\"H\":13,\"_2B\":2,\"_3B\":0,\"HR\":2,\"RBI\":7,\"SB\":0,\"CS\":0,\"BB\":3,\"SO\":10,\"IBB\":0,\"HBP\":0,\"SH\":0,\"SF\":0,\"GIDP\":5}";
        private const string batting39 = "{\"PlayerID\":\"aaronto01\",\"YearID\":1971,\"Stint\":1,\"TeamID\":\"ATL\",\"LgID\":\"NL\",\"G\":25,\"G_batting\":null,\"AB\":53,\"R\":4,\"H\":12,\"_2B\":2,\"_3B\":0,\"HR\":0,\"RBI\":3,\"SB\":0,\"CS\":0,\"BB\":3,\"SO\":5,\"IBB\":1,\"HBP\":0,\"SH\":0,\"SF\":0,\"GIDP\":3}";
        private const string batting40 = "{\"PlayerID\":\"aasedo01\",\"YearID\":1977,\"Stint\":1,\"TeamID\":\"BOS\",\"LgID\":\"AL\",\"G\":13,\"G_batting\":null,\"AB\":0,\"R\":0,\"H\":0,\"_2B\":0,\"_3B\":0,\"HR\":0,\"RBI\":0,\"SB\":0,\"CS\":0,\"BB\":0,\"SO\":0,\"IBB\":0,\"HBP\":0,\"SH\":0,\"SF\":0,\"GIDP\":0}";

        // multiple stints
        private const string batting41 = "{\"PlayerID\":\"huelsfr01\",\"YearID\":1904,\"Stint\":1,\"TeamID\":\"CHA\",\"LgID\":\"AL\",\"G\":3,\"G_batting\":null,\"AB\":6,\"R\":0,\"H\":1,\"_2B\":1,\"_3B\":0,\"HR\":0,\"RBI\":0,\"SB\":0,\"CS\":null,\"BB\":0,\"SO\":1,\"IBB\":null,\"HBP\":0,\"SH\":0,\"SF\":null,\"GIDP\":null}";
        private const string batting42 = "{\"PlayerID\":\"huelsfr01\",\"YearID\":1904,\"Stint\":2,\"TeamID\":\"DET\",\"LgID\":\"AL\",\"G\":4,\"G_batting\":null,\"AB\":18,\"R\":1,\"H\":6,\"_2B\":1,\"_3B\":0,\"HR\":0,\"RBI\":4,\"SB\":1,\"CS\":null,\"BB\":1,\"SO\":2,\"IBB\":null,\"HBP\":0,\"SH\":0,\"SF\":null,\"GIDP\":null}";
        private const string batting43 = "{\"PlayerID\":\"huelsfr01\",\"YearID\":1904,\"Stint\":3,\"TeamID\":\"CHA\",\"LgID\":\"AL\",\"G\":1,\"G_batting\":null,\"AB\":1,\"R\":0,\"H\":0,\"_2B\":0,\"_3B\":0,\"HR\":0,\"RBI\":0,\"SB\":0,\"CS\":null,\"BB\":0,\"SO\":0,\"IBB\":null,\"HBP\":0,\"SH\":0,\"SF\":null,\"GIDP\":null}";
        private const string batting44 = "{\"PlayerID\":\"huelsfr01\",\"YearID\":1904,\"Stint\":4,\"TeamID\":\"SLA\",\"LgID\":\"AL\",\"G\":20,\"G_batting\":null,\"AB\":68,\"R\":6,\"H\":15,\"_2B\":2,\"_3B\":1,\"HR\":0,\"RBI\":1,\"SB\":0,\"CS\":null,\"BB\":6,\"SO\":13,\"IBB\":null,\"HBP\":2,\"SH\":1,\"SF\":null,\"GIDP\":null}";
        private const string batting45 = "{\"PlayerID\":\"huelsfr01\",\"YearID\":1904,\"Stint\":5,\"TeamID\":\"WS1\",\"LgID\":\"AL\",\"G\":84,\"G_batting\":null,\"AB\":303,\"R\":21,\"H\":75,\"_2B\":19,\"_3B\":4,\"HR\":2,\"RBI\":30,\"SB\":6,\"CS\":null,\"BB\":24,\"SO\":72,\"IBB\":null,\"HBP\":5,\"SH\":3,\"SF\":null,\"GIDP\":null}";
        #endregion

        #region fields
        private BarStoolLeagueContext context;
        private BattingController tested;
        #endregion

        #region setup
        public BattingControllerTests()
        {
            SetupTestData();
            tested = new BattingController(context);
        }

        private void SetupTestData()
        {
            var options = SqliteInMemory.CreateOptions<BarStoolLeagueContext>();
            context = new BarStoolLeagueContext(options);
            context.Database.EnsureCreated();
            SeedDatabaseForTests(context);
        }

        private void SeedDatabaseForTests(BarStoolLeagueContext context)
        {
            DeserializeAndAddTo(batting01, context);
            DeserializeAndAddTo(batting02, context);
            DeserializeAndAddTo(batting03, context);
            DeserializeAndAddTo(batting04, context);
            DeserializeAndAddTo(batting05, context);
            DeserializeAndAddTo(batting06, context);
            DeserializeAndAddTo(batting07, context);
            DeserializeAndAddTo(batting08, context);
            DeserializeAndAddTo(batting09, context);
            DeserializeAndAddTo(batting10, context);
            DeserializeAndAddTo(batting11, context);
            DeserializeAndAddTo(batting12, context);
            DeserializeAndAddTo(batting13, context);
            DeserializeAndAddTo(batting14, context);
            DeserializeAndAddTo(batting15, context);
            DeserializeAndAddTo(batting16, context);
            DeserializeAndAddTo(batting17, context);
            DeserializeAndAddTo(batting18, context);
            DeserializeAndAddTo(batting19, context);
            DeserializeAndAddTo(batting20, context);
            DeserializeAndAddTo(batting21, context);
            DeserializeAndAddTo(batting22, context);
            DeserializeAndAddTo(batting23, context);
            DeserializeAndAddTo(batting24, context);
            DeserializeAndAddTo(batting25, context);
            DeserializeAndAddTo(batting26, context);
            DeserializeAndAddTo(batting27, context);
            DeserializeAndAddTo(batting28, context);
            DeserializeAndAddTo(batting29, context);
            DeserializeAndAddTo(batting30, context);
            DeserializeAndAddTo(batting31, context);
            DeserializeAndAddTo(batting32, context);
            DeserializeAndAddTo(batting33, context);
            DeserializeAndAddTo(batting34, context);
            DeserializeAndAddTo(batting35, context);
            DeserializeAndAddTo(batting36, context);
            DeserializeAndAddTo(batting37, context);
            DeserializeAndAddTo(batting38, context);
            DeserializeAndAddTo(batting39, context);
            DeserializeAndAddTo(batting40, context);
            // multi-stints
            DeserializeAndAddTo(batting41, context);
            DeserializeAndAddTo(batting42, context);
            DeserializeAndAddTo(batting43, context);
            DeserializeAndAddTo(batting44, context);
            DeserializeAndAddTo(batting45, context);

            context.SaveChanges();
        }

        private void DeserializeAndAddTo(string json, BarStoolLeagueContext context)
        {
            var batting = new Batting();
            JsonConvert.PopulateObject(json, batting);
            context.Batting.Add(batting);

        }

        #endregion


        [Fact]
        private void GetBatting_SpecifyPageAndSize_ShouldReturnCorrectItems()
        {
            var actual = tested.GetBatting(2, 5);
            actual.Result.Value.Count().Should().Be(5);
        }

        [Theory]
        [InlineData("aardsda01", 2006, 1, 2)]
        [InlineData("aaronha01", 1954, 1, 468)]
        [InlineData("aaronha01", 1964, 1, 570)]
        [InlineData("aaronha01", 1974, 1, 340)]
        [InlineData("aaronto01", 1965, 1, 16)]
        [InlineData("huelsfr01", 1904, 1, 6)]
        private void GetBatting_ProvidePlayerYearAndStint_ShouldReturnCorrectAtBatStat(string playerId, short year, short stint, short expected)
        {
            var actual = tested.GetBatting(playerId, year, stint);
            actual.Result.Value.Ab.Should().Be(expected);
        }

        [Theory]
        [InlineData("aardsda01", 2006, 2)]
        [InlineData("aaronha01", 1954, 468)]
        [InlineData("aaronha01", 1964, 570)]
        [InlineData("aaronha01", 1974, 340)]
        [InlineData("aaronto01", 1965, 16)]
        [InlineData("huelsfr01", 1904, 396)] // <-- player has 5 stints
        private void GetBatting_ProvidePlayerAndYear_ShouldReturnCorrectAtBatStat(string playerId, short year, short expected)
        {
            var batting = tested.GetBatting(playerId, year);
            var actual = batting.Result.Value.Sum(b => b.Ab);
            actual.Should().Be(expected);
        }


        [Theory]
        [InlineData("aardsda01", 0)]
        [InlineData("aaronha01", 755)]
        [InlineData("aaronto01", 13)]
        [InlineData("aasedo01", 0)]
        [InlineData("huelsfr01", 2)]
        private void GetBatting_ProvidePlayerId_ShouldReturnCorrectCareerHRCount(string playerId, short expected)
        {
            var batting = tested.GetBatting(playerId);
            var actual = batting.Result.Value.Sum(b => b.Hr);
            actual.Should().Be(expected);
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose() =>
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        #endregion
    }
}
