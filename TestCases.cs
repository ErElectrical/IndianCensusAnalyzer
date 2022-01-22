using NUnit.Framework;
using IndianSensorAnalyzer.Poco;
using static IndianSensorAnalyzer.CensusAnalyzer;
using System.Collections.Generic;
using IndianSensorAnalyzer;
using System;


namespace IndianCensusTestCases
{
    public class Tests
    {

        public string indianSateCensusHeaders = "State,Population,AreaInsqkm,DensityPerSqKm";
        public string indianStateCodeHeaders = "SrNo,State Name,Tin,StateCode";
        public string indianCensusFilePath = @"C:\Users\as\Desktop\.net\IndianCensusAnalyzer\IndianCensusAnalyzer\FileFolder\IndiaStateCensusData.csv";
        public string indianStateCodeFilePath = @"C:\Users\as\Desktop\.net\IndianCensusAnalyzer\IndianCensusAnalyzer\FileFolder\IndiaStateCode.csv";

        public string wrongIndianStateCensusFilePath = @"C:\Users\as\Desktop\.net\IndianCensusAnalyzer\IndianCensusAnalyzer\WrongIndiaStateCensusData.csv ";
        public string WrongIndiaStateCodeFilePath = @"C:\Users\as\Desktop\.net\IndianCensusAnalyzer\WrongIndiaStateCensusData.csv ";

        public string wrongIndiaCensusFileType = @" C:\Users\as\Desktop\.net\IndianCensusAnalyzer\IndianCensusAnalyzer\FileFolder\IndianStateCensus.txt";
        public string WrongindianStateCodeFileType = @"C:\Users\as\Desktop\.net\IndianCensusAnalyzer\IndianCensusAnalyzer\FileFolder\WrongTypeIndiaStateCode.txt ";

        public string delimiterIndianCensusFilePath = @"C:\Users\as\Desktop\.net\IndianCensusAnalyzer\IndianCensusAnalyzer\FileFolder\IndianStateCensusDelimiter.csv ";
        public string delimiterIndianStateCodeFilePath = @"C:\Users\as\Desktop\.net\IndianCensusAnalyzer\IndianCensusAnalyzer\FileFolder\DelimiterIndiaStateCodes.csv ";

        public string WrongHeaderIndianCensusFilePath = @" C:\Users\as\Desktop\.net\IndianCensusAnalyzer\IndianCensusAnalyzer\FileFolder\WrongIndiaStateCensusData.csv";

        public string wrongIndianStateFileType = @"C:\Users\as\Desktop\.net\IndianCensusAnalyzer\IndianCensusAnalyzer\FileFolder\WrongHeaderIndiaStateCodes.csv ";

        IndianSensorAnalyzer.CensusAnalyzer censusAnalyzer;
        Dictionary<string, CensusDTO> totalRecords;
        Dictionary<string, CensusDTO> stateRecords;

        [SetUp]
        public void Setup()
        {
            censusAnalyzer = new IndianSensorAnalyzer.CensusAnalyzer();
            totalRecords = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();

        }

        [Test]
        public void GivenIndianCensusFile_WhenReaded_Should_Returns_CensusDataCount()

        {
            totalRecords = censusAnalyzer.LoadCensusData(Country.India, indianCensusFilePath, indianSateCensusHeaders);
            stateRecords = censusAnalyzer.LoadCensusData(Country.India, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(3, totalRecords.Count);
            Assert.AreEqual(4, stateRecords.Count);

        }

        [Test]
        public void GivenWrongIndianCensusDataFile_should_returns_customException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.India, wrongIndianStateCensusFilePath, indianSateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.India, WrongIndiaStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.File_Not_Found, censusException.etype);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.File_Not_Found, stateException.etype);





        }

        [Test]

        public void GivenWrongIndianCensusDataFileType_Should_Returns_aCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.India, wrongIndiaCensusFileType, indianSateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.India, WrongindianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Invalid_File_Type, censusException.etype);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Invalid_File_Type, stateException.etype);

        }

        [Test]
        public void GivenWrongDelimiterShould_Throw_Custom_Exception()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.India, delimiterIndianCensusFilePath, indianSateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.India, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Incorrect_Delimiter, censusException.etype);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Incorrect_Delimiter, stateException.etype);

        }

        public void WrongHeader_should_returns_customExcption_ifreaded()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.India, WrongHeaderIndianCensusFilePath, indianSateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.India, wrongIndianStateFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Incorrect_Header, censusException.etype);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Incorrect_Header, stateException.etype);

        }


    }
}