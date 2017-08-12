using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using NUnit.Framework;
using spotsATF.TestSteps.Interfaces;

namespace spotsATF.TestSteps.TestStepLibrary.Database.Sql.User
{
    public class User
    {
        private string _email;

        private readonly SqlConnection _connection;
        private SqlCommand _command;

        private string _wClause;
        private readonly string _table;
        private string _query;

        public User()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connection = new SqlConnection(connectionString);
            _table = "FROM AspNetUsers";
        }

        public User WithEmail(string email)
        {
            _email = email;
            _wClause = " WHERE Email = '" + _email + "'";
            return this;
        }

        public IVerificationTestStep Exists
        {
            get
            {
                return new VerificationTestStep((driver) =>
                {
                    Assert.IsNotNull(_email, "User email has to be specified.");

                    _connection.Open();
                    _query = "Select Email " + _table + " " + _wClause;
                    _command = new SqlCommand(_query, _connection);

                    var list = new List<string>();
                    using (var reader = _command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            list.Add(reader["Email"].ToString());
                        }
                    }

                    Assert.That(list.Count > 0, $"User with email {_email} could not be found in the SQL database.");

                });
            }
        }

        public IActionTestStep Delete
        {
            get
            {
                return new ActionTestStep((driver) =>
                {
                    Assert.IsNotNull(_email, "User email has to be specified.");

                    _connection.Open();
                    _query = "DELETE " + _table + " " + _wClause;
                    _command = new SqlCommand(_query, _connection);

                    _command.ExecuteNonQuery();
                    _connection.Close();
                });
            }
        }

        public IVerificationTestStep WasDeleted
        {
            get
            {
                return new VerificationTestStep((driver) =>
                {
                    Assert.IsNotNull(_email, "User email has to be specified.");

                    _connection.Open();
                    _query = "Select Email " + _table + " " + _wClause;
                    _command = new SqlCommand(_query, _connection);

                    var list = new List<string>();
                    using (var reader = _command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            list.Add(reader["Email"].ToString());
                        }
                    }

                    Assert.AreEqual(0, list.Count, "User could not be deleted from SQL database.");
                });
            }
        }
    }
}
