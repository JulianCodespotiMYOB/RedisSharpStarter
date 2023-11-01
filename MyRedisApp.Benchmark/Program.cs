using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Dapper;

namespace MyRedisApp.Benchmark;

public class Program
{
    public static void Main(string[] args)
    {
        //SetupDatabase();
        var config = DefaultConfig.Instance.WithOptions(ConfigOptions.DisableOptimizationsValidator);
        //BenchmarkRunner.Run<SqlBenchmark>(config);
        BenchmarkRunner.Run<RedisBenchmark>(config);
    }

    private static void SetupDatabase()
    {
        var sqlConnectionService = new SqlConnectionService("Server=localhost,1433;Database=BenchmarkDb;User Id=sa;Password=SQLDatabase123;");
        using var masterDbConnection = sqlConnectionService.GetMasterDatabaseConnection();
        masterDbConnection.Open();

        // Create BenchmarkDb if it doesn't exist
        masterDbConnection.Execute(@"
        IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'BenchmarkDb')
        BEGIN
            CREATE DATABASE BenchmarkDb;
        END");

        using var dbConnection = sqlConnectionService.GetDatabaseConnection();
        dbConnection.Open();
        
        // Create YourTable if it doesn't exist
        dbConnection.Execute(@"
        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'BenchmarkTable')
        BEGIN
            CREATE TABLE BenchmarkTable
            (
                MyColumn NVARCHAR(256) PRIMARY KEY,
                Value NVARCHAR(MAX)
            );
        END");
    }
}