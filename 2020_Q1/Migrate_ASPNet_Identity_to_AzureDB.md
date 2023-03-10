# Migrate ASP.Net Identity db to Azure db

Read AspNetUsers table from SQLite file and write to Azure DB

The AspNetUsers table has merged with our extension in ApplicationUser

```C#

    public class ApplicationUser : IdentityUser
    {
        public string Department { get; set; }
        public string Group { get; set; }
    }

```

```C#
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Text;

namespace MigrateDB
{
    public class ASPNetUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public int EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }

        public string PhoneNumber { get; set; }
        public int PhoneNumberConfirmed { get; set; }
        public int TwoFactorEnabled { get; set; }
        public string LockoutEnd { get; set; }
        public int LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Department { get; set; }
        public string Group { get; set; }
    }

    class MigrateASPNetIdentity
    {
        private string cnStringAzureDB { get; set; }

        public MigrateASPNetIdentity()
        {
            // needs to replace the [Initial Catalog] and [User ID] below.

            cnStringAzureDB = "Server=tcp:gportaldb.database.windows.net,1433;Initial Catalog=gportalaccounts;Persist Security Info=False;User ID={ID_HERE};Password={PASS_HERE};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public void Migrate()
        {
            List<ASPNetUser> sources = ReadFromSQLite();

            foreach (var record in sources)
            {
                InsertRecord(record);
            }
        }

        private void InsertRecord(ASPNetUser user)
        {
            // Create SQL statement to submit
            // the [@Department] and [@Group] are our extension !  We only put [Department] here as [Group] is a SQL keyword which will cause problem.
            string sql = "INSERT INTO AspNetUsers(Id, UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount,Department)";
            sql += " VALUES(@Id,@UserName,@NormalizedUserName,@Email,@NormalizedEmail,@EmailConfirmed,@PasswordHash,@SecurityStamp,@ConcurrencyStamp,@PhoneNumber,@PhoneNumberConfirmed,@TwoFactorEnabled,@LockoutEnd,@LockoutEnabled,@AccessFailedCount,@Department)";

            try
            {
                // Create SQL connection object in using block for automatic closing and disposing
                using (SqlConnection cnn = new SqlConnection(cnStringAzureDB))
                {
                    // Open the connection
                    cnn.Open();

                    // Create command object in using block for automatic disposal
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        // Create input parameters
                        cmd.Parameters.Add(new SqlParameter("@Id", user.Id));
                        cmd.Parameters.Add(new SqlParameter("@UserName", user.UserName));
                        cmd.Parameters.Add(new SqlParameter("@NormalizedUserName", user.NormalizedUserName));
                        cmd.Parameters.Add(new SqlParameter("@Email", user.Email));
                        cmd.Parameters.Add(new SqlParameter("@NormalizedEmail", user.NormalizedEmail));

                        cmd.Parameters.Add(new SqlParameter("@EmailConfirmed", user.EmailConfirmed));
                        cmd.Parameters.Add(new SqlParameter("@PasswordHash", user.PasswordHash));
                        cmd.Parameters.Add(new SqlParameter("@SecurityStamp", user.SecurityStamp));
                        cmd.Parameters.Add(new SqlParameter("@ConcurrencyStamp", user.ConcurrencyStamp));
                        cmd.Parameters.Add(new SqlParameter("@PhoneNumber", user.PhoneNumber));

                        cmd.Parameters.Add(new SqlParameter("@PhoneNumberConfirmed", user.PhoneNumberConfirmed));
                        cmd.Parameters.Add(new SqlParameter("@TwoFactorEnabled", user.TwoFactorEnabled));
                        cmd.Parameters.Add(new SqlParameter("@LockoutEnd", user.LockoutEnd));
                        cmd.Parameters.Add(new SqlParameter("@LockoutEnabled", user.LockoutEnabled));
                        cmd.Parameters.Add(new SqlParameter("@AccessFailedCount", user.AccessFailedCount));

                        // the [@Department] and [@Group] are our extension !
                        cmd.Parameters.Add(new SqlParameter("@Department", user.Department));
                        //cmd.Parameters.Add(new SqlParameter("@Group", user.Group));

                        // Set CommandType

                        cmd.CommandType = CommandType.Text;
                        // Execute the INSERT statement
                        var RowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine("Populate to azure db - {0}", user.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }


        private List<ASPNetUser> ReadFromSQLite()
        {
            // read sqlite database
            string sqliteCNString = @"Data Source=C:\MyProjects\GPortal\migrate_aspnet_identity_db\signoff.identity.local.db";

            List<ASPNetUser> records = new List<ASPNetUser>();

            // Create a connection
            using (var cnn = new SQLiteConnection(sqliteCNString))
            {
                // Open the connection
                cnn.Open();

                // Create command object
                string command = "select Id, UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount,Department,`Group` from AspNetUsers;";
                using (var cmd = new SQLiteCommand(command, cnn))
                {
                    using (var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            ASPNetUser oneRecord = new ASPNetUser();

                            {
                                oneRecord.Id = dr["Id"].ToString();
                                oneRecord.UserName = dr["UserName"].ToString();
                                oneRecord.NormalizedUserName = dr["NormalizedUserName"].ToString();
                                oneRecord.Email = dr["Email"].ToString();
                                oneRecord.NormalizedEmail = dr["NormalizedEmail"].ToString();

                                oneRecord.EmailConfirmed = 0;
                                if (dr["EmailConfirmed"].ToString().Equals("1"))
                                {
                                    oneRecord.EmailConfirmed = 1;
                                }

                                oneRecord.PasswordHash = dr["PasswordHash"].ToString();
                                oneRecord.SecurityStamp = dr["SecurityStamp"].ToString();
                                oneRecord.ConcurrencyStamp = dr["ConcurrencyStamp"].ToString();

                                oneRecord.PhoneNumber = dr["PhoneNumber"].ToString();

                                oneRecord.PhoneNumberConfirmed = 0;
                                if (dr["PhoneNumberConfirmed"].ToString().Equals("1"))
                                {
                                    oneRecord.PhoneNumberConfirmed = 1;
                                }

                                oneRecord.TwoFactorEnabled = 0;
                                if (dr["TwoFactorEnabled"].ToString().Equals("1"))
                                {
                                    oneRecord.TwoFactorEnabled = 1;
                                }

                                oneRecord.LockoutEnd = dr["LockoutEnd"].ToString();

                                oneRecord.LockoutEnabled = 0;
                                if (dr["LockoutEnabled"].ToString().Equals("1"))
                                {
                                    oneRecord.LockoutEnabled = 1;
                                }

                                oneRecord.AccessFailedCount = 0;
                                if (dr["AccessFailedCount"].ToString().Equals("1"))
                                {
                                    oneRecord.AccessFailedCount = 1;
                                }

                                oneRecord.Department = dr["Department"].ToString();
                                oneRecord.Group = dr["Group"].ToString();
                            }

                            records.Add(oneRecord);
                        }
                    }
                }
            }

            return records;
        }
    }
}

```
