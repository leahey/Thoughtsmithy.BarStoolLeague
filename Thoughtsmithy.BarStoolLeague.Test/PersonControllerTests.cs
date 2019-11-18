using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thoughtsmithy.BarStoolLeague.Controllers;
using Thoughtsmithy.BarStoolLeague.Models;
using Xunit;

namespace Thoughtsmithy.BarStoolLeague.Test
{
    public class PersonControllerTests
    {
        #region const
        private const string person01 = "{\"playerId\":\"aardsda01\",\"birthYear\":1981,\"birthMonth\":12,\"birthDay\":27,\"birthCountry\":\"USA\",\"birthState\":\"CO\",\"birthCity\":\"Denver\",\"deathYear\":null,\"deathMonth\":null,\"deathDay\":null,\"deathCountry\":null,\"deathState\":null,\"deathCity\":null,\"nameFirst\":\"David\",\"nameLast\":\"Aardsma\",\"nameGiven\":\"David Allan\",\"weight\":215,\"height\":75,\"bats\":\"R\",\"throws\":\"R\",\"debut\":\"2004-04-06 00:00:00\",\"finalGame\":\"2015-08-23 00:00:00\",\"retroId\":\"aardd001\",\"bbrefId\":\"aardsda01\"}";
        private const string person02 = "{\"playerId\":\"aaronha01\",\"birthYear\":1934,\"birthMonth\":2,\"birthDay\":5,\"birthCountry\":\"USA\",\"birthState\":\"AL\",\"birthCity\":\"Mobile\",\"deathYear\":null,\"deathMonth\":null,\"deathDay\":null,\"deathCountry\":null,\"deathState\":null,\"deathCity\":null,\"nameFirst\":\"Hank\",\"nameLast\":\"Aaron\",\"nameGiven\":\"Henry Louis\",\"weight\":180,\"height\":72,\"bats\":\"R\",\"throws\":\"R\",\"debut\":\"1954-04-13 00:00:00\",\"finalGame\":\"1976-10-03 00:00:00\",\"retroId\":\"aaroh101\",\"bbrefId\":\"aaronha01\"}";
        private const string person03 = "{\"playerId\":\"aaronto01\",\"birthYear\":1939,\"birthMonth\":8,\"birthDay\":5,\"birthCountry\":\"USA\",\"birthState\":\"AL\",\"birthCity\":\"Mobile\",\"deathYear\":1984,\"deathMonth\":8,\"deathDay\":16,\"deathCountry\":\"USA\",\"deathState\":\"GA\",\"deathCity\":\"Atlanta\",\"nameFirst\":\"Tommie\",\"nameLast\":\"Aaron\",\"nameGiven\":\"Tommie Lee\",\"weight\":190,\"height\":75,\"bats\":\"R\",\"throws\":\"R\",\"debut\":\"1962-04-10 00:00:00\",\"finalGame\":\"1971-09-26 00:00:00\",\"retroId\":\"aarot101\",\"bbrefId\":\"aaronto01\"}";
        private const string person04 = "{\"playerId\":\"aasedo01\",\"birthYear\":1954,\"birthMonth\":9,\"birthDay\":8,\"birthCountry\":\"USA\",\"birthState\":\"CA\",\"birthCity\":\"Orange\",\"deathYear\":null,\"deathMonth\":null,\"deathDay\":null,\"deathCountry\":null,\"deathState\":null,\"deathCity\":null,\"nameFirst\":\"Don\",\"nameLast\":\"Aase\",\"nameGiven\":\"Donald William\",\"weight\":190,\"height\":75,\"bats\":\"R\",\"throws\":\"R\",\"debut\":\"1977-07-26 00:00:00\",\"finalGame\":\"1990-10-03 00:00:00\",\"retroId\":\"aased001\",\"bbrefId\":\"aasedo01\"}";
        private const string person05 = "{\"playerId\":\"abadan01\",\"birthYear\":1972,\"birthMonth\":8,\"birthDay\":25,\"birthCountry\":\"USA\",\"birthState\":\"FL\",\"birthCity\":\"Palm Beach\",\"deathYear\":null,\"deathMonth\":null,\"deathDay\":null,\"deathCountry\":null,\"deathState\":null,\"deathCity\":null,\"nameFirst\":\"Andy\",\"nameLast\":\"Abad\",\"nameGiven\":\"Fausto Andres\",\"weight\":184,\"height\":73,\"bats\":\"L\",\"throws\":\"L\",\"debut\":\"2001-09-10 00:00:00\",\"finalGame\":\"2006-04-13 00:00:00\",\"retroId\":\"abada001\",\"bbrefId\":\"abadan01\"}";
        private const string person06 = "{\"playerId\":\"abadfe01\",\"birthYear\":1985,\"birthMonth\":12,\"birthDay\":17,\"birthCountry\":\"D.R.\",\"birthState\":\"La Romana\",\"birthCity\":\"La Romana\",\"deathYear\":null,\"deathMonth\":null,\"deathDay\":null,\"deathCountry\":null,\"deathState\":null,\"deathCity\":null,\"nameFirst\":\"Fernando\",\"nameLast\":\"Abad\",\"nameGiven\":\"Fernando Antonio\",\"weight\":220,\"height\":73,\"bats\":\"L\",\"throws\":\"L\",\"debut\":\"2010-07-28 00:00:00\",\"finalGame\":\"2017-10-01 00:00:00\",\"retroId\":\"abadf001\",\"bbrefId\":\"abadfe01\"}";
        private const string person07 = "{\"playerId\":\"abadijo01\",\"birthYear\":1850,\"birthMonth\":11,\"birthDay\":4,\"birthCountry\":\"USA\",\"birthState\":\"PA\",\"birthCity\":\"Philadelphia\",\"deathYear\":1905,\"deathMonth\":5,\"deathDay\":17,\"deathCountry\":\"USA\",\"deathState\":\"NJ\",\"deathCity\":\"Pemberton\",\"nameFirst\":\"John\",\"nameLast\":\"Abadie\",\"nameGiven\":\"John W.\",\"weight\":192,\"height\":72,\"bats\":\"R\",\"throws\":\"R\",\"debut\":\"1875-04-26 00:00:00\",\"finalGame\":\"1875-06-10 00:00:00\",\"retroId\":\"abadj101\",\"bbrefId\":\"abadijo01\"}";
        private const string person08 = "{\"playerId\":\"abbated01\",\"birthYear\":1877,\"birthMonth\":4,\"birthDay\":15,\"birthCountry\":\"USA\",\"birthState\":\"PA\",\"birthCity\":\"Latrobe\",\"deathYear\":1957,\"deathMonth\":1,\"deathDay\":6,\"deathCountry\":\"USA\",\"deathState\":\"FL\",\"deathCity\":\"Fort Lauderdale\",\"nameFirst\":\"Ed\",\"nameLast\":\"Abbaticchio\",\"nameGiven\":\"Edward James\",\"weight\":170,\"height\":71,\"bats\":\"R\",\"throws\":\"R\",\"debut\":\"1897-09-04 00:00:00\",\"finalGame\":\"1910-09-15 00:00:00\",\"retroId\":\"abbae101\",\"bbrefId\":\"abbated01\"}";
        private const string person09 = "{\"playerId\":\"abbeybe01\",\"birthYear\":1869,\"birthMonth\":11,\"birthDay\":11,\"birthCountry\":\"USA\",\"birthState\":\"VT\",\"birthCity\":\"Essex\",\"deathYear\":1962,\"deathMonth\":6,\"deathDay\":11,\"deathCountry\":\"USA\",\"deathState\":\"VT\",\"deathCity\":\"Colchester\",\"nameFirst\":\"Bert\",\"nameLast\":\"Abbey\",\"nameGiven\":\"Bert Wood\",\"weight\":175,\"height\":71,\"bats\":\"R\",\"throws\":\"R\",\"debut\":\"1892-06-14 00:00:00\",\"finalGame\":\"1896-09-23 00:00:00\",\"retroId\":\"abbeb101\",\"bbrefId\":\"abbeybe01\"}";
        private const string person10 = "{\"playerId\":\"abbeych01\",\"birthYear\":1866,\"birthMonth\":10,\"birthDay\":14,\"birthCountry\":\"USA\",\"birthState\":\"NE\",\"birthCity\":\"Falls City\",\"deathYear\":1926,\"deathMonth\":4,\"deathDay\":27,\"deathCountry\":\"USA\",\"deathState\":\"CA\",\"deathCity\":\"San Francisco\",\"nameFirst\":\"Charlie\",\"nameLast\":\"Abbey\",\"nameGiven\":\"Charles S.\",\"weight\":169,\"height\":68,\"bats\":\"L\",\"throws\":\"L\",\"debut\":\"1893-08-16 00:00:00\",\"finalGame\":\"1897-08-19 00:00:00\",\"retroId\":\"abbec101\",\"bbrefId\":\"abbeych01\"}";

        private const string person01Id = "aardsda01";
        private const string person02Id = "aaronha01";
        private const string person03Id = "aaronto01";
        private const string person04Id = "aasedo01";
        private const string person05Id = "abadan01";
        private const string person06Id = "abadfe01";
        private const string person07Id = "abadijo01";
        private const string person08Id = "abbated01";
        private const string person09Id = "abbeybe01";
        private const string person10Id = "abbeych01";
        #endregion

        #region private
        private Mock<BarStoolLeagueContext> contextMock;
        private readonly Dictionary<string, Person> peopleList = new Dictionary<string, Person>();
        #endregion

        #region setup
        private void PopulatePersonList()
        {
            peopleList.Clear();

            DeserializeAndAddTo(person01, person01Id);
            DeserializeAndAddTo(person02, person02Id);
            DeserializeAndAddTo(person03, person03Id);
            DeserializeAndAddTo(person04, person04Id);
            DeserializeAndAddTo(person05, person05Id);
            DeserializeAndAddTo(person06, person06Id);
            DeserializeAndAddTo(person07, person07Id);
            DeserializeAndAddTo(person08, person08Id);
            DeserializeAndAddTo(person09, person09Id);
            DeserializeAndAddTo(person10, person10Id);
        }

        private void DeserializeAndAddTo(string json, string key)
        {
            var peep = new Person();
            JsonConvert.PopulateObject(json, peep);
            peopleList.Add(key, peep);
        }

        public PersonControllerTests()
        {
            PopulatePersonList();
            contextMock = new Mock<BarStoolLeagueContext>();
            var returnPerson = new Person();

            //contextMock
            //    .Setup(m => m.GetById(It.IsAny<string>()))
            //    .Callback<string>(s => returnPerson = peopleList[s])
            //    .Returns(() => returnPerson);

            //contextMock
            //    .Setup(m => m.Get(It.IsAny<int>(), It.IsAny<int>()))
            //    .Returns(peopleList.Values.Take(50).AsQueryable());

            //contextMock
            //    .Setup(m => m.TotalCount)
            //    .Returns(peopleList.Count);
        }
        #endregion

        //#region tests
        //[Fact]
        //public void GetPerson_ById_ValidId_ShouldReturnCorrectPerson()
        //{
        //    // arrange
        //    var tested = new PersonController(contextMock.Object);
        //    var expected = "David Aardsma";

        //    // act
        //    var actual = tested.GetPerson(person01Id);

        //    // assert
        //    Assert.Equal(expected, $"{actual.Value.NameFirst} {actual.Value.NameLast}");
        //}

        //#endregion
    }
}
