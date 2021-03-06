﻿#region Licenses
/*MIT License
Copyright(c) 2020
Robert Garrison

Permission Is hereby granted, free Of charge, To any person obtaining a copy
of this software And associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, And/Or sell
copies Of the Software, And To permit persons To whom the Software Is
furnished To Do so, subject To the following conditions:

The above copyright notice And this permission notice shall be included In all
copies Or substantial portions Of the Software.

THE SOFTWARE Is PROVIDED "AS IS", WITHOUT WARRANTY Of ANY KIND, EXPRESS Or
IMPLIED, INCLUDING BUT Not LIMITED To THE WARRANTIES Of MERCHANTABILITY,
FITNESS For A PARTICULAR PURPOSE And NONINFRINGEMENT. In NO Event SHALL THE
AUTHORS Or COPYRIGHT HOLDERS BE LIABLE For ANY CLAIM, DAMAGES Or OTHER
LIABILITY, WHETHER In AN ACTION Of CONTRACT, TORT Or OTHERWISE, ARISING FROM,
OUT Of Or In CONNECTION With THE SOFTWARE Or THE USE Or OTHER DEALINGS In THE
SOFTWARE*/
#endregion
#region Using Statements
using AdoNetCore.AseClient;
using ADONetHelper.Core;
using System.Data;
#endregion

namespace ADONetHelper.ASE
{
    /// <summary>
    /// A specialized instance of <see cref="DbClient"/> that is used to query an ASE database system
    /// </summary>
    /// <seealso cref="DbClient"/>
    public class ASEClient : DbClient
    {
        #region Events
        /// <summary>
        /// An event that is triggered for any message or warning sent by the database
        /// </summary>
        /// <remarks>
        /// In order to respond to warnings and messages from the database, the client should create an <see cref="AseInfoMessageEventHandler" /> delegate to listen to this event.
        /// </remarks>
        public event AseInfoMessageEventHandler InfoMessage
        {
            add
            {
                //Get an exclusive lock first
                lock (Connection)
                {
                    Connection.InfoMessage += value;
                }
            }
            remove
            {
                //Get an exclusive lock first
                lock (Connection)
                {
                    Connection.InfoMessage -= value;
                }
            }
        }
        #endregion
        #region Fields/Properties
        /// <summary>
        /// An instance of <see cref="AseConnection"/> to use to connect to an ASE database
        /// </summary>
        /// <returns></returns>
        protected AseConnection Connection
        {
            get
            {
                //Return this back to the caller
                return (AseConnection)ExecuteSQL.Connection;
            }
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Insantiates a new instance of <see cref="ASEClient"/> using the passed in <paramref name="connectionString"/> And <paramref name="queryCommandType"/>
        /// </summary>
        /// <param name="connectionString">The connection string used to query a data store</param>
        /// <param name="queryCommandType">Represents how a command should be interpreted by the data provider</param>
        public ASEClient(string connectionString, CommandType queryCommandType) : base(connectionString, queryCommandType, AseClientFactory.Instance)
        { 
        }
        /// <summary>
        /// Insantiates a new instance of <see cref="ASEClient"/> using the passed in <paramref name="connectionString"/>
        /// </summary>
        /// <param name="connectionString">The connection string used to query a data store</param>
        public ASEClient(string connectionString) : base(connectionString, AseClientFactory.Instance)
        {
        }
        /// <summary>
        /// Insantiates a new instance of <see cref="ASEClient"/> using the passed in <paramref name="executor"/>
        /// </summary>
        /// <param name="executor">An instance of <see cref="ISqlExecutor"/></param>
        public ASEClient(ISqlExecutor executor) : base(executor)
        {
        }
        /// <summary>
        /// Insantiates a new instance of <see cref="ASEClient"/> using the passed in <paramref name="connection" />
        /// </summary>
        /// <param name="connection">An instance of <see cref="AseConnection"/> to use to query a database</param>
        public ASEClient(AseConnection connection) : base(connection)
        {       
        }
        /// <summary>
        /// Insantiates a new instance of <see cref="ASEClient"/> using the passed in <paramref name="connectionString"/> and <paramref name="factory"/>
        /// </summary>
        /// <param name="connectionString">Connection string to use to query a database</param>
        /// <param name="factory">An instance of <see cref="IDbObjectFactory"/></param>
        public ASEClient(string connectionString, IDbObjectFactory factory) : base(connectionString, factory)
        {
        }
        /// <summary>
        /// Constructor to query a database using an existing <see cref="AseConnection"/> to initialize the <paramref name="connection"/>
        /// </summary>
        /// <param name="connection">An instance of <see cref="AseConnection"/> to use to query a database </param>
        /// <param name="commandType">Represents how a command should be interpreted by the data provider</param>
        public ASEClient(AseConnection connection, CommandType commandType) : base(connection, commandType)
        {
        }
        #endregion
    }
}