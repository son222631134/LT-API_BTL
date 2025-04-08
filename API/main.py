import os
import datetime

import flask
import pyodbc


project_directory = os.path.dirname(os.getcwd())
database_directory = os.path.join(project_directory, 'Database')
server_name = 'DESKTOP-BHA7K14\\SQLEXPRESS'
database_name = 'Database_BTL_API'
conn_str = (
    r'DRIVER={SQL Server};'
    r'SERVER='      + server_name +  ';'
    r'DATABASE='    + database_name + ';'
    r'Integrated Security=True;'
    r'Trusted_Connection=yes;'
)
try:
    conn = pyodbc.connect(conn_str)
    print("Connected to database successfully")
except pyodbc.Error as e:
    print("Error dtb:", e)
app = flask.Flask(__name__)

@app.route('/Login/CheckLogin', methods = ['GET'])
def CheckLogin():
    try:
        # username = 'NV1'
        # password = '123'
        username = flask.request.json.get('username')
        password = flask.request.json.get('password')
        cursor = conn.cursor()
        cursor.execute(
            "SELECT * FROM Account WHERE Username = ? AND Password = ?", username, password
        )
        results = []
        keys = []

        if cursor.rowcount == 0:
            resp = flask.jsonify({"mess": "Login failed"})
            resp.status_code = 200
            return resp
        else:
            resp = flask.jsonify({"mess": "Login successful"})
            resp.status_code = 200
            updateLastLogin(username)
            return resp

        # for i in cursor.description:
        #     keys.append(i[0])
        # for val in cursor.fetchall():
        #     results.append(dict(zip(keys, val)))
        # resp = flask.jsonify(results)
        # resp.status_code = 200
        # return resp
    except Exception as e:
        print('Check Login: ',e)

def updateLastLogin(username):
    try:
        update_conn = pyodbc.connect(conn_str)
        cursor = update_conn.cursor()
        cursor.execute(
            "UPDATE Account SET LastLogin = ? WHERE Username = ?",
            datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S"), username
        )
        update_conn.commit()
        update_conn.close()
        print(datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S"))
    except Exception as e:
        print('Update Last login: ',e)

@app.route('/Logout', methods = ['PUT'])
def Logout():
    try:
        username = flask.request.json.get('username')
        keepLogin = flask.request.json.get('keeplogin')
        TTL = flask.request.json.get('TTL')
        if keepLogin == 'no':
            TTL = 0
        KeepLoginExpDate = datetime.datetime.now() + datetime.timedelta(seconds=TTL)
        cursor = conn.cursor()
        cursor.execute(
            "UPDATE Account SET KeepLoginExpDate = ? WHERE Username = ?", KeepLoginExpDate, username
        )
        conn.commit()
        resp = flask.jsonify({"mess": "Logout successful"})
        resp.status_code = 200
        return resp
    except Exception as e:
        print('Logout: ',e)


def getall(tbl):
    try:
        cursor = conn.cursor()
        cursor.execute("SELECT * FROM " + tbl)
        results = []
        keys = []
        for i in cursor.description:
            keys.append(i[0])
        for val in cursor.fetchall():
            results.append(dict(zip(keys, val)))
        resp = flask.jsonify(results)
        resp.status_code = 200

        return resp
    except Exception as e:
        print(e)

#todo
def add(tbl, data):
    try:
        cursor = conn.cursor()
        sql = "INSERT INTO " + tbl + " VALUES "
        sql += "("
        for i in range(len(data)-1):
            sql += "?,"
        sql += "?)"
        print(sql)
        print(data)
        cursor.execute(sql, data)
        conn.commit()
        resp = flask.jsonify({"mess": "Thêm thành công"})
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

def delete(tbl, col, val):
    try:
        cursor = conn.cursor()
        sql = "DELETE FROM " + tbl + " WHERE " + col + " = " + val
        print(sql)
        cursor.execute(sql)
        print(cursor.rowcount)
        conn.commit()
        if cursor.rowcount == 0:
            resp = flask.jsonify({"mess": "Không tìm thấy"})
        else:
            resp = flask.jsonify({"mess": "Xóa thành công"})
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

#Hang hoa
@app.route('/HangHoa/getall', methods = ['GET'])
def getAllHangHoa():
    return getall('DMHangHoa')
@app.route('/HangHoa/add', methods = ['POST'])
def addHangHoa():
    try:
        maHang = str( flask.request.json.get("MaHang") )
        tenHang = str( flask.request.json.get("TenHang") )
        soLuong = str( flask.request.json.get("SoLuong") )
        donGiaNhap = str( flask.request.json.get("DonGiaNhap") )
        donGiaBan = str( flask.request.json.get("DonGiaBan") )
        maDonVi = str( flask.request.json.get("MaDonVi") )
        maNoiSX = str( flask.request.json.get("MaNoiSX") )
        maCongDung = str( flask.request.json.get("MaCongDung") )
        maMau = str( flask.request.json.get("MaMau") )
        maDacDiem = str( flask.request.json.get("MaDacDiem") )
        imagePath = flask.request.json.get("ImagePath")

        # Save the image to the specified directory
        if imagePath:
            newImagePath = database_directory + '\\Media\\HangHoa\\ImgHangHoa' + maHang + '.jpg';
            with open(imagePath, 'rb') as f:
                with open(newImagePath, 'wb') as f2:
                    f2.write(f.read())
        newImagePath = '\\Media\\HangHoa\\ImgHangHoa' + maHang + '.jpg';

        cursor = conn.cursor()
        sql = ("INSERT INTO DMHangHoa "
               "(MaHang, TenHang, SoLuong, DonGiaNhap, DonGiaBan, MaDonVi, MaNoiSX, MaCongDung, MaMau, MaDacDiem, ImagePath) VALUES (?,?,?,?,?,?,?,?,?,?,?)")
        data =  (maHang, tenHang, soLuong, donGiaNhap, donGiaBan, maDonVi, maNoiSX, maCongDung, maMau, maDacDiem, newImagePath)
        cursor.execute(sql, data)
        conn.commit()
        resp = flask.jsonify({"mess": "Thêm thành công"})
        resp.status_code = 200
        return resp
    except Exception as e:
        print('addHangHoa: ', e)
@app.route('/HangHoa/modify', methods = ['PUT'])
def modifyHangHoa():
    try:
        maHang = str( flask.request.json.get("MaHang") )
        tenHang = str( flask.request.json.get("TenHang") )
        soLuong = str( flask.request.json.get("SoLuong") )
        donGiaNhap = str( flask.request.json.get("DonGiaNhap") )
        donGiaBan = str( flask.request.json.get("DonGiaBan") )
        maDonVi = str( flask.request.json.get("MaDonVi") )
        maNoiSX = str( flask.request.json.get("MaNoiSX") )
        maCongDung = str( flask.request.json.get("MaCongDung") )
        maMau = str( flask.request.json.get("MaMau") )
        maDacDiem = str( flask.request.json.get("MaDacDiem") )
        imagePath = flask.request.json.get("ImagePath")

        # Save the image to the specified directory
        if imagePath:
            newImagePath = database_directory + '\\Media\\HangHoa\\ImgHangHoa' + maHang + '.jpg';
            with open(imagePath, 'rb') as f:
                with open(newImagePath, 'wb') as f2:
                    f2.write(f.read())
        newImagePath = '\\HangHoa\\ImgHangHoa' + maHang + '.jpg';

        cursor = conn.cursor()
        sql = ("UPDATE DMHangHoa SET "
               "TenHang = ?, SoLuong = ?, DonGiaNhap = ?, DonGiaBan = ?, MaDonVi = ?, MaNoiSX = ?, MaCongDung = ?, MaMau = ?, MaDacDiem = ?, ImagePath = ? "
               "WHERE MaHang = ?")
        data =  (tenHang, soLuong, donGiaNhap, donGiaBan, maDonVi, maNoiSX, maCongDung, maMau, maDacDiem, newImagePath, maHang)
        cursor.execute(sql, data)
        conn.commit()
        resp = flask.jsonify({"mess": "Thêm thành công"})
        resp.status_code = 200
        return resp
    except Exception as e:
        print('addHangHoa: ', e)
@app.route('/HangHoa/delete', methods = ['DELETE'])
def deleteHangHoa():
    maHang = str( flask.request.json.get('MaHang') )
    pictureDirectory = database_directory + '\\Media\\HangHoa\\ImgHangHoa' + maHang + '.jpg';
    if os.path.exists(pictureDirectory):
        os.remove(pictureDirectory)
    return delete('DMHangHoa', 'MaHang', maHang)

    try:
        cursor = conn.cursor()
        cursor.execute("DELETE FROM DMHangHoa WHERE MaHang = ?", maHang)
        conn.commit()
        resp = flask.jsonify({"mess": "Xóa thành công"})
        resp.status_code = 200
        return resp
    except Exception as e:
        print('deleteHangHoa: ', e)

#Hoa Don Ban
@app.route('/HoaDonBan/getall', methods = ['GET'])
def getAllHoaDonBan():
    return getall('HoaDonBan')
@app.route('/HoaDonBan/add', methods = ['POST'])
def addHoaDonBan():
    try:
        soHDB = str( flask.request.json.get("SoHDB") )
        maNV = str( flask.request.json.get("MaNV") )
        maKhach = str( flask.request.json.get("MaKhach") )
        ngayBan = str( flask.request.json.get("NgayBan") )
        tongTien = str( flask.request.json.get("TongTien") )

        cursor = conn.cursor()
        sql = ("INSERT INTO HoaDonBan "
               "(SoHDB, MaNV, MaKhach, NgayBan, TongTien) VALUES (?,?,?,?,?)")
        data =  (soHDB, maNV, maKhach, ngayBan, tongTien)
        cursor.execute(sql, data)
        conn.commit()
        resp = flask.jsonify({"mess": "Thêm thành công"})
        resp.status_code = 200
        return resp
    except Exception as e:
        print('addHoaDon: ', e)
@app.route('/HoaDonBan/modify', methods = ['PUT'])
def modifyHoaDonBan():
    try:
        soHDB = str( flask.request.json.get("SoHDB") )
        maNV = str( flask.request.json.get("MaNV") )
        maKhach = str( flask.request.json.get("MaKhach") )
        ngayBan = str( flask.request.json.get("NgayBan") )
        tongTien = str( flask.request.json.get("TongTien") )

        cursor = conn.cursor()
        sql = ("UPDATE HoaDonBan SET "
               "MaNV = ?, MaKhach = ?, NgayBan = ?, TongTien = ? "
               "WHERE SoHDB = ?")
        data =  (maNV, maKhach, ngayBan, tongTien, soHDB)
        cursor.execute(sql, data)
        conn.commit()
        resp = flask.jsonify({"mess": "Thêm thành công"})
        resp.status_code = 200
        return resp
    except Exception as e:
        print('modifyHoaDonBan: ', e)
@app.route('/HoaDonBan/delete', methods = ['DELETE'])


def deleteHoaDonBan():
    soHDB = str(flask.request.json.get('SoHDB'))
    return delete('HoaDonBan', 'SoHDB', soHDB)
    # try:
    #     soHDB = str( flask.request.json.get('SoHDB') )
    #     cursor = conn.cursor()
    #     cursor.execute("DELETE FROM HoaDonBan WHERE SoHDB = ?", soHDB)
    #     conn.commit()
    #     resp = flask.jsonify({"mess": "Xóa thành công"})
    #     resp.status_code = 200
    #     return resp
    # except Exception as e:
    #     print('deleteHoaDonBan: ', e)

#Hoa Don Nhap
@app.route('/HoaDonNhap/getall', methods = ['GET'])
def getAllHoaDonNhap():
    return getall('HoaDonNhap')
@app.route('/HoaDonNhap/add', methods = ['POST'])
def addHoaDonNhap():
    try:
        soHDN = str( flask.request.json.get("SoHDN") )
        maNV = str( flask.request.json.get("MaNV") )
        maNCC = str( flask.request.json.get("MaNCC") )
        ngayNhap = str( flask.request.json.get("NgayNhap") )
        tongTien = str( flask.request.json.get("TongTien") )

        cursor = conn.cursor()
        sql = ("INSERT INTO HoaDonNhap "
               "(SoHDN, MaNV, MaNCC, NgayNhap, TongTien) VALUES (?,?,?,?,?)")
        data =  (soHDN, maNV, maNCC, ngayNhap, tongTien)
        cursor.execute(sql, data)
        conn.commit()
        resp = flask.jsonify({"mess": "Thêm thành công"})
        resp.status_code = 200
        return resp
    except Exception as e:
        print('addHoaDon: ', e)
@app.route('/HoaDonNhap/modify', methods = ['PUT'])
def modifyHoaDonNhap():
    try:
        soHDN = str( flask.request.json.get("SoHDN") )
        maNV = str( flask.request.json.get("MaNV") )
        maNCC = str( flask.request.json.get("MaNCC") )
        ngayNhap = str( flask.request.json.get("NgayNhap") )
        tongTien = str( flask.request.json.get("TongTien") )

        cursor = conn.cursor()
        sql = ("UPDATE HoaDonNhap SET "
               "MaNV = ?, MaNCC = ?, NgayNhap = ?, TongTien = ? "
               "WHERE SoHDN = ? ")
        data =  (maNV, maNCC, ngayNhap, tongTien, soHDN)
        cursor.execute(sql, data)
        conn.commit()
        resp = flask.jsonify({"mess": "Thêm thành công"})
        resp.status_code = 200
        return resp
    except Exception as e:
        print('modifyHoaDonBan: ', e)
@app.route('/HoaDonNhap/delete', methods = ['DELETE'])
def deleteHoaDonNhap():
    soHDN = str(flask.request.json.get('SoHDN'))
    return delete('HoaDonNhap', 'SoHDN', soHDN)





#----------------------------------------------
#API GET: Lấy thông tin toàn bộ khách hàngđe
@app.route('/SanPham/getall', methods = ['GET'])
def getAllSanPham():
    try:
        cursor = conn.cursor()
        cursor.execute("select *from tblSanPham")
        results = []
        keys = []
        for i in cursor.description:
            keys.append(i[0])
        for val in cursor.fetchall():
            results.append(dict(zip(keys, val)))
        resp = flask.jsonify(results)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)


@app.route('/SanPham/find/<TenSP>/<TenCL>', methods = ['GET'])
def findSanPham(TenSP,TenCL):
    try:
        cursor = conn.cursor()
        cursor.execute("select tblSanPham.* from tblSanPham"
                       " join tblChatLieu on tblSanPham.ChatLieu = tblChatLieu.MaCL"
                       " where tblSanPham.TenSP LIKE ? AND tblChatLieu.TenCL LIKE ?",TenSP, TenCL)
        results = []
        keys = []
        for i in cursor.description:
            keys.append(i[0])
        for val in cursor.fetchall():
            results.append(dict(zip(keys, val)))
        resp = flask.jsonify(results)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)
@app.route('/SanPham/tonKho', methods = ['GET'])
def findTonKho():
    try:
        cursor = conn.cursor()
        cursor.execute("select tblSanPham.* from tblSanPham"
                       " where SoLuong>0")
        results = []
        keys = []
        for i in cursor.description:
            keys.append(i[0])
        for val in cursor.fetchall():
            results.append(dict(zip(keys, val)))
        resp = flask.jsonify(results)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)


@app.route('/SanPham/add', methods = ['POST'])
def add():
    try:
        maSP = flask.request.json.get("MaSP")
        tenSP = flask.request.json.get("TenSP")
        cursor = conn.cursor()
        sql = "insert into tblSanPham(MaSP,TenSP) values( ?, ?)"
        data = (maSP, tenSP)
        cursor.execute(sql, data)
        conn.commit()
        resp = flask.jsonify({"mess": "thành công"})
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)


if __name__ == "__main__":
    print('\n')
    print(database_directory)
    print(pyodbc.drivers())
    app.run()
