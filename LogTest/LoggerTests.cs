using Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Data.SqlClient;
using System.IO;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Logging.Tests
{
    [TestClass]
    public class LoggerTests
    {
        private const string LogFilePath = "D:\\VS\\softwareDesign\\simpleCalculator\\Logs\\Calculator.log";
        private const string ConnectionString = "Data Source=rapist;Initial Catalog=Calculator;Integrated Security=True";

        [TestInitialize]
        public void Initialize()
        {
            // 清理测试之前可能存在的日志文件
            if (File.Exists(LogFilePath))
            {
                File.Delete(LogFilePath);
            }

            // 清理测试之前可能存在的数据库表
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand("TRUNCATE TABLE Logs", connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        [TestMethod]
        public void TestFileLogger()
        {
            // Arrange
            ILogger logger = new FileLogger(LogFilePath);

            // Act
            logger.Log("Test message");

            // Assert
            string logContent = File.ReadAllText(LogFilePath);
            Assert.IsTrue(logContent.Contains("Test message"));
        }

        [TestMethod]
        public void TestAdoNetLogger()
        {
            // Arrange
            ILogger logger = new AdoNetLogger(ConnectionString);

            // Act
            logger.Log("Test message");

            // Assert
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Logs WHERE Message = 'Test message'", connection))
            {
                connection.Open();
                int count = (int)command.ExecuteScalar();
                Assert.AreEqual(1, count);
            }
        }

        [TestMethod]
        public void TestEfLogger()
        {
            // Arrange
            ILogger logger = new EfLogger(new LogDbContext());

            // Act
            logger.Log("Test message");

            // Assert
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Logs WHERE Message = 'Test message'", connection))
            {
                connection.Open();
                int count = (int)command.ExecuteScalar();
                Assert.AreEqual(1, count);
            }
        }
    }
}
