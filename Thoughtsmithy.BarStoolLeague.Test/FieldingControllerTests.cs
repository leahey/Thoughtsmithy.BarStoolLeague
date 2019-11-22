using System;
using System.Linq;
using FluentAssertions;
using Newtonsoft.Json;
using TestSupport.EfHelpers;
using Thoughtsmithy.BarStoolLeague.Controllers;
using Thoughtsmithy.BarStoolLeague.Data;
using Thoughtsmithy.BarStoolLeague.Models;
using Xunit;

namespace Thoughtsmithy.BarStoolLeague.Test
{
    public class FieldingControllerTests : IDisposable
    {
        #region fields
        private BarStoolLeagueContext context;
        private FieldingController tested;
        #endregion

        #region const
        private const string person01 = "{\"playerId\":\"bautijo02\",\"birthYear\":1874,\"birthMonth\":6,\"birthDay\":5,\"birthCountry\":\"USA\",\"birthState\":\"MO\",\"birthCity\":\"St. Louis\",\"deathYear\":1959,\"deathMonth\":6,\"deathDay\":9,\"deathCountry\":null,\"deathState\":null,\"deathCity\":null,\"nameFirst\":\"Frank\",\"nameLast\":\"Huelsman\",\"nameGiven\":\"Frank Elmer\",\"weight\":190,\"height\":75,\"bats\":\"R\",\"throws\":\"R\",\"debut\":\"1977-07-26 00:00:00\",\"finalGame\":\"1990-10-03 00:00:00\",\"retroId\":\"aased001\",\"bbrefId\":\"aasedo01\"}";

        private const string fielding01 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2004,\"Stint\":1,\"TeamID\":\"BAL\",\"LgID\":\"AL\",\"POS\":\"3B\",\"G\":4,\"GS\":0,\"InnOuts\":15,\"PO\":0,\"A\":0,\"E\":0,\"DP\":0,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding02 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2004,\"Stint\":1,\"TeamID\":\"BAL\",\"LgID\":\"AL\",\"POS\":\"OF\",\"G\":6,\"GS\":2,\"InnOuts\":72,\"PO\":4,\"A\":1,\"E\":0,\"DP\":0,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding03 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2004,\"Stint\":2,\"TeamID\":\"TBA\",\"LgID\":\"AL\",\"POS\":\"3B\",\"G\":2,\"GS\":0,\"InnOuts\":12,\"PO\":0,\"A\":2,\"E\":0,\"DP\":0,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding04 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2004,\"Stint\":2,\"TeamID\":\"TBA\",\"LgID\":\"AL\",\"POS\":\"OF\",\"G\":8,\"GS\":3,\"InnOuts\":85,\"PO\":4,\"A\":0,\"E\":0,\"DP\":0,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding05 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2004,\"Stint\":3,\"TeamID\":\"KCA\",\"LgID\":\"AL\",\"POS\":\"3B\",\"G\":11,\"GS\":6,\"InnOuts\":174,\"PO\":5,\"A\":17,\"E\":1,\"DP\":2,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding06 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2004,\"Stint\":3,\"TeamID\":\"KCA\",\"LgID\":\"AL\",\"POS\":\"OF\",\"G\":1,\"GS\":0,\"InnOuts\":3,\"PO\":0,\"A\":0,\"E\":0,\"DP\":0,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding07 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2004,\"Stint\":4,\"TeamID\":\"PIT\",\"LgID\":\"NL\",\"POS\":\"OF\",\"G\":12,\"GS\":9,\"InnOuts\":225,\"PO\":19,\"A\":0,\"E\":3,\"DP\":0,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding08 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2005,\"Stint\":1,\"TeamID\":\"PIT\",\"LgID\":\"NL\",\"POS\":\"3B\",\"G\":8,\"GS\":7,\"InnOuts\":176,\"PO\":6,\"A\":14,\"E\":1,\"DP\":2,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding09 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2006,\"Stint\":1,\"TeamID\":\"PIT\",\"LgID\":\"NL\",\"POS\":\"2B\",\"G\":3,\"GS\":2,\"InnOuts\":65,\"PO\":9,\"A\":9,\"E\":0,\"DP\":3,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding10 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2006,\"Stint\":1,\"TeamID\":\"PIT\",\"LgID\":\"NL\",\"POS\":\"3B\",\"G\":33,\"GS\":31,\"InnOuts\":802,\"PO\":22,\"A\":54,\"E\":6,\"DP\":5,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding11 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2006,\"Stint\":1,\"TeamID\":\"PIT\",\"LgID\":\"NL\",\"POS\":\"OF\",\"G\":85,\"GS\":68,\"InnOuts\":1923,\"PO\":154,\"A\":8,\"E\":2,\"DP\":1,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding12 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2007,\"Stint\":1,\"TeamID\":\"PIT\",\"LgID\":\"NL\",\"POS\":\"3B\",\"G\":126,\"GS\":122,\"InnOuts\":3194,\"PO\":95,\"A\":251,\"E\":15,\"DP\":16,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding13 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2007,\"Stint\":1,\"TeamID\":\"PIT\",\"LgID\":\"NL\",\"POS\":\"OF\",\"G\":21,\"GS\":18,\"InnOuts\":518,\"PO\":30,\"A\":1,\"E\":2,\"DP\":0,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding14 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2008,\"Stint\":1,\"TeamID\":\"PIT\",\"LgID\":\"NL\",\"POS\":\"3B\",\"G\":91,\"GS\":81,\"InnOuts\":2179,\"PO\":45,\"A\":196,\"E\":11,\"DP\":16,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding15 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2008,\"Stint\":2,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"1B\",\"G\":5,\"GS\":4,\"InnOuts\":81,\"PO\":29,\"A\":0,\"E\":0,\"DP\":1,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding16 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2008,\"Stint\":2,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"2B\",\"G\":2,\"GS\":2,\"InnOuts\":48,\"PO\":2,\"A\":6,\"E\":0,\"DP\":2,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding17 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2008,\"Stint\":2,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"3B\",\"G\":8,\"GS\":4,\"InnOuts\":120,\"PO\":5,\"A\":11,\"E\":0,\"DP\":1,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding18 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2009,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"3B\",\"G\":26,\"GS\":22,\"InnOuts\":627,\"PO\":18,\"A\":48,\"E\":3,\"DP\":4,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding19 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2009,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"OF\",\"G\":79,\"GS\":70,\"InnOuts\":1923,\"PO\":132,\"A\":11,\"E\":1,\"DP\":2,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding20 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2010,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"1B\",\"G\":4,\"GS\":1,\"InnOuts\":54,\"PO\":26,\"A\":0,\"E\":0,\"DP\":0,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding21 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2010,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"3B\",\"G\":48,\"GS\":45,\"InnOuts\":1179,\"PO\":26,\"A\":100,\"E\":4,\"DP\":7,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding22 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2010,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"OF\",\"G\":113,\"GS\":113,\"InnOuts\":2957,\"PO\":180,\"A\":12,\"E\":3,\"DP\":5,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding23 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2011,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"3B\",\"G\":25,\"GS\":25,\"InnOuts\":615,\"PO\":17,\"A\":62,\"E\":2,\"DP\":1,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding24 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2011,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"OF\",\"G\":116,\"GS\":115,\"InnOuts\":3042,\"PO\":233,\"A\":13,\"E\":6,\"DP\":5,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding25 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2012,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"1B\",\"G\":4,\"GS\":0,\"InnOuts\":21,\"PO\":8,\"A\":2,\"E\":0,\"DP\":1,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding26 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2012,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"3B\",\"G\":1,\"GS\":0,\"InnOuts\":12,\"PO\":0,\"A\":0,\"E\":0,\"DP\":0,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding27 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2012,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"OF\",\"G\":90,\"GS\":90,\"InnOuts\":2327,\"PO\":155,\"A\":11,\"E\":2,\"DP\":4,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding28 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2013,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"1B\",\"G\":1,\"GS\":0,\"InnOuts\":6,\"PO\":2,\"A\":0,\"E\":0,\"DP\":0,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding29 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2013,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"3B\",\"G\":3,\"GS\":2,\"InnOuts\":64,\"PO\":1,\"A\":1,\"E\":0,\"DP\":0,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding30 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2013,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"OF\",\"G\":109,\"GS\":109,\"InnOuts\":2898,\"PO\":192,\"A\":8,\"E\":5,\"DP\":4,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding31 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2014,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"1B\",\"G\":12,\"GS\":11,\"InnOuts\":291,\"PO\":75,\"A\":6,\"E\":0,\"DP\":6,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding32 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2014,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"OF\",\"G\":133,\"GS\":130,\"InnOuts\":3404,\"PO\":282,\"A\":12,\"E\":4,\"DP\":2,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding33 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2015,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"OF\",\"G\":118,\"GS\":118,\"InnOuts\":3116,\"PO\":224,\"A\":4,\"E\":3,\"DP\":1,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding34 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2016,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"1B\",\"G\":1,\"GS\":0,\"InnOuts\":9,\"PO\":3,\"A\":0,\"E\":0,\"DP\":0,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding35 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2016,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"OF\",\"G\":91,\"GS\":90,\"InnOuts\":2361,\"PO\":149,\"A\":5,\"E\":2,\"DP\":0,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding36 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2017,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"1B\",\"G\":1,\"GS\":0,\"InnOuts\":3,\"PO\":2,\"A\":0,\"E\":0,\"DP\":0,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding37 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2017,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"3B\",\"G\":8,\"GS\":4,\"InnOuts\":114,\"PO\":4,\"A\":10,\"E\":0,\"DP\":2,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding38 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2017,\"Stint\":1,\"TeamID\":\"TOR\",\"LgID\":\"AL\",\"POS\":\"OF\",\"G\":143,\"GS\":140,\"InnOuts\":3728,\"PO\":274,\"A\":10,\"E\":5,\"DP\":2,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding39 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2018,\"Stint\":1,\"TeamID\":\"ATL\",\"LgID\":\"NL\",\"POS\":\"3B\",\"G\":8,\"GS\":8,\"InnOuts\":184,\"PO\":3,\"A\":11,\"E\":1,\"DP\":2,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding40 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2018,\"Stint\":2,\"TeamID\":\"NYN\",\"LgID\":\"NL\",\"POS\":\"1B\",\"G\":2,\"GS\":2,\"InnOuts\":44,\"PO\":14,\"A\":3,\"E\":0,\"DP\":2,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding41 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2018,\"Stint\":2,\"TeamID\":\"NYN\",\"LgID\":\"NL\",\"POS\":\"2B\",\"G\":1,\"GS\":0,\"InnOuts\":3,\"PO\":0,\"A\":0,\"E\":0,\"DP\":0,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding42 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2018,\"Stint\":2,\"TeamID\":\"NYN\",\"LgID\":\"NL\",\"POS\":\"3B\",\"G\":11,\"GS\":9,\"InnOuts\":222,\"PO\":3,\"A\":16,\"E\":0,\"DP\":2,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding43 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2018,\"Stint\":2,\"TeamID\":\"NYN\",\"LgID\":\"NL\",\"POS\":\"OF\",\"G\":58,\"GS\":54,\"InnOuts\":1476,\"PO\":110,\"A\":5,\"E\":3,\"DP\":2,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding44 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2018,\"Stint\":3,\"TeamID\":\"PHI\",\"LgID\":\"NL\",\"POS\":\"3B\",\"G\":2,\"GS\":0,\"InnOuts\":12,\"PO\":0,\"A\":1,\"E\":0,\"DP\":0,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        private const string fielding45 = "{\"PlayerID\":\"bautijo02\",\"YearID\":2018,\"Stint\":3,\"TeamID\":\"PHI\",\"LgID\":\"NL\",\"POS\":\"OF\",\"G\":19,\"GS\":8,\"InnOuts\":282,\"PO\":15,\"A\":2,\"E\":0,\"DP\":1,\"PB\":null,\"WP\":null,\"SB\":null,\"CS\":null,\"ZR\":null}";
        #endregion

        #region setup
        public FieldingControllerTests()
        {
            SetupTestData();
            tested = new FieldingController(context);
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
            DeserializeAndAddPlayer(person01, context);

            DeserializeAndAddFielding(fielding01, context);
            DeserializeAndAddFielding(fielding02, context);
            DeserializeAndAddFielding(fielding03, context);
            DeserializeAndAddFielding(fielding04, context);
            DeserializeAndAddFielding(fielding05, context);
            DeserializeAndAddFielding(fielding06, context);
            DeserializeAndAddFielding(fielding07, context);
            DeserializeAndAddFielding(fielding08, context);
            DeserializeAndAddFielding(fielding09, context);
            DeserializeAndAddFielding(fielding10, context);
            DeserializeAndAddFielding(fielding11, context);
            DeserializeAndAddFielding(fielding12, context);
            DeserializeAndAddFielding(fielding13, context);
            DeserializeAndAddFielding(fielding14, context);
            DeserializeAndAddFielding(fielding15, context);
            DeserializeAndAddFielding(fielding16, context);
            DeserializeAndAddFielding(fielding17, context);
            DeserializeAndAddFielding(fielding18, context);
            DeserializeAndAddFielding(fielding19, context);
            DeserializeAndAddFielding(fielding20, context);
            DeserializeAndAddFielding(fielding21, context);
            DeserializeAndAddFielding(fielding22, context);
            DeserializeAndAddFielding(fielding23, context);
            DeserializeAndAddFielding(fielding24, context);
            DeserializeAndAddFielding(fielding25, context);
            DeserializeAndAddFielding(fielding26, context);
            DeserializeAndAddFielding(fielding27, context);
            DeserializeAndAddFielding(fielding28, context);
            DeserializeAndAddFielding(fielding29, context);
            DeserializeAndAddFielding(fielding30, context);
            DeserializeAndAddFielding(fielding31, context);
            DeserializeAndAddFielding(fielding32, context);
            DeserializeAndAddFielding(fielding33, context);
            DeserializeAndAddFielding(fielding34, context);
            DeserializeAndAddFielding(fielding35, context);
            DeserializeAndAddFielding(fielding36, context);
            DeserializeAndAddFielding(fielding37, context);
            DeserializeAndAddFielding(fielding38, context);
            DeserializeAndAddFielding(fielding39, context);
            DeserializeAndAddFielding(fielding40, context);
            DeserializeAndAddFielding(fielding41, context);
            DeserializeAndAddFielding(fielding42, context);
            DeserializeAndAddFielding(fielding43, context);
            DeserializeAndAddFielding(fielding44, context);
            DeserializeAndAddFielding(fielding45, context);

            context.SaveChanges();
        }

        private void DeserializeAndAddPlayer(string json, BarStoolLeagueContext context)
        {
            var person = new Person();
            JsonConvert.PopulateObject(json, person);
            context.Persons.Add(person);
        }

        private void DeserializeAndAddFielding(string json, BarStoolLeagueContext context)
        {
            var fielding = new Fielding();
            JsonConvert.PopulateObject(json, fielding);
            context.Fielding.Add(fielding);

        }

        #endregion

        [Fact]
        private void GetFielding_SpecifyPageAndSize_ShouldReturnCorrectItems()
        {
            var actual = tested.GetFielding(2, 5);
            actual.Result.Value.Count().Should().Be(5);
        }

        [Fact]
        private void GetFielding_GivenCriteria_ShouldReturnCorrectRecord()
        {
            var actual = tested.GetFielding("bautijo02", 2008, 2, "3B");
            actual.Result.Value.GS.Should().Be(4);
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
