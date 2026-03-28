using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ShuttleZone.Membership
{
    internal static class DataAccess
    {
        private static readonly string ConnStr = "Server=127.0.0.1;Uid=root;Pwd=;Database=shuttlezone;SslMode=Disabled;";

        public static List<MemberModel> GetMembers(bool showArchived)
        {
            var list = new List<MemberModel>();

            using (var conn = new MySqlConnection(ConnStr))
            using (var cmd = conn.CreateCommand())
            {
                if (showArchived)
                    cmd.CommandText = "SELECT * FROM members WHERE is_archived = 1 ORDER BY id DESC;";
                else
                    cmd.CommandText = "SELECT * FROM members WHERE is_archived = 0 ORDER BY id DESC;";

                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new MemberModel
                        {
                            Id = rdr.GetInt32("id"),
                            MemberCode = rdr.IsDBNull(rdr.GetOrdinal("member_code")) ? null : rdr.GetString("member_code"),
                            Name = rdr.IsDBNull(rdr.GetOrdinal("name")) ? "" : rdr.GetString("name"),
                            Email = rdr.IsDBNull(rdr.GetOrdinal("email")) ? "" : rdr.GetString("email"),
                            Phone = rdr.IsDBNull(rdr.GetOrdinal("phone")) ? "" : rdr.GetString("phone"),
                            MembershipType = rdr.IsDBNull(rdr.GetOrdinal("membership_type")) ? "" : rdr.GetString("membership_type"),
                            ExpiryDate = rdr.IsDBNull(rdr.GetOrdinal("expiry_date")) ? (DateTime?)null : rdr.GetDateTime("expiry_date"),
                            JoinDate = rdr.IsDBNull(rdr.GetOrdinal("join_date")) ? (DateTime?)null : rdr.GetDateTime("join_date"),
                            IsArchived = rdr.GetInt32("is_archived") == 1
                        });
                    }
                }
            }

            return list;
        }

        public static int AddMember(MemberModel model)
        {
            using (var conn = new MySqlConnection(ConnStr))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO members (name, email, phone, membership_type, expiry_date, join_date) " +
                                  "VALUES (@name, @email, @phone, @mtype, @expiry, @join);";
                cmd.Parameters.AddWithValue("@name", model.Name ?? "");
                cmd.Parameters.AddWithValue("@email", model.Email ?? "");
                cmd.Parameters.AddWithValue("@phone", model.Phone ?? "");
                cmd.Parameters.AddWithValue("@mtype", model.MembershipType ?? "");
                cmd.Parameters.AddWithValue("@expiry", (object)model.ExpiryDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@join", (object)model.JoinDate ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                var id = (int)cmd.LastInsertedId;

                if (id > 0)
                {
                    using (var cmd2 = conn.CreateCommand())
                    {
                        cmd2.CommandText = "UPDATE members SET member_code=@code WHERE id=@id;";
                        cmd2.Parameters.AddWithValue("@code", $"M{id:D3}");
                        cmd2.Parameters.AddWithValue("@id", id);
                        cmd2.ExecuteNonQuery();
                    }
                }

                return id;
            }
        }

        public static bool UpdateMember(MemberModel model)
        {
            using (var conn = new MySqlConnection(ConnStr))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE members SET name=@name,email=@email,phone=@phone,membership_type=@mtype,expiry_date=@expiry,join_date=@join WHERE id=@id;";
                cmd.Parameters.AddWithValue("@name", model.Name ?? "");
                cmd.Parameters.AddWithValue("@email", model.Email ?? "");
                cmd.Parameters.AddWithValue("@phone", model.Phone ?? "");
                cmd.Parameters.AddWithValue("@mtype", model.MembershipType ?? "");
                cmd.Parameters.AddWithValue("@expiry", (object)model.ExpiryDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@join", (object)model.JoinDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id", model.Id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static bool RestoreMember(int id)
        {
            using (var conn = new MySqlConnection(ConnStr))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE members SET is_archived = 0 WHERE id=@id;";
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool ArchiveMember(int id)
        {
            using (var conn = new MySqlConnection(ConnStr))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE members SET is_archived = 1 WHERE id=@id;";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}