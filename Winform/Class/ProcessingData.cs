using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_Prj.Class
{
    internal class ProcessingData
    {
        private static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="
                                                    + Prepare.getDatabaseDirectory()
                                                    + ";Integrated Security=True;";
        private static SqlConnection sqlConnection;
        public static SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }

        public ProcessingData() { }

        public static void OpenConnection()
        {
            if (sqlConnection == null)
                sqlConnection = new SqlConnection(connectionString);

            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
        }
        public static void CloseConnection()
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
                sqlConnection.Close();
        }
        
        // For DanhMucHangHoa, DanhMucKhachHang, HoaDonBan, HoaDonNhap
            // Phương thức lấy dữ liệu từ bất kỳ bảng nào theo truy vấn SQL
            public static DataTable GetData(string query, Dictionary<string, object> parameters = null)
            {
                DataTable dataTable = new DataTable();
                try
                {
                    // OpenConnection();
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching data: " + ex.Message);
                }
                finally
                {
                    // CloseConnection();
                }
                return dataTable;
            }


        // Phương thức thực thi câu lệnh SQL (INSERT, UPDATE, DELETE)
        public static void ExecuteQuery(string query, Dictionary<string, object> parameters = null)
            {
                try
                {
                    // OpenConnection();
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error executing query: " + ex.Message);
                }
                finally
                {
                    // CloseConnection();
                }
            }

            // Phương thức INSERT tổng quát vào bất kỳ bảng nào
            public static void Insert(string tableName, Dictionary<string, object> columnValues)
            {
                string columns = string.Join(", ", columnValues.Keys);
                string values = string.Join(", ", columnValues.Keys.Select(k => "@" + k));

                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

                ExecuteQuery(query, columnValues);
            }

            // Phương thức UPDATE tổng quát cho bất kỳ bảng nào
            public static void Update(string tableName, Dictionary<string, object> columnValues, string conditionColumn, object conditionValue)
            {
                string setClause = string.Join(", ", columnValues.Keys.Select(k => $"{k} = @{k}"));
                string query = $"UPDATE {tableName} SET {setClause} WHERE {conditionColumn} = @{conditionColumn}";

                columnValues.Add(conditionColumn, conditionValue); // Thêm điều kiện WHERE vào parameters
                ExecuteQuery(query, columnValues);
            }

            // Phương thức DELETE tổng quát cho bất kỳ bảng nào
            public static void Delete(string tableName, string conditionColumn, object conditionValue)
            {
                string query = $"DELETE FROM {tableName} WHERE {conditionColumn} = @{conditionColumn}";

                var parameters = new Dictionary<string, object>
                {
                    { conditionColumn, conditionValue }
                };

                ExecuteQuery(query, parameters);
            }

            // Phương thức lấy dữ liệu cho ComboBox từ bất kỳ bảng nào
            public static DataTable GetComboBoxData(string tableName, string valueColumn, string displayColumn)
            {
                string query = $"SELECT {valueColumn}, {displayColumn} FROM {tableName}";
                return GetData(query);
            }

            // Phương thức tìm kiếm tổng quát cho bất kỳ bảng nào theo cột cụ thể
            public static DataTable Search(string tableName, string[] columnsToSearch, string searchValue)
            {
                string condition = string.Join(" OR ", columnsToSearch.Select(c => $"{c} LIKE @searchValue"));
                string query = $"SELECT * FROM {tableName} WHERE {condition}";

                var parameters = new Dictionary<string, object>
                {
                    { "@searchValue", "%" + searchValue + "%" }
                };

                return GetData(query, parameters);
            }
            
            

/*
        //DanhMucHangHoa
            // Phương thức lấy dữ liệu từ bất kỳ bảng nào theo truy vấn SQL
            public DataTable DanhMucHangHoa_GetData(string query, Dictionary<string, object> parameters = null)
                {
                    DataTable dataTable = new DataTable();
                    try
                    {
                        // OpenConnection();
                        using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                        {
                            if (parameters != null)
                            {
                                foreach (var param in parameters)
                                {
                                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                                }
                            }

                            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                            {
                                adapter.Fill(dataTable);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error fetching data: " + ex.Message);
                    }
                    finally
                    {
                        // CloseConnection();
                    }
                    return dataTable;
                }

            // Phương thức thực thi câu lệnh SQL (INSERT, UPDATE, DELETE)
            public void DanhMucHangHoa_ExecuteQuery(string query, Dictionary<string, object> parameters = null)
            {
                try
                {
                    // OpenConnection();
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error executing query: " + ex.Message);
                }
                finally
                {
                    // CloseConnection();
                }
            }

            // Phương thức INSERT tổng quát vào bất kỳ bảng nào
            public void DanhMucHangHoa_Insert(string tableName, Dictionary<string, object> columnValues)
            {
                string columns = string.Join(", ", columnValues.Keys);
                string values = string.Join(", ", columnValues.Keys.Select(k => "@" + k));

                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

                DanhMucHangHoa_ExecuteQuery(query, columnValues);
            }

            // Phương thức UPDATE tổng quát cho bất kỳ bảng nào
            public void DanhMucHangHoa_Update(string tableName, Dictionary<string, object> columnValues, string conditionColumn, object conditionValue)
            {
                string setClause = string.Join(", ", columnValues.Keys.Select(k => $"{k} = @{k}"));
                string query = $"UPDATE {tableName} SET {setClause} WHERE {conditionColumn} = @{conditionColumn}";

                columnValues.Add(conditionColumn, conditionValue); // Thêm điều kiện WHERE vào parameters
                DanhMucHangHoa_ExecuteQuery(query, columnValues);
            }

            // Phương thức DELETE tổng quát cho bất kỳ bảng nào
            public void DanhMucHangHoa_Delete(string tableName, string conditionColumn, object conditionValue)
            {
                string query = $"DELETE FROM {tableName} WHERE {conditionColumn} = @{conditionColumn}";

                var parameters = new Dictionary<string, object>
                {
                    { conditionColumn, conditionValue }
                };

                DanhMucHangHoa_ExecuteQuery(query, parameters);
            }

            // Phương thức lấy dữ liệu cho ComboBox từ bất kỳ bảng nào
            public DataTable DanhMucHangHoa_GetComboBoxData(string tableName, string valueColumn, string displayColumn)
            {
                string query = $"SELECT {valueColumn}, {displayColumn} FROM {tableName}";
                return DanhMucHangHoa_GetData(query);
            }

            // Phương thức tìm kiếm tổng quát cho bất kỳ bảng nào theo cột cụ thể
            public DataTable DanhMucHangHoa_Search(string tableName, string[] columnsToSearch, string searchValue)
            {
                string condition = string.Join(" OR ", columnsToSearch.Select(c => $"{c} LIKE @searchValue"));
                string query = $"SELECT * FROM {tableName} WHERE {condition}";

                var parameters = new Dictionary<string, object>
                {
                    { "@searchValue", "%" + searchValue + "%" }
                };

                return DanhMucHangHoa_GetData(query, parameters);
            }

        //DanhMucKhachHang
            // Phương thức lấy dữ liệu từ bất kỳ bảng nào theo truy vấn SQL
            public DataTable DanhMucKhachHang_GetData(string query, Dictionary<string, object> parameters = null)
            {
                DataTable dataTable = new DataTable();
                try
                {
                    // OpenConnection();
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching data: " + ex.Message);
                }
                finally
                {
                    // CloseConnection();
                }
                return dataTable;
            }

            // Phương thức thực thi câu lệnh SQL (INSERT, UPDATE, DELETE)
            public void DanhMucKhachHang_ExecuteQuery(string query, Dictionary<string, object> parameters = null)
            {
                try
                {
                    // OpenConnection();
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error executing query: " + ex.Message);
                }
                finally
                {
                    // CloseConnection();
                }
            }

            // Phương thức INSERT tổng quát vào bất kỳ bảng nào
            public void DanhMucKhachHang_Insert(string tableName, Dictionary<string, object> columnValues)
            {
                string columns = string.Join(", ", columnValues.Keys);
                string values = string.Join(", ", columnValues.Keys.Select(k => "@" + k));

                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

                DanhMucKhachHang_ExecuteQuery(query, columnValues);
            }

            // Phương thức UPDATE tổng quát cho bất kỳ bảng nào
            public void DanhMucKhachHang_Update(string tableName, Dictionary<string, object> columnValues, string conditionColumn, object conditionValue)
            {
                string setClause = string.Join(", ", columnValues.Keys.Select(k => $"{k} = @{k}"));
                string query = $"UPDATE {tableName} SET {setClause} WHERE {conditionColumn} = @{conditionColumn}";

                columnValues.Add(conditionColumn, conditionValue); // Thêm điều kiện WHERE vào parameters
                DanhMucKhachHang_ExecuteQuery(query, columnValues);
            }

            // Phương thức DELETE tổng quát cho bất kỳ bảng nào
            public void DanhMucKhachHang_Delete(string tableName, string conditionColumn, object conditionValue)
            {
                string query = $"DELETE FROM {tableName} WHERE {conditionColumn} = @{conditionColumn}";

                var parameters = new Dictionary<string, object>
                {
                    { conditionColumn, conditionValue }
                };

                DanhMucKhachHang_ExecuteQuery(query, parameters);
            }

            // Phương thức lấy dữ liệu cho ComboBox từ bất kỳ bảng nào
            public DataTable DanhMucKhachHang_GetComboBoxData(string tableName, string valueColumn, string displayColumn)
            {
                string query = $"SELECT {valueColumn}, {displayColumn} FROM {tableName}";
                return DanhMucKhachHang_GetData(query);
            }

            // Phương thức tìm kiếm tổng quát cho bất kỳ bảng nào theo cột cụ thể
            public DataTable DanhMucKhachHang_Search(string tableName, string[] columnsToSearch, string searchValue)
            {
                string condition = string.Join(" OR ", columnsToSearch.Select(c => $"{c} LIKE @searchValue"));
                string query = $"SELECT * FROM {tableName} WHERE {condition}";

                var parameters = new Dictionary<string, object>
                {
                    { "@searchValue", "%" + searchValue + "%" }
                };

                return DanhMucKhachHang_GetData(query, parameters);
            }

        //HoaDonBan
            // Phương thức lấy dữ liệu từ bất kỳ bảng nào theo truy vấn SQL
            public DataTable HoaDonBan_GetData(string query, Dictionary<string, object> parameters = null)
            {
                DataTable dataTable = new DataTable();
                try
                {
                    // OpenConnection();
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching data: " + ex.Message);
                }
                finally
                {
                    // CloseConnection();
                }
                return dataTable;
            }

            // Phương thức thực thi câu lệnh SQL (INSERT, UPDATE, DELETE)
            public void HoaDonBan_ExecuteQuery(string query, Dictionary<string, object> parameters = null)
            {
                try
                {
                    // OpenConnection();
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error executing query: " + ex.Message);
                }
                finally
                {
                    // CloseConnection();
                }
            }

            // Phương thức INSERT tổng quát vào bất kỳ bảng nào
            public void HoaDonBan_Insert(string tableName, Dictionary<string, object> columnValues)
            {
                string columns = string.Join(", ", columnValues.Keys);
                string values = string.Join(", ", columnValues.Keys.Select(k => "@" + k));

                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

                HoaDonBan_ExecuteQuery(query, columnValues);
            }

            // Phương thức UPDATE tổng quát cho bất kỳ bảng nào
            public void HoaDonBan_Update(string tableName, Dictionary<string, object> columnValues, string conditionColumn, object conditionValue)
            {
                string setClause = string.Join(", ", columnValues.Keys.Select(k => $"{k} = @{k}"));
                string query = $"UPDATE {tableName} SET {setClause} WHERE {conditionColumn} = @{conditionColumn}";

                columnValues.Add(conditionColumn, conditionValue); // Thêm điều kiện WHERE vào parameters
                HoaDonBan_ExecuteQuery(query, columnValues);
            }

            // Phương thức DELETE tổng quát cho bất kỳ bảng nào
            public void HoaDonBan_Delete(string tableName, string conditionColumn, object conditionValue)
            {
                string query = $"DELETE FROM {tableName} WHERE {conditionColumn} = @{conditionColumn}";

                var parameters = new Dictionary<string, object>
                {
                    { conditionColumn, conditionValue }
                };

                HoaDonBan_ExecuteQuery(query, parameters);
            }

            // Phương thức lấy dữ liệu cho ComboBox từ bất kỳ bảng nào
            public DataTable HoaDonBan_GetComboBoxData(string tableName, string valueColumn, string displayColumn)
            {
                string query = $"SELECT {valueColumn}, {displayColumn} FROM {tableName}";
                return HoaDonBan_GetData(query);
            }

            // Phương thức tìm kiếm tổng quát cho bất kỳ bảng nào theo cột cụ thể
            public DataTable HoaDonBan_Search(string tableName, string[] columnsToSearch, string searchValue)
            {
                string condition = string.Join(" OR ", columnsToSearch.Select(c => $"{c} LIKE @searchValue"));
                string query = $"SELECT * FROM {tableName} WHERE {condition}";

                var parameters = new Dictionary<string, object>
                {
                    { "@searchValue", "%" + searchValue + "%" }
                };

                return HoaDonBan_GetData(query, parameters);
            }


        //HoaDonNhap
            // Phương thức lấy dữ liệu từ bất kỳ bảng nào theo truy vấn SQL
            public DataTable HoaDonNhap_GetData(string query, Dictionary<string, object> parameters = null)
            {
                DataTable dataTable = new DataTable();
                try
                {
                    // OpenConnection();
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching data: " + ex.Message);
                }
                finally
                {
                    // CloseConnection();
                }
                return dataTable;
            }

            // Phương thức thực thi câu lệnh SQL (INSERT, UPDATE, DELETE)
            public void HoaDonNhap_ExecuteQuery(string query, Dictionary<string, object> parameters = null)
            {
                try
                {
                    // OpenConnection();
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching data: " + ex.Message);
                    }
                finally
                {
                    // CloseConnection();
                }
            }

            // Phương thức INSERT tổng quát vào bất kỳ bảng nào
            public void HoaDonNhap_Insert(string tableName, Dictionary<string, object> columnValues)
            {
                string columns = string.Join(", ", columnValues.Keys);
                string values = string.Join(", ", columnValues.Keys.Select(k => "@" + k));

                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

                HoaDonNhap_ExecuteQuery(query, columnValues);
            }

            // Phương thức UPDATE tổng quát cho bất kỳ bảng nào
            public void HoaDonNhap_Update(string tableName, Dictionary<string, object> columnValues, string conditionColumn, object conditionValue)
            {
                string setClause = string.Join(", ", columnValues.Keys.Select(k => $"{k} = @{k}"));
                string query = $"UPDATE {tableName} SET {setClause} WHERE {conditionColumn} = @{conditionColumn}";

                columnValues.Add(conditionColumn, conditionValue); // Thêm điều kiện WHERE vào parameters
                HoaDonNhap_ExecuteQuery(query, columnValues);
            }

            // Phương thức DELETE tổng quát cho bất kỳ bảng nào
            public void HoaDonNhap_Delete(string tableName, string conditionColumn, object conditionValue)
            {
                string query = $"DELETE FROM {tableName} WHERE {conditionColumn} = @{conditionColumn}";

                var parameters = new Dictionary<string, object>
                {
                    { conditionColumn, conditionValue }
                };

                HoaDonNhap_ExecuteQuery(query, parameters);
            }

            // Phương thức lấy dữ liệu cho ComboBox từ bất kỳ bảng nào
            public DataTable HoaDonNhap_GetComboBoxData(string tableName, string valueColumn, string displayColumn)
            {
                string query = $"SELECT {valueColumn}, {displayColumn} FROM {tableName}";
                return HoaDonNhap_GetData(query);
            }

            // Phương thức tìm kiếm tổng quát cho bất kỳ bảng nào theo cột cụ thể
            public DataTable HoaDonNhap_Search(string tableName, string[] columnsToSearch, string searchValue)
            {
                string condition = string.Join(" OR ", columnsToSearch.Select(c => $"{c} LIKE @searchValue"));
                string query = $"SELECT * FROM {tableName} WHERE {condition}";

                var parameters = new Dictionary<string, object>
                {
                    { "@searchValue", "%" + searchValue + "%" }
                };

                return HoaDonNhap_GetData(query, parameters);
            }
*/

        //NhanVien
            public static DataTable NhanVien_GetAllNhanVien()
            {
                // using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM NhanVien";
                    SqlDataAdapter adt = new SqlDataAdapter(query, sqlConnection);
                    DataTable dt = new DataTable();
                    adt.Fill(dt);
                    return dt;
                }
            }
            public static DataTable GetAllHangHoa()
            {
                // using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM DMHangHoa";
                    SqlDataAdapter adt = new SqlDataAdapter(query, sqlConnection);
                    DataTable dt = new DataTable();
                    adt.Fill(dt);
                    return dt;
                }
            }
            public static DataTable GetAllKhachHang()
            {
                // using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM KhachHang";
                    SqlDataAdapter adt = new SqlDataAdapter(query, sqlConnection);
                    DataTable dt = new DataTable();
                    adt.Fill(dt);
                    return dt;
                }
            }
        public static void NhanVien_AddNhanVien(string maNV, string tenNV, string diaChi, string dienThoai, string gioiTinh, DateTime ngaySinh, string maCV)
            {
                // using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    // sqlConnection.Open();
                    string query = "INSERT INTO NhanVien (MaNV, TenNV, DiaChi, DienThoai, GioiTinh, NgaySinh, MaCV) VALUES (@MaNV, @TenNV, @DiaChi, @DienThoai, @GioiTinh, @NgaySinh, @MaCV)";
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        cmd.Parameters.AddWithValue("@TenNV", tenNV);
                        cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                        cmd.Parameters.AddWithValue("@DienThoai", dienThoai);
                        cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@MaCV", maCV);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            public static void NhanVien_UpdateNhanVien(string maNV, string tenNV, string diaChi, string dienThoai, string gioiTinh, DateTime ngaySinh, string maCV)
            {
                // using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    // sqlConnection.Open();
                    string query = "UPDATE NhanVien SET TenNV = @TenNV, DiaChi = @DiaChi, DienThoai = @DienThoai, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, MaCV = @MaCV WHERE MaNV = @MaNV";
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        cmd.Parameters.AddWithValue("@TenNV", tenNV);
                        cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                        cmd.Parameters.AddWithValue("@DienThoai", dienThoai);
                        cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@MaCV", maCV);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            public static void NhanVien_DeleteNhanVien(string maNV)
            {
                // using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    // sqlConnection.Open();
                    string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            public static DataTable NhanVien_SearchNhanVien(string searchValue)
            {
                // using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM NhanVien WHERE MaNV LIKE @Search OR TenNV LIKE @Search";
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    cmd.Parameters.AddWithValue("@Search", "%" + searchValue + "%");
                    SqlDataAdapter adt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adt.Fill(dt);
                    return dt;
                }
            }
            public static DataTable NhanVien_GetMaCVList()
            {
                // using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string query = "SELECT MaCV FROM CongViec";
                    SqlDataAdapter adt = new SqlDataAdapter(query, sqlConnection);
                    DataTable dt = new DataTable();
                    adt.Fill(dt);
                    return dt;
                }
            }

        public static void RunSQLQuerry(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))  // Giả định có connectionString
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Nếu có tham số thì thêm vào câu lệnh
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
