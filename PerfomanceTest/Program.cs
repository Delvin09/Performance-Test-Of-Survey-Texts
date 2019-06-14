using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace PerfomanceTest
{
    public class IntellGroupDatabasePerfTest
    {
        private readonly List<string> _queriesList = new List<string>();
        private SqlConnection _connection;
        private SqlCommand[] _commands;

        [GlobalSetup]
        public void GlobalInit()
        {
            var allVariants = Queries.ColumnNames.Select(col => string.Format(Queries.GetDupItem, col)).ToArray();
            _queriesList.AddRange(allVariants);
        }

        [IterationSetup(Target = nameof(IntellGroup_AfterCleanup))]
        public void IterationSetupAfterCleanup()
        {
            _connection = new SqlConnection(@"Data Source=EFISCO-OFIL;Encrypt=False;Integrated Security=True;Initial Catalog=zSulaPNL_20180413104126_intelligencegroup_1eced1591d9743b5913cd95ffb7be73a");
            _connection.Open();
            _commands = _queriesList.Select(q => new SqlCommand(q, _connection)).ToArray();
        }

        [IterationSetup(Target = nameof(IntellGroup_BeforeCleanup))]
        public void IterationSetupBeforeCleanup()
        {
            _connection = new SqlConnection(@"Data Source=EFISCO-OFIL;Encrypt=False;Integrated Security=True;Initial Catalog=zSulaPNL_20180413104126_intelligencegroup_1eced1591d9743b5913cd95ffb7be73a_copy");
            _connection.Open();
            _commands = _queriesList.Select(q => new SqlCommand(q, _connection)).ToArray();
        }

        [IterationSetup(Target = nameof(DemoDb))]
        public void IterationSetupDemoDb()
        {
            Console.WriteLine("Start local B");
            _connection = new SqlConnection(@"Data Source=EFISCO-OFIL;Encrypt=False;Integrated Security=True;Initial Catalog=zClient_20190603143232_demo_0053e79d0981494a86b927f5cad88fe7");
            _connection.Open();
            _commands = _queriesList.Select(q => new SqlCommand(q, _connection)).ToArray();
            Console.WriteLine("End local B");
        }

        [IterationCleanup]
        public void IterationCleanup()
        {
            foreach (var command in _commands)
            {
                command.Dispose();
            }

            _connection.Close();
            _commands = null;
            _connection = null;
        }

        [Benchmark]
        public void IntellGroup_BeforeCleanup()
        {
            foreach (var command in _commands)
            {
                using (var reader = command.ExecuteReader())
                {
                    //while (reader.Read())
                    //{

                    //}
                }
            }
        }

        [Benchmark(Baseline = true)]
        public void IntellGroup_AfterCleanup()
        {
            foreach (var command in _commands)
            {
                using (var reader = command.ExecuteReader())
                {
                    //while (reader.Read())
                    //{

                    //}
                }
            }
        }

        [Benchmark]
        public void DemoDb()
        {
            foreach (var command in _commands)
            {
                using (var reader = command.ExecuteReader())
                {
                    //while (reader.Read())
                    //{

                    //}
                }
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<IntellGroupDatabasePerfTest>();
        }
    }
}
