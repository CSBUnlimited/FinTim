﻿using FinAndTime.Entities;
using FinAndTime.Methods;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FinAndTime.DataAccess
{
    public static class SqliteConnector
    {
        private static readonly object readWriteLock = new object();
        private static readonly string _password = "1234";
        private static readonly string _databasePath = FinTimApplication.AppSettings.SQLiteDatabasePath;
        public static readonly string LastInsertedIdQuery = "SELECT last_insert_rowid()";

        /// <summary>
        /// Create new database connection, not opened
        /// </summary>
        public static SQLiteConnection GetConnection
        {
            get
            {
                SQLiteConnection connection = FinTimApplication.DependancyContainer.GetInstance<SQLiteConnection>();
                //connection.SetPassword(_password);
                return connection;
            }
        }

        public static bool IsDatabaseInitialized => File.Exists(_databasePath);

        /// <summary>
        /// Execute Query Async
        /// </summary>
        /// <typeparam name="T">Type of list need to returned</typeparam>
        /// <param name="query">Query</param>
        /// <param name="readerFunc">Reader function</param>
        /// <param name="parameters">Optional. Parameters</param>
        /// <param name="isNeedTransactionBlock">Optional. IsNeedTransactionBlock default false</param>
        /// <returns>List of T</returns>
        public static async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, Func<SQLiteDataReader, T> readerFunc, IEnumerable<KeyValuePair<string, object>> parameters = null, bool isNeedTransactionBlock = false)
        {
            IList<T> items = new List<T>();

            await Task.Run(() =>
            {
                using (SQLiteConnection conn = GetConnection)
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = query;
                        if (parameters != null && parameters.Count() > 0)
                        {
                            foreach (KeyValuePair<string, object> parameter in parameters)
                            {
                                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                            }
                        }
                        cmd.Prepare();


                        lock (readWriteLock)
                        {
                            conn.Open();
                            SQLiteTransaction transaction = null;
                            try
                            {
                                if (isNeedTransactionBlock)
                                {
                                    transaction = conn.BeginTransaction();
                                }

                                using (SQLiteDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        items.Add(readerFunc(reader));
                                    }
                                }

                                transaction?.Commit();
                            }
                            catch
                            {
                                transaction?.Rollback();
                                throw;
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                    }
                }
            });

            return items;
        }

        /// <summary>
        /// Execute Query Single Or Default Async
        /// </summary>
        /// <typeparam name="T">Type of list need to returned</typeparam>
        /// <param name="query">Query</param>
        /// <param name="readerFunc">Reader function</param>
        /// <param name="parameters">Optional. Parameters</param>
        /// <param name="isNeedTransactionBlock">Optional. IsNeedTransactionBlock default false</param>
        /// <returns>List of T</returns>
        public static async Task<T> ExecuteQuerySingleOrDefaultAsync<T>(string query, Func<SQLiteDataReader, T> readerFunc, IEnumerable<KeyValuePair<string, object>> parameters = null, bool isNeedTransactionBlock = false)
        {
            T item = default;

            await Task.Run(() =>
            {
                using (SQLiteConnection conn = GetConnection)
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = query;
                        if (parameters != null && parameters.Count() > 0)
                        {
                            foreach (KeyValuePair<string, object> parameter in parameters)
                            {
                                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                            }
                        }
                        cmd.Prepare();

                        lock (readWriteLock)
                        {
                            conn.Open();
                            SQLiteTransaction transaction = null;
                            try
                            {
                                if (isNeedTransactionBlock)
                                {
                                    transaction = conn.BeginTransaction();
                                }

                                using (SQLiteDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        item = readerFunc(reader);
                                    }
                                }

                                transaction?.Commit();
                            }
                            catch
                            {
                                transaction?.Rollback();
                                throw;
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                    }
                }
            });

            return item;
        }

        /// <summary>
        /// Execute Non Query - Async
        /// </summary>
        /// <param name="query">Query</param>
        /// <param name="parameters">Optional. Parameters</param>
        /// <param name="isNeedTransactionBlock">Optional. IsNeedTransactionBlock default false</param>
        /// <returns>Changes count</returns>
        public static async Task<int> ExecuteNonQueryAsync(string query, IEnumerable<KeyValuePair<string, object>> parameters = null, bool isNeedTransactionBlock = false)
        {
            int changesCount = -1;

            await Task.Run(() =>
            {
                using (SQLiteConnection conn = GetConnection)
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = query;
                        if (parameters != null && parameters.Count() > 0)
                        {
                            foreach (KeyValuePair<string, object> parameter in parameters)
                            {
                                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                            }
                        }
                        cmd.Prepare();

                        lock (readWriteLock)
                        {
                            conn.Open();
                            SQLiteTransaction transaction = null;
                            try
                            {
                                if (isNeedTransactionBlock)
                                {
                                    transaction = conn.BeginTransaction();
                                }

                                changesCount = cmd.ExecuteNonQuery();

                                transaction?.Commit();
                            }
                            catch
                            {
                                transaction?.Rollback();
                                throw;
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                    }
                }
            });

            return changesCount;
        }

        /// <summary>
        /// Execute Insert Query - Async
        /// </summary>
        /// <param name="query">Query</param>
        /// <param name="parameters">Optional. Parameters</param>
        /// <param name="isNeedTransactionBlock">Optional. IsNeedTransactionBlock default false</param>
        /// <returns>Inseted Id</returns>
        public static async Task<int> ExecuteInsertQueryAsync(string query, IEnumerable<KeyValuePair<string, object>> parameters = null, bool isNeedTransactionBlock = false)
        {
            int insertedId = -1;

            await Task.Run(() =>
            {
                using (SQLiteConnection conn = GetConnection)
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = query;
                        if (parameters != null && parameters.Count() > 0)
                        {
                            foreach (KeyValuePair<string, object> parameter in parameters)
                            {
                                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                            }
                        }
                        cmd.Prepare();

                        lock (readWriteLock)
                        {
                            conn.Open();
                            SQLiteTransaction transaction = null;
                            try
                            {
                                if (isNeedTransactionBlock)
                                {
                                    transaction = conn.BeginTransaction();
                                }

                                int changesCount = cmd.ExecuteNonQuery();

                                if (changesCount > 0)
                                {
                                    cmd.CommandText = LastInsertedIdQuery;
                                    cmd.Prepare();

                                    insertedId = int.Parse(cmd.ExecuteScalar().ToString());
                                }

                                transaction?.Commit();
                            }
                            catch
                            {
                                transaction?.Rollback();
                                throw;
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                    }
                }
            });

            return insertedId;
        }

        /// <summary>
        /// Execute Scalar - Async
        /// </summary>
        /// <typeparam name="T">Type need to returned</typeparam>
        /// <param name="query">Query</param>
        /// <param name="parameters">Optional. Parameters</param>
        /// <param name="isNeedTransactionBlock">Optional. IsNeedTransactionBlock default false</param>
        /// <returns>T</returns>
        public static async Task<T> ExecuteScalarAsync<T>(string query, Func<string, T> stringToTypeCast, IEnumerable<KeyValuePair<string, object>> parameters = null, bool isNeedTransactionBlock = false)
        {
            T result = default;

            await Task.Run(() =>
            {
                using (SQLiteConnection conn = GetConnection)
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = query;
                        if (parameters != null && parameters.Count() > 0)
                        {
                            foreach (KeyValuePair<string, object> parameter in parameters)
                            {
                                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                            }
                        }
                        cmd.Prepare();

                        lock (readWriteLock)
                        {
                            conn.Open();
                            SQLiteTransaction transaction = null;
                            try
                            {
                                if (isNeedTransactionBlock)
                                {
                                    transaction = conn.BeginTransaction();
                                }

                                result = stringToTypeCast(cmd.ExecuteScalar().ToString());

                                transaction?.Commit();
                            }
                            catch
                            {
                                transaction?.Rollback();
                                throw;
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                    }
                }
            });

            return result;
        }

        /// <summary>
        /// Initialize Database
        /// </summary>
        public static void InitializeDatabase()
        {
            if (IsDatabaseInitialized)
            {
                return;
            }

            SQLiteConnection.CreateFile(_databasePath);

            using (SQLiteConnection conn = GetConnection)
            {
                conn.Open();
                //conn.ChangePassword(_password);
                conn.Close();
            }

            using (SQLiteConnection conn = GetConnection)
            {
                conn.Open();
                SQLiteTransaction transaction = conn.BeginTransaction();
                try
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        #region Create Tables

                        cmd.CommandText =
                            @"CREATE TABLE `User` (
	                            `Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                            `FirstName`	TEXT NOT NULL,
	                            `LastName`	TEXT NOT NULL,
	                            `RegisteredDateTime`	INTEGER NOT NULL,
	                            `StartingAmount`	NUMERIC NOT NULL,
	                            `CurrentBalance`	NUMERIC NOT NULL,
	                            `LastCheckDateTime`	INTEGER NOT NULL
                            );";
                        cmd.ExecuteNonQuery();
                        Thread.Sleep(500);

                        cmd.CommandText =
                            @"CREATE TABLE `TransactionLog` (
	                            `Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                            `TransactionId`	INTEGER NOT NULL,
	                            `ScheduledTransactionId`	INTEGER,
	                            `TransactionPartyId`	INTEGER NOT NULL,
	                            `IsDeletedTransaction`	INTEGER NOT NULL,
	                            `IsIncome`	INTEGER NOT NULL,
	                            `TransactionDateTime`	INTEGER NOT NULL,
	                            `Amount`	NUMERIC NOT NULL,
	                            `StartingBalance`	NUMERIC NOT NULL,
	                            `FinalBalance`	NUMERIC NOT NULL,
	                            `Remarks`	TEXT NOT NULL,
	                            `CreatedDateTime`	INTEGER NOT NULL,
	                            `IsUserPerformed`	INTEGER NOT NULL
                            );";
                        cmd.ExecuteNonQuery();
                        Thread.Sleep(500);

                        cmd.CommandText =
                            @"CREATE TABLE `Transaction` (
	                            `Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                            `ReferenceNumber`	TEXT,
	                            `TransactionPartyId`	INTEGER NOT NULL,
	                            `Amount`	NUMERIC NOT NULL,
	                            `IsIncome`	INTEGER NOT NULL,
	                            `TransactionDateTime`	INTEGER NOT NULL,
	                            `ScheduledTransactionId`	INTEGER,
	                            `Remarks`	TEXT,
	                            `IsUserPerformed`	INTEGER NOT NULL DEFAULT 0,
	                            `CreatedDateTime`	INTEGER NOT NULL,
	                            `IsActive`	INTEGER NOT NULL DEFAULT 1
                            );";
                        cmd.ExecuteNonQuery();
                        Thread.Sleep(500);

                        cmd.CommandText =
                            @"CREATE TABLE `ScheduledTransaction` (
	                            `Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                            `Amount`	NUMERIC NOT NULL,
	                            `TransactionPartyId`	INTEGER NOT NULL,
	                            `Remarks`	TEXT NOT NULL,
	                            `RepeatPeriod`	INTEGER NOT NULL,
	                            `RepeatValue`	INTEGER NOT NULL,
	                            `RepeatCount`	INTEGER NOT NULL DEFAULT 1,
	                            `OccuredCount`	INTEGER NOT NULL DEFAULT 0,
	                            `LastOccuredDateTime`	INTEGER,
	                            `CreatedDateTime`	INTEGER NOT NULL,
	                            `IsActive`	INTEGER NOT NULL DEFAULT 1
                            );";
                        cmd.ExecuteNonQuery();
                        Thread.Sleep(500);

                        cmd.CommandText =
                            @"CREATE TABLE `TransactionParty` (
	                            `Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                            `Code`	TEXT NOT NULL UNIQUE,
	                            `Description`	TEXT NOT NULL,
	                            `CreatedDateTime`	INTEGER NOT NULL,
	                            `IsActive`	INTEGER NOT NULL DEFAULT 1
                            );";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText =
                            @"INSERT INTO `TransactionParty`
                            (`Id`,`Code`,`Description`,`CreatedDateTime`) 
                            VALUES (1,'OWN','Owner Party'," + TimeConverterMethods.ConvertDateTimeToTimeStamp(DateTime.Now).ToString() + ");";
                        cmd.ExecuteNonQuery();

                        Thread.Sleep(500);

                        cmd.CommandText =
                            @"CREATE TABLE `SkipTransaction` (
	                            `Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                            `ScheduledTransactionId`	TEXT NOT NULL,
	                            `SkipCount`	INTEGER NOT NULL,
	                            `EffectedCount`	BLOB NOT NULL DEFAULT 0,
	                            `Remarks`	TEXT NOT NULL,
	                            `IsActive`	INTEGER NOT NULL DEFAULT 1,
	                            `CreatedDateTime`	INTEGER NOT NULL,
	                            `LastEffectedDateTime`	INTEGER
                            );";
                        cmd.ExecuteNonQuery();
                        Thread.Sleep(500);

                        #endregion
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
