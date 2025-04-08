from flask import Flask, request, jsonify
from flask_sqlalchemy import SQLAlchemy

app = Flask(__name__)

app.config['SQLALCHEMY_DATABASE_URI'] = 'mssql+pyodbc://@MSI/DuLieu?driver=ODBC+Driver+17+for+SQL+Server&Trusted_Connection=yes'
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False

db = SQLAlchemy(app)

class ChatLieu(db.Model):
    __tablename__ = 'tblChatLieu'
    MaCL = db.Column(db.Integer, primary_key=True)
    TenCL = db.Column(db.String(50), nullable=False)

    # Quan hệ ngược để truy cập từ SanPham
    sanphams = db.relationship('SanPham', backref='chatlieu', lazy=True)

    def __repr__(self):
        return f"<ChatLieu(MaCL={self.MaCL}, TenCL='{self.TenCL}')>"

class SanPham(db.Model):
    __tablename__ = 'tblSanPham'
    MaSP = db.Column(db.Integer, primary_key=True)
    TenSP = db.Column(db.Unicode(100), nullable=False)  # Hỗ trợ Unicode
    ChatLieu = db.Column(db.Integer, db.ForeignKey('tblChatLieu.MaCL'))
    MoTa = db.Column(db.Unicode(255))  # Hỗ trợ Unicode
    GiaNhap = db.Column(db.Float)
    GiaBan = db.Column(db.Float)
    SoLuong = db.Column(db.Integer)

    def __repr__(self):
        return f"<SanPham(MaSP={self.MaSP}, TenSP='{self.TenSP}', ChatLieu={self.ChatLieu})>"



@app.route('/sanpham', methods=['GET'])
def get_all_products():
    products = SanPham.query.all()
    result = [
        {
            "MaSP": p.MaSP,
            "TenSP": p.TenSP,
            "ChatLieu": p.chatlieu.TenCL if p.chatlieu else None,
            "MoTa": p.MoTa,
            "GiaNhap": p.GiaNhap,
            "GiaBan": p.GiaBan,
            "SoLuong": p.SoLuong
        }
        for p in products
    ]
    return jsonify(result)

@app.route('/sanpham/timkiem', methods=['GET'])
def tim_kiem_san_pham():
    ten_sp = request.args.get('TenSP', '')
    chat_lieu = request.args.get('ChatLieu', '')

    san_pham = db.session.query(SanPham).join(ChatLieu, SanPham.ChatLieu == ChatLieu.MaCL) \
        .filter(SanPham.TenSP.collate('Vietnamese_CI_AI').ilike(f"%{ten_sp}%")) \
        .filter(ChatLieu.TenCL.collate('Vietnamese_CI_AI').ilike(f"%{chat_lieu}%")) \
        .all()

    if not san_pham:
        return jsonify({"message": "Không tìm thấy sản phẩm phù hợp"}), 404

    result = [{"MaSP": sp.MaSP, "TenSP": sp.TenSP, "ChatLieu": sp.ChatLieu, "GiaBan": sp.GiaBan} for sp in san_pham]
    return jsonify(result)


@app.route('/sanpham/tonkho', methods=['GET'])
def get_in_stock_products():
    products = SanPham.query.filter(SanPham.SoLuong > 0).all()
    result = [
        {
            "MaSP": p.MaSP,
            "TenSP": p.TenSP,
            "ChatLieu": p.chatlieu.TenCL if p.chatlieu else None,
            "MoTa": p.MoTa,
            "GiaNhap": p.GiaNhap,
            "GiaBan": p.GiaBan,
            "SoLuong": p.SoLuong
        }
        for p in products
    ]
    return jsonify(result)


@app.route('/sanpham', methods=['POST'])
def add_product():
    data = request.json
    new_product = SanPham(
        TenSP=data['TenSP'],
        ChatLieu=data['ChatLieu'],
        MoTa=data.get('MoTa', ''),
        GiaNhap=data['GiaNhap'],
        GiaBan=data['GiaBan'],
        SoLuong=data['SoLuong']
    )
    db.session.add(new_product)
    db.session.commit()
    return jsonify({"message": "Sản phẩm đã được thêm!"}), 201

# API cập nhật sản phẩm
@app.route('/sanpham/<int:masp>', methods=['PUT'])
def update_product(masp):
    product = SanPham.query.get(masp)
    if not product:
        return jsonify({"message": "Không tìm thấy sản phẩm!"}), 404

    data = request.json
    product.TenSP = data.get('TenSP', product.TenSP)
    product.ChatLieu = data.get('ChatLieu', product.ChatLieu)
    product.MoTa = data.get('MoTa', product.MoTa)
    product.GiaNhap = data.get('GiaNhap', product.GiaNhap)
    product.GiaBan = data.get('GiaBan', product.GiaBan)
    product.SoLuong = data.get('SoLuong', product.SoLuong)

    db.session.commit()
    return jsonify({"message": "Sản phẩm đã được cập nhật!"})


@app.route('/sanpham/<int:masp>', methods=['DELETE'])
def delete_product(masp):
    product = SanPham.query.get(masp)
    if not product:
        return jsonify({"message": "Không tìm thấy sản phẩm!"}), 404

    db.session.delete(product)
    db.session.commit()
    return jsonify({"message": "Sản phẩm đã được xóa!"})


if __name__ == '__main__':
    app.run(debug=True)
