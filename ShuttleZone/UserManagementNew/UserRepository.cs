using MySql.Data.MySqlClient;
using ShuttleZone.database;
using System.Collections.Generic;

namespace ShuttleZone.UserManagement
{
    public class UserRepository
    {
        // 🔹 GET ALL USERS
        public List<UserModel> GetAllUsers()
        {
            var users = new List<UserModel>();

            using (var conn = DBconnection.GetConnection())
            {
                string query = "SELECT * FROM users";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new UserModel
                        {
                            ID = reader["id"].ToString(),
                            Username = reader["username"].ToString(),
                            FullName = reader["full_name"].ToString(),
                            Email = reader["email"].ToString(),
                            PhoneNumber = reader["phone"]?.ToString(), // ✅ FIX
                            Role = reader["role"].ToString(),
                            Status = reader["status"].ToString(),
                            Password = reader["password"].ToString(),
                            ProfileImagePath = reader["profile_image"]?.ToString()
                        });
                    }
                }
            }

            return users;
        }

        // 🔹 ADD USER
        public void AddUser(UserModel user)
        {
            using (var conn = DBconnection.GetConnection())
            {
                string query = @"INSERT INTO users 
        (id, username, full_name, email, phone, role, status, password, profile_image)
        VALUES (@id, @username, @fullName, @email, @phone, @role, @status, @password, @image)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", user.ID);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@fullName", user.FullName);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@phone", user.PhoneNumber ?? ""); // ✅ FIX
                    cmd.Parameters.AddWithValue("@role", user.Role);
                    cmd.Parameters.AddWithValue("@status", user.Status ?? "Active");
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@image", user.ProfileImagePath ?? "");

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 🔥 SOFT DELETE (ARCHIVE)
        public void DeleteUser(string id)
        {
            using (var conn = DBconnection.GetConnection())
            {
                string query = "UPDATE users SET status = 'Inactive' WHERE id = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 🔥 PERMANENT DELETE (ONLY FROM ARCHIVE)
        public void DeleteUserPermanently(string id)
        {
            using (var conn = DBconnection.GetConnection())
            {
                string query = "DELETE FROM users WHERE id=@id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 🔹 UPDATE STATUS (MANUAL CHANGE)
        public void UpdateUserStatus(string id, string status)
        {
            using (var conn = DBconnection.GetConnection())
            {
                string query = "UPDATE users SET status=@status WHERE id=@id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 🔹 UPDATE PROFILE
        public void UpdateUser(UserModel user)
        {
            using (var conn = DBconnection.GetConnection())
            {
                string query = @"UPDATE users 
                         SET username=@username,
                             full_name=@fullName,
                             email=@email,
                             phone=@phone,
                             role=@role,
                             status=@status,
                             profile_image=@image
                         WHERE id=@id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", user.ID);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@fullName", user.FullName);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@phone", user.PhoneNumber ?? ""); // ✅ FIX
                    cmd.Parameters.AddWithValue("@role", user.Role);
                    cmd.Parameters.AddWithValue("@status", user.Status);
                    cmd.Parameters.AddWithValue("@image", user.ProfileImagePath ?? "");

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 🔹 CHANGE PASSWORD
        public void ChangePassword(string id, string newPassword)
        {
            using (var conn = DBconnection.GetConnection())
            {
                string query = "UPDATE users SET password=@pass WHERE id=@id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@pass", newPassword);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 🔥 RESTORE USER
        public void RestoreUser(string userId)
        {
            using (var conn = DBconnection.GetConnection())
            {
                string query = "UPDATE users SET status = 'Active' WHERE id = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}