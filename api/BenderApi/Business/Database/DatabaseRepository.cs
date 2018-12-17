using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using BenderApi.Models;
using System.Data.SQLite;
using System;
using Dapper;

namespace BenderApi.Business.Database{
    public class DatabaseRepository: IDatabaseRepository
    {

        private static string DbFile
        {
            get { return Environment.CurrentDirectory + "\\bender.db"; }
        }

        private SQLiteConnection DatabaseConnection(){
            if (!File.Exists(DbFile))
            {
                this.CreateDatabase();
            }
            
            return new SQLiteConnection("Data Source=" + DbFile);
        }

        public IEnumerable<Project> GetAllProjects(){
            using (var conn = DatabaseConnection())
            {
                var projects = conn.Query<Project>(@"select * from Projects");

                foreach(var project in projects){
                    project.DeployEnvironments = GetDeployEnvironments(project.Id);
                }

                return projects;
            }
        }

        private IEnumerable<DeployEnvironment> GetDeployEnvironments(int id){
            using (var conn = DatabaseConnection())
            {
                var environments = conn.Query<DeployEnvironment>(@"select * from Environments");
                var configurations = new List<BuildConfiguration>();

                foreach(var environment in environments){
                    var buildSteps = GetBuildSteps(environment.Id);
                    var buildConfiguration = new BuildConfiguration();
                    buildConfiguration.Steps = buildSteps;
                    buildConfiguration.ClearDestinationFolder = true;

                     environment.BuildConfiguration = buildConfiguration;
                }

               return environments;
            }
        }

        private IEnumerable<BuildStep> GetBuildSteps(int id){
            using (var conn = DatabaseConnection())
            {
                return conn.Query<BuildStep>(@"select * from BuildSteps");
            }
        }

        private void CreateDatabase()
        {
            var fs = File.Create(DbFile);
            fs.Close();

            using (var conn = DatabaseConnection())
            {
                conn.Open();
                conn.Execute(
                    @"CREATE TABLE `Projects` (
                    `Id`	INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
                    `ProjectName`	TEXT(100),
                    `ProjectId`	TEXT(100),
                    `Version`	TEXT(100),
                    `LastDeployAtUtc`	INTEGER)");

                conn.Execute(
                    @"CREATE TABLE `Logs` (
                    `Id`	INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
                    `ProjectId`	TEXT(100),
                    `ProjectVersion`	TEXT(100),
                    `LogText`	TEXT,
                    `CreatedAtUtc`	INTEGER)");

                conn.Execute(
                    @"CREATE TABLE `Environments` (
                    `Id`	INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
                    `EnvironmentName`	TEXT(100),
                    `Destination`	TEXT(255))");

                conn.Execute(
                    @"CREATE TABLE `BuildSteps` (
                    `Id`	INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
                    `EnvironmentId`	INTEGER,
                    `Application` TEXT(255),
					`Arguments` TEXT(255))");
            }
        }

    }
}